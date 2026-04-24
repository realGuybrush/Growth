using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SkipCutsceneByEsc : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    
    [SerializeField]
    private PlayerInput UIInputActions;
    private InputAction esc;

    private void Awake()
    {
        esc = UIInputActions.actions.FindAction("Escape");
        if (esc == null) return;
        esc.Enable();
        esc.performed += HandleEsc;
    }

    private void OnDestroy()
    {
        if (esc == null) return;
        esc.performed -= HandleEsc;
        esc.Disable();
    }
    
    protected virtual void HandleEsc(InputAction.CallbackContext obj)
    {
        videoPlayer.playbackSpeed = 1000f;
    }

}