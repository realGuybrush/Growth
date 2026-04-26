using UnityEngine;

public class DisappearAndApperify : DisappearByStep
{
    [SerializeField]
    private GameObject nextObject;
    private void OnDisable()
    {
        if(nextObject != null)
            nextObject.SetActive(true);
    }
}