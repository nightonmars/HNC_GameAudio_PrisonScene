using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Animator ani;
    public float doorSpeed = 0.3f;
    public EventReference doorSound;
    public GameObject doorPosition; 
    

    // Store the hash of the trigger parameter
    private int openDoorHash;

    private void Start()
    {
        // Convert the "OpenDoor" trigger string to a hash and store it
        openDoorHash = Animator.StringToHash("OpenDoor");
        ani.speed = doorSpeed; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ani.SetTrigger(openDoorHash);
            RuntimeManager.PlayOneShotAttached(doorSound, doorPosition); 
        }
    }
}
