using System;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField]
    private GameObject message;
    
    public event Action OnSleep = delegate { };
    private void OnTriggerEnter2D(Collider2D other)
    {
        //message.SetActive(true);
        Sleep();
    }

    public void Sleep()
    {
        OnSleep?.Invoke();
    }

}