using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ReturnToMainMenu : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer.loopPointReached += ChangeScene;
    }

    private void OnDestroy()
    {
        videoPlayer.loopPointReached -= ChangeScene;
    }

    private void ChangeScene(VideoPlayer source)
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}