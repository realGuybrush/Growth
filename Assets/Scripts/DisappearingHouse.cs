using UnityEngine;

public class DisappearingHouse : MonoBehaviour
{
    [SerializeField]
    private GameObject house;
    private void OnTriggerEnter2D(Collider2D other)
    {
        house.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        house.SetActive(true);
    }
}
