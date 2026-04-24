using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EscManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput UIInputActions;
    private InputAction esc;

    [SerializeField]
    private GameObject escMessage, sleepMessage, speech;

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

    private void HandleEsc(InputAction.CallbackContext obj)
    {
        escMessage.SetActive(!escMessage.activeSelf && !sleepMessage.activeSelf && !speech.activeSelf);
        speech.SetActive(false);
        sleepMessage.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}