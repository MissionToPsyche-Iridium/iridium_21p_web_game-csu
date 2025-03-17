using UnityEngine;
using UnityEngine.SceneManagement; // Needed to switch scenes

public class SceneLoadsLevel : MonoBehaviour
{
    // Load Level A
    public void LoadLevelA()
    {
        SceneManager.LoadScene("Level A");
    }
}