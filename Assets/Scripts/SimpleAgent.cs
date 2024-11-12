using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class SimpleAgent : Agent
{
    public override void Initialize()
    {
        ;
    }

    public override void OnEpisodeBegin()
    {
       ;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
       ;
        
        // Add a dummy observation to ensure observations are added correctly.
        sensor.AddObservation(transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        ;

        // Check if there are continuous actions available
        if (actions.ContinuousActions.Length >= 2)
        {
            float moveX = actions.ContinuousActions[0];
            float moveZ = actions.ContinuousActions[1];
            Debug.Log($"Action values - X: {moveX}, Z: {moveZ}");

            // Apply movement based on the action values (optional)
            Vector3 move = new Vector3(moveX, 0, moveZ) * 5f;
            transform.localPosition += move * Time.deltaTime;
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
       
        var continuousActions = actionsOut.ContinuousActions;

        // Ensure we have space in the actions array before setting values
        if (continuousActions.Length >= 2)
        {
            continuousActions[0] = Input.GetAxis("Horizontal"); // X-axis control
            continuousActions[1] = Input.GetAxis("Vertical");   // Z-axis control
        }
    }

    private void Update()
    {
       
    }

    private void FixedUpdate()
    {
        
    }
}
