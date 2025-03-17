using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayIntroVideoAndTransition : MonoBehaviour
{
    public VideoPlayer videoPlayer; // The Video Player component
    public Button continueButton;   // The Continue Button
    public string mainMenuSceneName = "MainMenu"; // Name of the Main Menu scene

    void Start()
    {
        // Disable auto-play on awake (we'll trigger play via the button)
        videoPlayer.playOnAwake = false;

        // Set button listener to trigger video play
        continueButton.onClick.AddListener(OnContinueButtonClicked);

        // Add a listener to transition to the Main Menu when the video finishes
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // This function will play the video when the Continue Button is clicked
    void OnContinueButtonClicked()
    {
        videoPlayer.Play();
    }

    // This function is called when the video finishes
    void OnVideoFinished(VideoPlayer vp)
    {
        // Load the Main Menu scene when the video ends
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
