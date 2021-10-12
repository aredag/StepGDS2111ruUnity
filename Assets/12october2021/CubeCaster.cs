using UnityEngine;

public class CubeCaster : MonoBehaviour
{
    private Vector3[] Directions() => new Vector3[] { transform.forward, -transform.forward, transform.right, -transform.right, transform.up, -transform.up };

    public void OnDrawGizmos()
    {
        foreach (var dir in Directions())
        {
            if (Physics.Raycast(transform.position, dir, out var hit))
            {
                Gizmos.DrawLine(transform.position, hit.point);
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }
}