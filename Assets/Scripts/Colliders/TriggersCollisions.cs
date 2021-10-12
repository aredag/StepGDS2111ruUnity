using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("Entered");
    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.LogError("Staying");
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.LogError("Exit");
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Debug.LogError("Entered");
    }
    
    private void OnCollisionExit(Collision other)
    {
        Debug.LogError("Staying");
    }
    
    private void OnCollisionStay(Collision other)
    {
        Debug.LogError("Exit");
    }
}
