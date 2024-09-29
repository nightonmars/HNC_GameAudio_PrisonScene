using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimatorToSoundController : MonoBehaviour
{
    [SerializeField] FirstPersonController controller;
    [SerializeField] FMOD_FootStepManager footstepManager;
    private Animator ani;
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] float runSpeed = 1.5f;
    bool playerSprinting;
    float playerSpeed;
    float playerJumping;

    void Start()
    {
        ani = gameObject.GetComponent<Animator>(); 
    }

    private void Update()
    {
        playerSpeed = controller._speed;
        //playerSprinting = controller.isSprinting();
      //  playerJumping = controller.isJumping();

        if (playerSpeed > 1)
        {
            WalkAnimationStart();
         //   Debug.Log("speed" + playerSpeed);
        }
        else if (playerSpeed < 1)
        {
            WalkAnimationStop();
         //   Debug.Log("speed" + playerSpeed);
        }
        
       if(playerSprinting)
        {
            StartRunning();
            footstepManager.SetFootstepRunningLength(); 
        }
       else if (!playerSprinting)
        { StopRunning();
            footstepManager.SetFootstepWalkLength();
        }

       if(!controller.Grounded)
        {
            WalkAnimationStop();        
        }  

       if(!controller.Grounded && playerJumping <= 0.0f)
        {
            footstepManager.JumpSound();
        }

    }
    public void WalkAnimationStart()
    {
        ani.SetBool("isMoving", true);
    }

    public void WalkAnimationStop()
    {
        ani.SetBool("isMoving", false);
    }

    public void StartRunning()
    {
        ani.speed = runSpeed;
    }

    public void StopRunning()
    {
        ani.speed = walkSpeed;
    }
}
