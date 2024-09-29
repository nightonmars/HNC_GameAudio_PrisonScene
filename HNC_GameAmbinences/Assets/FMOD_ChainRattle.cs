using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOD_ChainRattle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("hello");
        }
    }
}
