using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Apply a forward force to test movement
        rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
    }
}
