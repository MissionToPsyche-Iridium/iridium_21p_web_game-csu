using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleCollector : MonoBehaviour
{
    private int totalSamples;
    private int collectedSamples;

    void Start()
    {
        totalSamples = GameObject.FindGameObjectsWithTag("Sample").Length;
        collectedSamples = 0;
    }

    public void CollectSample()
    {
        collectedSamples++;
        if (collectedSamples >= totalSamples)
        {
            LoadNextLevel();
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

