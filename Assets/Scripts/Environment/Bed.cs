using System;
using System.Collections;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField]
    private GameObject message, bedBlocker, malCount;

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
        malCount.SetActive(true);
    }

    public void Sleep()
    {
        player.transform.position = transform.position;
        malCount.SetActive(false);
        StartCoroutine("SleepCoroutine");
        OnSleep?.Invoke();
    }

    private IEnumerator SleepCoroutine()
    {
        player.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(sleepTime);
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}