using System;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    private RaycastHit hit;

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
           Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red); 
           
           Debug.LogError($"Did hit{hit.collider.gameObject.name}");
        }
        else
        {
           Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) *   1000, Color.white); 
           Debug.LogError("Did not hit");
        }
    }
}
