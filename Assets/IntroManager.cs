using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    // Google Drive shareable link converted to direct URL
    public string videoURL = "https://drive.google.com/uc?export=download&id=1K2p3srYPJFows_q4XxMD1lHbnGeWXWga";

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Set the source to URL
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = videoURL;

        // Register callback when the video finishes
        videoPlayer.loopPointReached += OnVideoEnd;

        // Prepare the video before playing
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnVideoPrepared;
    }

    // Called when the video is prepared (ready to play)
    void OnVideoPrepared(VideoPlayer vp)
    {
        vp.Play();
    }

    // Called when the video ends
    void OnVideoEnd(VideoPlayer vp)
    {
        // Load the MainMenu scene after the video ends
        SceneManager.LoadScene("MainMenu");
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        videoPlayer.loopPointReached -= OnVideoEnd;
        videoPlayer.prepareCompleted -= OnVideoPrepared;
    }
}
