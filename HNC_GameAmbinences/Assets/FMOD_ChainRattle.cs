using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 

public class FMOD_ChainRattle : MonoBehaviour
{
    public EventReference chainSound;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            RuntimeManager.PlayOneShotAttached(chainSound, gameObject); 
        }
    }
}
