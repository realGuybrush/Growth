using System.Collections.Generic;
using UnityEngine;

public class AppearifyByStep : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToAppear;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Equals("MC"))
            foreach(var obj in objectsToAppear)
                obj.SetActive(true);
    }
}