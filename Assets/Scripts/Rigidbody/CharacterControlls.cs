using UnityEngine;
 
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (SphereCollider))]
public class CharacterControlls : MonoBehaviour {
 
    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    Rigidbody rigidbody;
    Collider _sphereCollider;
 
 
 
    void Awake () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
        _sphereCollider = GetComponent<Collider>();
    }
    
 
    void FixedUpdate () {
        if (grounded) {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
 
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rigidbody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
 
            // Jump
            if (canJump && Input.GetButton("Jump")) {
                rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }
 
        rigidbody.AddForce(new Vector3 (0, -gravity * rigidbody.mass, 0));
 
        grounded = false;
    }
 
    void OnCollisionStay()
    {
        grounded = true;    
        Debug.LogError("Stay");
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.LogError("Enter");
    }

    void OnCollisionExit(Collision other)
    {
        Debug.LogError("Exit");
    }
    

    float CalculateJumpVerticalSpeed () {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}