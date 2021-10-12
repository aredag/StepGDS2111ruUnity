using System;
using UnityEngine;

public class CubeCaster : MonoBehaviour
{
    private Vector3[] Directions() => new Vector3[] { transform.forward, -transform.forward, transform.right, -transform.right, transform.up, -transform.up };

    private Collider _collider;
    public Transform transformToMove;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }
    
    private void Update()
    {
        foreach (var touch in Input.touches)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //for mouse
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                transformToMove.position = hit.point;
            }
        }
    }

    public void OnDrawGizmos()
    {
        foreach (var dir in Directions())
        {
            DrawRaycastAtHit(dir, out var hit);
        }
    }

    void DrawRaycastAtHit(Vector3 dir, out RaycastHit hit)
    {
        if (Physics.Raycast(transform.position, dir, out hit))
        {
            Gizmos.DrawLine(transform.position, hit.point);
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}