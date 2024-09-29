using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator ani;

    // Store the hash of the trigger parameter
    private int openDoorHash;

    private void Start()
    {
        // Convert the "OpenDoor" trigger string to a hash and store it
        openDoorHash = Animator.StringToHash("OpenDoor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Use the hashed trigger instead of the string
            ani.SetTrigger(openDoorHash);
        }
    }
}
