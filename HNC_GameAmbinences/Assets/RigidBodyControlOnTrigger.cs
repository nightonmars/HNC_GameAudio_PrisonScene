using UnityEngine;

public class RigidBodyControlOnTrigger : MonoBehaviour
{
    public Rigidbody targetRigidbody; // The Rigidbody to disable/enable
    public Transform referenceDirection; // The reference for the correct direction
    public float requiredApproachAngle = 45f; // Angle within which the approach is considered correct

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Calculate direction of approach
            Vector3 approachDirection = other.transform.position - transform.position;
            approachDirection.Normalize();

            // Calculate the angle between the approach direction and the reference forward direction
            float angle = Vector3.Angle(referenceDirection.forward, approachDirection);

            // If the approach angle is within the required range, disable the Rigidbody
            if (angle <= requiredApproachAngle)
            {
                targetRigidbody.isKinematic = true; // Disable Rigidbody by making it kinematic
             //   Debug.Log("Rigidbody disabled: Correct approach detected.");
            }
            else
            {
              //  Debug.Log("Approach angle too wide. Rigidbody remains enabled.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Re-enable the Rigidbody when the player exits the trigger
            targetRigidbody.isKinematic = false;
          //  Debug.Log("Rigidbody re-enabled on trigger exit.");
        }
    }
}