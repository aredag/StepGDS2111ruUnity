using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CubeGeneration : MonoBehaviour
{
    
#region Serialized Fields
    [SerializeField] int _xSize;
    [SerializeField] int _ySize;
    [SerializeField] int _zSize;
    [SerializeField] float _vertexSize = 0.1f;
#endregion

#region Private Fields
    Vector3[] _vertices;
    MeshFilter _meshFilter;
    MeshRenderer _meshRenderer;
#endregion
   void OnEnable()
   {
       StartCoroutine(GenerateCube());
   }


   IEnumerator GenerateCube()
   {
       var wait = new WaitForSeconds(0.005f);
       
       _vertices = new Vector3[(_xSize + 1) * (_ySize + 1) * (_zSize + 1)]; //TODO debug vertex count
       
       _meshFilter = GetComponent<MeshFilter>();
       _meshFilter.mesh = new Mesh()
       {
            name = "Cube Mesh",
       };

       /*
       int cornerVertices = 8;
       int edgeVertices = (_xSize + _ySize + _zSize - 3) * 4;
       int faceVertices = ((_xSize - 1) * (_ySize - 1) + (_xSize - 1) * (_zSize - 1) + (_ySize - 1) * (_zSize - 1) * 2);
       _vertices = new Vector3[cornerVertices + edgeVertices + faceVertices];
       */

       int v = 0;

       for (int y = 0; y <= _ySize; y++)
       {
           for (int x = 0; x <= _xSize; x++)
           {
               _vertices[v++] = new Vector3(x, y, 0);
                yield return wait;
           }
           
           for (int z = 1; z <= _zSize; z++)
           {
               _vertices[v++] = new Vector3(_xSize, y, z);
                yield return wait;
           }
           
           for (int x = _xSize - 1; x >= 0; x--)
           {
               _vertices[v++] = new Vector3(x, y, _zSize);
                yield return wait;
           }
           
           for (int z = _zSize - 1; z > 0; z--)
           {
               _vertices[v++] = new Vector3(0, y, z);
                yield return wait;
           }
           
           yield return wait;
       }

       for (int z = 1; z < _zSize; z++)
       {
           for (int x = 1; x < _xSize; x++)
           {
               _vertices[v++] = new Vector3(x, _ySize, z);
           }
       }
       
       for (int z = 1; z < _zSize; z++)
       {
           for (int x = 1; x < _xSize; x++)
           {
               _vertices[v++] = new Vector3(x, 0, z);
           }
       }
       
       GenerateVertices();
       StartCoroutine(GenerateTriangles());

       yield return wait;
   }

   void GenerateVertices()
   {
       _meshFilter.mesh.vertices = _vertices;
   }

   IEnumerator GenerateTriangles()
   {
       int quads = (_xSize * _ySize + _xSize * _zSize + _ySize * _zSize) * 2;
       int[] triangles = new int[quads * 6];
       var wait = new WaitForSeconds(0.005f);

       int ring = (_xSize + _zSize) * 2;
       int t = 0, v = 0;

       for (int y = 0; y < _ySize; y++, v++)
       {
           for (int q = 0; q < ring - 1; q++, v++)
           {
               t = SetQuad(triangles, t, v, v + 1, v + ring, v + ring + 1);
               _meshFilter.mesh.triangles = triangles;
               yield return wait;
           }
           t = SetQuad(triangles, t, v, v - ring + 1, v + ring, v + 1);
           _meshFilter.mesh.triangles = triangles;
         //  t = CrateTopFaces(triangles,t,ring);
           yield return wait;
       }

       yield return wait;
       
   }


   int CrateTopFaces(int[] triangles, int t, int ring)
   {
       int v = ring * _ySize;
       int vMin = ring * (_ySize + 1) - 1;
       int vMid = vMin + 1;
       int vMax = v + 2;

       for (int x = 0; x < _xSize - 1; x++, v++)
       {
           t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + ring);
       }

       for (int z = 1; z < _zSize - 1; z++, vMin--, vMid++, vMax++)
       {
           t = SetQuad(triangles, t, vMin, vMid, vMin - 1, vMid + _xSize - 1);
           for (int x = 1; x < _xSize - 1; x++, vMid++)
           {
               t = SetQuad(triangles, t, vMid, vMid + 1, vMid + _xSize - 1, vMid + _xSize);
           }
           t = SetQuad(triangles, t, vMid, vMax, vMid + _xSize - 1, vMax + 1);
       }
       return t;
   }
   
   int SetQuad(int[] triangles, int i, int v00, int v10,int v01,int v11)
   { 
       triangles[i] = v00;
       triangles[i + 1] = triangles[i + 4] = v01;
       triangles[i + 2] = triangles[i + 3] = v10;
       triangles[i + 5] = v11;
       return i + 6;
   }
   
  void OnDrawGizmos()
    {
        if(_vertices == null) return;
        
        Gizmos.color = Color.red;

        for (int i = 0; i < _vertices.Length; i++)
        {
            Gizmos.DrawSphere(_vertices[i], _vertexSize);
        }
    }
}
