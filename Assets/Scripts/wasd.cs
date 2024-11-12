using UnityEngine;

public class WASDControl : MonoBehaviour
{
    public float speed = 5f; // Speed multiplier for movement
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Read input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal"); // X-axis movement (A/D or Left/Right)
        float moveVertical = Input.GetAxis("Vertical");     // Z-axis movement (W/S or Up/Down)

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply force to move the sphere
        rb.AddForce(movement * speed);
    }
}
