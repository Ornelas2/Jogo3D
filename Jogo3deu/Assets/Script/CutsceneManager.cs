using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer cutsceneVideo; // Assign your VideoPlayer component in the Inspector
    public float fadeOutDuration = 1.0f; // Duration for optional fade-out effect (adjust if needed)
    public CanvasGroup fadeCanvasGroup; // Assign the CanvasGroup for fading (optional)

    private void Start()
    {
        // Optionally add logic to handle pre-cutscene setup (e.g., audio)
        cutsceneVideo.Prepare(); // Prepare the video for playback
        cutsceneVideo.loopPointReached += OnVideoEnd; // Subscribe to the loopPointReached event
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(LoadDemoSceneAfterDelay());
    }

    private IEnumerator LoadDemoSceneAfterDelay()
    {
        // Optional fade-out effect
        if (fadeCanvasGroup != null)
        {
            float fadeAlpha = 0.0f;
            while (fadeAlpha < 1.0f)
            {
                fadeAlpha += Time.deltaTime / fadeOutDuration;
                fadeCanvasGroup.alpha = fadeAlpha;
                yield return null;
            }
        }

        yield return new WaitForSeconds(fadeOutDuration); // Wait for fade-out or delay
        SceneManager.LoadScene("Demo"); // Replace "Demo" with the actual scene name
    }

    private void OnDestroy()
    {
        cutsceneVideo.loopPointReached -= OnVideoEnd; // Unsubscribe from the event on destruction
    }
}