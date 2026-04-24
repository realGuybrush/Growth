using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject introCanvas, exitMessageWeb;
    
    [SerializeField]
    private VideoPlayer introPlayer;

    private void OnEnable()
    {
        introPlayer.loopPointReached += StartGame;
    }

    private void OnDisable()
    {
        introPlayer.loopPointReached -= StartGame;
    }

    public void NewGameVideo()
    {
        introCanvas.SetActive(true);
        introPlayer.Play();
    }

    private void StartGame(VideoPlayer source)
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
        #if UNITY_WEBGL
        exitMessageWeb.SetActive(true);
        #endif
    }
}