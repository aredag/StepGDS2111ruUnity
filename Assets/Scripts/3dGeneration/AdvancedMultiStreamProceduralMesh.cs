using Unity.Collections;
using Unity.Mathematics;
using static Unity.Mathematics.math;
using UnityEngine;
using UnityEngine.Rendering;
using float3 = Unity.Mathematics.float3;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class AdvancedMultiStreamProceduralMesh : MonoBehaviour
{
    #region Private Fields

    MeshFilter _meshFilter;
    MeshRenderer _meshRenderer;
    Mesh _currentMesh;

    int vertexAttributeCount = 4;
    int  triangleIndexes = 6;

    #endregion 
    void OnEnable()
    {
        
        Mesh.MeshDataArray meshDataArray = Mesh.AllocateWritableMeshData(1);
        Mesh.MeshData meshData = meshDataArray[0];
        
        var vertexAttributes = new NativeArray<VertexAttributeDescriptor>(vertexAttributeCount, Allocator.Temp);
        vertexAttributes[0] = new VertexAttributeDescriptor(dimension: 3);
        vertexAttributes[1] = new VertexAttributeDescriptor(VertexAttribute.Normal,dimension: 3, stream: 1);
        vertexAttributes[2] = new VertexAttributeDescriptor(VertexAttribute.Tangent,dimension: 4, stream: 2);
        vertexAttributes[3] = new VertexAttributeDescriptor(VertexAttribute.TexCoord0,dimension: 2, stream: 3);
        
        meshData.SetVertexBufferParams(vertexAttributeCount, vertexAttributes);
        
        var positions = meshData.GetVertexData<float3>();
        positions[0] = 0f;
        positions[1] = float3(1f, 0f, 0f);
        positions[1] = float3(0f, 1f, 0f);
        positions[1] = float3(1f, 1f, 0f);
        
        var normals = meshData.GetVertexData<float3>(1);
        normals[0] = 0f;
        normals[1] = float3(1f, 0f, 0f);
        normals[1] = float3(0f, 1f, 0f);
        normals[1] = float3(1f, 1f, 0f);
        
        var tangents = meshData.GetVertexData<float4>(2);
        tangents[0] = tangents[1] = tangents[2] = tangents[3] = float4(1f, 0, 0, -1f);
        
        var textCoord = meshData.GetVertexData<float2>(3);
        textCoord[0] = 0f;
        textCoord[1] = float2(1f,0f);
        textCoord[2] = float2(0f,1f);
        textCoord[3] = float2(1f, 1f);
        
        meshData.subMeshCount = 1;
        
        meshData.SetIndexBufferParams(triangleIndexes, IndexFormat.UInt16);
        var trianglesPos = meshData.GetIndexData<ushort>();
        trianglesPos[0] = 0;
        trianglesPos[1] = 2;
        trianglesPos[2] = 1;
        trianglesPos[3] = 1;
        trianglesPos[4] = 2;
        trianglesPos[5] = 3;
        
        var triangleIndices = meshData.GetIndexData<ushort>();
        meshData.SetSubMesh(0, new SubMeshDescriptor(0, triangleIndices.Length));
        
        _meshFilter = GetComponent<MeshFilter>();
        
        _currentMesh = new Mesh()
        {
            name = "Advanced Procedural Name"
        };

        _meshFilter.mesh = _currentMesh;
        
        vertexAttributes.Dispose();
        
        Mesh.ApplyAndDisposeWritableMeshData(meshDataArray, _currentMesh);
        
    }
}
