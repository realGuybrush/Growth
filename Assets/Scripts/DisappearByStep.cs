using System.Collections;
using UnityEngine;

public class DisappearByStep : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private float disappearTime;

    private float currentDisappearTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        CommitDisappearing();
    }

    protected virtual void CommitDisappearing()
    {
        currentDisappearTime = disappearTime;
        if (sprite == null)
            gameObject.SetActive(false);
        else
            StartCoroutine("Disappear");
    }

    private IEnumerator Disappear()
    {
        currentDisappearTime -= Time.deltaTime;
        sprite.color = new Color(1f, 1f, 1f, currentDisappearTime/disappearTime);
        yield return new WaitForSeconds(disappearTime);
        gameObject.SetActive(false);
    }
}