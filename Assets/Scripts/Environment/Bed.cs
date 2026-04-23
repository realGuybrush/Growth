using System;
using System.Collections;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField]
    private GameObject message, bedBlocker;

    [SerializeField]
    private Rigidbody2D player;

    [SerializeField]
    private float sleepTime = 4f;
    
    public event Action OnSleep = delegate { };
    private void OnTriggerEnter2D(Collider2D other)
    {
        message.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        message.SetActive(false);
        bedBlocker.SetActive(true);
    }

    public void Sleep()
    {
        player.transform.position = transform.position;
        StartCoroutine("DisablePlayer");
        OnSleep?.Invoke();
    }

    private IEnumerator DisablePlayer()
    {
        player.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(sleepTime);
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}