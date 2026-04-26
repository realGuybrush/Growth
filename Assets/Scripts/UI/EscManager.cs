using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EscManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput UIInputActions;
    private InputAction esc;

    [SerializeField]
    private GameObject escMessage;

    [SerializeField]
    private List<GameObject> otherMessages = new List<GameObject>();

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
        bool activate = !escMessage.activeSelf;
        if(otherMessages != null)
            foreach (var message in otherMessages)
            {
                activate &= !message.activeSelf;
                message.SetActive(false);
            }
        escMessage.SetActive(activate);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}