using UnityEngine;
using System.Collections;
using DG.Tweening;
using FMOD.Studio;
using FMODUnity; 
public class DoorWobble : MonoBehaviour
{
    public EventReference woobleSound;
    public Transform door;
    public Animator doorAnimator; // Reference to the Animator
    public float wobbleDuration = 1f;
    public float wobbleIntensity = 5f;

    [ContextMenu("Wobble door")]
    public void TriggerWobble()
    {
        StartCoroutine(WaitForAnimatorAndWobble());
    }

    private IEnumerator WaitForAnimatorAndWobble()
    {
        if (doorAnimator != null)
        {
            // Disable the Animator
            doorAnimator.enabled = false;

            // Wait for a frame to ensure the Animator stops cancelling animations
            yield return null;
        }

        // Trigger the wobble
        door.DOShakeRotation(wobbleDuration, wobbleIntensity, vibrato: 10, randomness: 90, fadeOut: true);
    }

    public void WobbleSound()
    {
        RuntimeManager.PlayOneShotAttached(woobleSound, gameObject);
    }
}