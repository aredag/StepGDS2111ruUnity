using UnityEngine;

public class TransformMover : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, 
            Input.GetAxis("Vertical"));

        transform.position += targetVelocity * speed;

    }
}
