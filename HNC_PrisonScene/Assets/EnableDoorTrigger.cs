using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDoorTrigger : MonoBehaviour
{
   public Collider door;
   public FMOD_MusicPlayer musicPlayer;

   private void Start()
   { 
      door.enabled = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Mug"))
      {
        door.enabled = true;
        musicPlayer.doorOpenMusic();
        //Debug.Log("Door is triggered");
      }
   }
}
