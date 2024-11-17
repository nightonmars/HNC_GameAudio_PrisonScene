using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDoorTrigger : MonoBehaviour
{
   public Collider door;

   private void Start()
   { 
      door.enabled = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Mug"))
      {
        door.enabled = true;
        Debug.Log("Door is triggered");
      }
   }
}
