using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Register a callback for when the video finishes
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Called when the video ends
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}