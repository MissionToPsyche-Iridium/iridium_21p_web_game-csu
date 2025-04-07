using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SampleCollector : MonoBehaviour
{
    public static SampleCollector Instance;

    public TextMeshProUGUI sampleText;

    private int totalSamples;
    private int collectedSamples;

    void Awake()
    {
        // Ensure only one instance exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        var allSamples = GameObject.FindGameObjectsWithTag("Sample");
        totalSamples = 0;

        foreach (var sample in allSamples)
        {
            if (sample.activeInHierarchy)
                totalSamples++;
        }

        collectedSamples = 0;

        Debug.Log("Total samples in scene: " + totalSamples);
        UpdateSampleText();
    }

    public void CollectSample()
    {
        collectedSamples++;
        Debug.Log("Collected sample. Current count: " + collectedSamples);
        UpdateSampleText();

        Debug.Log($"Collected {collectedSamples} / {totalSamples}");

        if (collectedSamples >= totalSamples)
        {
            LoadNextLevel();
        }
    }

    void UpdateSampleText()
    {
        if (sampleText != null)
        {
            sampleText.text = $"Samples: {collectedSamples} / {totalSamples}";
        }
        else
        {
            Debug.LogWarning("Sample Text is not assigned!");
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
