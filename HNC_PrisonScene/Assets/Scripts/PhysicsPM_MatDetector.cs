using UnityEngine;
/// <summary>
/// Place this script on your player character. It gets the material values and sets the
/// matIdx to be used to set param, switches in your middleware. 
/// </summary>
public class PhysicsPM_MatDetector : MonoBehaviour
{
    [Header("Add the material from PhysicMaterialCreator here")]
    [SerializeField] private PhysicMaterialCreator[] physicsMatCreator;
    public int matIdx { get; private set; }

    private bool[] materialStatus;
    //change this if you're using a rigid body. 
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        materialStatus = new bool[physicsMatCreator.Length];
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        PhysicsMaterial material = hit.collider.sharedMaterial;

        if (material != null)
        {
            for (int i = 0; i < physicsMatCreator.Length; i++)
            {
                PhysicMaterialCreator physicsToSound = physicsMatCreator[i];
                if (material == physicsToSound.pmMatKey && !materialStatus[i])
                {
                    materialStatus[i] = true;
                    // use matIdx to set RTPC/Param for your footstep manager.
                    matIdx = physicsToSound.matIntIdxValue;
                }
                else if (material != physicsToSound.pmMatKey && materialStatus[i])
                {
                    materialStatus[i] = false;
                }
            }
        }
    }
}


 


