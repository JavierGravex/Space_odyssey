using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelUIController : MonoBehaviour
{
    [Header("UI References")]
    public Slider fuelSlider;
    public TextMeshProUGUI fuelText;
    
    // NEW: The actual colored part of the slider
    public Image fillImage; 

    [Header("Color Settings")]
    // The timeline of colors
    public Gradient fuelGradient; 

    public void UpdateFuelDisplay(float currentFuel, float maxFuel)
    {
        // 1. Update Slider & Text
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = currentFuel;
        fuelText.text = $"{currentFuel:F0} / {maxFuel:F0}";

        // 2. Change the Color
        if (fillImage != null && fuelText != null)
        {
            // Get the percentage (from 0.0 to 1.0)
            float fuelPercentage = currentFuel / maxFuel;
            
            // Calculate the exact color from your gradient once
            Color currentColor = fuelGradient.Evaluate(fuelPercentage);

            // Apply that color to the slider's fill bar
            fillImage.color = currentColor;
            
            // Apply that EXACT same color to your text!
            fuelText.color = currentColor;
        }
    }
}