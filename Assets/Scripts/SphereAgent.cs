using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class SphereAgent : Agent
{
    public Transform target;      // Reference to the target
    public float moveSpeed = 2f;  // Speed multiplier for the sphere's movement
    private Rigidbody rb;         // Rigidbody for physics-based movement

    private Vector3 startPosition; // Starting position for the sphere

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.localPosition; // Set the initial spawn position
    }

    public override void OnEpisodeBegin()
    {
        // Reset the sphere's position and velocity at the start of each episode
        transform.localPosition = startPosition;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Observe the position of the target relative to the sphere
        sensor.AddObservation(target.localPosition - transform.localPosition);

        // Observe the sphere's current velocity
        sensor.AddObservation(rb.linearVelocity);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log("OnActionReceived called."); // Debug statement

        // Check if there are enough continuous actions available
        if (actions.ContinuousActions.Length >= 2)
        {
            // Convert actions into movement
            Vector3 move = new Vector3(actions.ContinuousActions[0], 0, actions.ContinuousActions[1]);

            // Apply a gradual force to make the sphere roll
            rb.AddForce(move * moveSpeed, ForceMode.Force);

            // Reward the agent as it gets closer to the target
            float distanceToTarget = Vector3.Distance(transform.localPosition, target.localPosition);
            AddReward(-distanceToTarget * 0.01f);  // Small negative reward for distance

            // Check if the agent reached the target
            if (distanceToTarget < 1.5f)
            {
                SetReward(1.0f);  // Positive reward for reaching the target
                Debug.Log("Sphere reached the target!"); // Debug statement
                EndEpisode();
            }

            // If the agent falls off the platform, end the episode with a penalty
            if (transform.localPosition.y < -1)
            {
                SetReward(-1.0f);  // Negative reward for falling off
                EndEpisode();
            }
        }
        else
        {
            Debug.LogError("Not enough continuous actions received.");
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActions = actionsOut.ContinuousActions;

        // Set the continuous actions based on player input for testing
        continuousActions[0] = Input.GetAxis("Horizontal"); // X-axis control
        continuousActions[1] = Input.GetAxis("Vertical");   // Z-axis control
    }
}
