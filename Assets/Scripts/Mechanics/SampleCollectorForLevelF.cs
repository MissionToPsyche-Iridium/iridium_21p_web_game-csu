using UnityEngine;
using TMPro; // Critical for Level A's TextMeshPro
using UnityEngine.SceneManagement;

public class SampleCollectorForLevelF : MonoBehaviour
{
    [Header("UI Reference")]
    public TMPro.TextMeshProUGUI sampleCounterText; // Must use TextMeshProUGUI

    [Header("Level F Settings")]
    public int totalSamples = 5; // Set to your metal count
    private int collectedSamples;

    void Start()
    {
        // Initialize UI to "0/5"
        UpdateUI();
        Debug.Log("[Level F] Ready! Samples to collect: " + totalSamples);
    }

    public void CollectSample()
    {
        collectedSamples++;
        UpdateUI();
        Debug.Log($"[Level F] Collected: {collectedSamples}/{totalSamples}");

        if (collectedSamples >= totalSamples)
        {
            Debug.Log("[Level F] Loading MainMenu...");
            SceneManager.LoadScene("MainMenu"); // Your custom transition
        }
    }

    void UpdateUI()
    {
        if (sampleCounterText != null)
            sampleCounterText.text = $"Samples: {collectedSamples}/{totalSamples}";
        else
            Debug.LogWarning("[Level F] UI Text not assigned!");
    }

    // Editor validation
#if UNITY_EDITOR
    void OnValidate()
    {
        if (sampleCounterText == null)
            Debug.LogError("Assign Level A's SampleCounterText!", this);
    }
#endif
}