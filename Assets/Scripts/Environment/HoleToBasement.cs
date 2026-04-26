using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleToBasement : MonoBehaviour
{
    [SerializeField]
    private GameObject holeMessage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        holeMessage.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        holeMessage.SetActive(false);
    }

    public void Descend()
    {
        SceneManager.LoadScene("Basement");
    }
}