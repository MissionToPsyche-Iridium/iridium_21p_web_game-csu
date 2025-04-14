using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleCollectorForLevelF : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Manually set this to your visible sample count")]
    public int expectedSamples = 5; // Set this to 5 in Inspector

    private int collectedSamples;

    void Start()
    {
        // Double-check for accidental hidden samples
        CleanUpHiddenSamples();

        Debug.Log($"Expecting to collect: {expectedSamples} samples");
    }

    // Call this from your SampleF script
    public void CollectSample()
    {
        collectedSamples++;
        Debug.Log($"Collected: {collectedSamples}/{expectedSamples}");

        if (collectedSamples >= expectedSamples)
        {
            Debug.Log("All collected! Loading MainMenu...");
            LoadMainMenu();
        }
    }

    void LoadMainMenu()
    {
        string sceneName = "MainMenu";
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Missing scene: {sceneName}. Add it via File > Build Settings!");
        }
    }

    // Nuclear option to delete hidden samples
    void CleanUpHiddenSamples()
    {
        GameObject[] allSamples = GameObject.FindGameObjectsWithTag("Sample");
        foreach (GameObject sample in allSamples)
        {
            if (!sample.activeInHierarchy || sample.GetComponent<Collider2D>() == null)
            {
                Debug.LogWarning($"Destroying hidden sample: {sample.name}");
                Destroy(sample);
            }
        }
    }
}