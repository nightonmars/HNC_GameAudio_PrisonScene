using TMPro;
using UnityEngine;

public class TextDilateController : MonoBehaviour
{
    public TMP_Text textPro; // Reference to the TextMeshPro component
    public float dilateSpeed = 1f; // Speed of dilate change
    private Material textMaterial;
    private bool dilate;

    void Start()
    {
        // Get the material of the TextMeshPro component
        textMaterial = textPro.fontMaterial;
    }
    [ContextMenu("Dilate")]
    public void StartDilate()
    {
        dilate = true; 
    }

    void Update()
    {
        if (dilate)
        {
            float currentDilate = textMaterial.GetFloat(ShaderUtilities.ID_FaceDilate);
            currentDilate += dilateSpeed * Time.deltaTime;
            textMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, currentDilate);
            if (currentDilate >= 0)
            {
                dilate = false;
            }
        }
        
    }

    public void SetDilate(float value)
    {
        // Set dilate to a specific value
        textMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, value);
    }
}