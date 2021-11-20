using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SimpleProceduralMesh : MonoBehaviour
{
    #region Private Fields

    MeshFilter _meshFilter;
    MeshRenderer _meshRenderer;
    Mesh _currentMesh;

    #endregion 
    
    #region Serialized Fields
    [SerializeField] [Range(0, 10)] int _mover = 1; 
    #endregion 
    
    void OnEnable()
    {
        _currentMesh = new Mesh
        {
            name = "Procedural name"
        };
        _currentMesh.vertices = new Vector3[]
        {
            Vector3.zero, Vector3.right, Vector3.up, new Vector3(1,1)
        };

        _currentMesh.triangles = new int[]
        {
            0, 2, 1,  //first trig
            1, 2, 3 //second trig
        };
        _currentMesh.normals = new Vector3[]
        {
            Vector3.back, Vector3.back, Vector3.back, Vector3.back,
        };
        
        _currentMesh.uv = new Vector2[]
        {
            Vector3.zero, Vector3.right, Vector3.up, Vector3.one 
        };

        _currentMesh.tangents = new Vector4[]
        {
            new Vector4(1f,0f,0f,-1f),
            new Vector4(1f,0f,0f,-1f),
            new Vector4(1f,0f,0f,-1f),
            new Vector4(1f,0f,0f,-1f),
        };
        
        _meshFilter = GetComponent<MeshFilter>();
        _meshFilter.mesh = _currentMesh;
    }
}
