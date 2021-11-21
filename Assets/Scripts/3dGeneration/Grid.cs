using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
#region Serialized Fields
    [SerializeField] int _xSize;
    [SerializeField] int _ySize;
    [SerializeField] float _vertexSize = 0.1f;
#endregion

#region Private Fields
    Vector3[] _vertices;
    MeshFilter _meshFilter;
    MeshRenderer _meshRenderer;
#endregion

    void OnEnable()
    {
       StartCoroutine(GenerateGrid());
    }

    IEnumerator GenerateGrid()
    {
        var wait = new WaitForSeconds(0.05f);

        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = new Mesh()
        {
            name = "Grid Mesh",
        };
        
        
        _vertices = new Vector3[(_xSize + 1) * (_ySize + 1)];
        Vector2[] uv = new Vector2[_vertices.Length];

        for (int i = 0, y = 0; y <= _ySize; y++)
        {
            for (int x = 0; x <= _xSize; x++, i++)
            {
                _vertices[i] = new Vector3(x, y);
                uv[i] = new Vector2((float)x / _xSize, (float)y / _ySize);
                yield return wait;
            }
        }

        _meshFilter.mesh.vertices = _vertices;
        _meshFilter.mesh.uv = uv;

        int[] triangles = new int[_xSize * _ySize * 6];

        for (int ti = 0, vi = 0, y = 0; y < _ySize; y++, vi++)
        {
            for (int x = 0; x < _xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3]= triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + _xSize + 1;
                triangles[ti + 5] = vi + _xSize + 2;
                
                _meshFilter.mesh.triangles = triangles;
                
                yield return wait;
            }
        }
        
        _meshFilter.mesh.RecalculateNormals();
        _meshFilter.mesh.RecalculateTangents();
        
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
