using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FloorContactChecker : MonoBehaviour
{
    public EventReference tableMovingSoundReference; // FMOD event reference
    private EventInstance tableMovingSoundInstance;

    private bool isOnFloor = true; // Tracks if the object is on the floor
    public LayerMask floorLayer; // Define which layers are considered as "floor"
    public float groundCheckRadius = 0.1f; // Radius for ground contact check
    public Transform groundCheckPoint; // Point from where the ground check is performed

    private Rigidbody rb;
    private bool soundHasStarted = false;
    private Vector3 orgPosition; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (groundCheckPoint == null)
        {
            Debug.LogWarning("No ground check point assigned! Defaulting to object's position.");
            groundCheckPoint = transform;
        }

        // Create FMOD event instance
        tableMovingSoundInstance = RuntimeManager.CreateInstance(tableMovingSoundReference);
        orgPosition = rb.transform.position;
    }

    void Update()
    {
        // Perform ground check
        bool wasOnFloor = isOnFloor;
        isOnFloor = Physics.CheckSphere(groundCheckPoint.position, groundCheckRadius, floorLayer);

        if (isOnFloor && !wasOnFloor)
        {
           // Debug.Log("Object regained contact with the floor.");
        }
        else if (!isOnFloor && wasOnFloor)
        {
         //   Debug.Log("Object lost contact with the floor!");
        }

        if (rb != null)
        {
            Vector3 velocity = rb.linearVelocity;
//            Debug.Log("Rigidbody Velocity: " + velocity);

            // Check if velocity has stopped
            if (velocity.magnitude <= 0.01f) // Adjust threshold if necessary
            {
             //   Debug.Log("Velocity has stopped.");

                if (soundHasStarted)
                {
                    StopFMODSound();
                    soundHasStarted = false; // Reset the sound start flag
                }
            }
            else
            {
                // Start FMOD sound if object is moving
                Vector3 position = rb.transform.position;
                if (position != orgPosition && !soundHasStarted)
                {
                    StartFMODSound();
                    soundHasStarted = true;
                }
            }
        }
    }

    private void StartFMODSound()
    {
        tableMovingSoundInstance.start();
    }

    private void StopFMODSound()
    {
        tableMovingSoundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }


    private void OnDestroy()
    {
        // Release FMOD event instance to free resources
        tableMovingSoundInstance.release();
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the ground check radius in the editor
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}
