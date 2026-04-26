using UnityEngine;

public class DisappearByStep : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private float disappearTime;

    private float currentDisappearTime;

    private bool disappear;

    private Color color;

    private void OnEnable()
    {
        disappear = false;
        color = sprite != null ? sprite.color: Color.white;
    }

    private void Update()
    {
        if(disappear)
        {
            currentDisappearTime -= Time.deltaTime;
            sprite.color = new Color(color.r, color.g, color.b, currentDisappearTime/disappearTime);
            if(currentDisappearTime <= 0)
                gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CommitDisappearing(other);
    }

    protected virtual void CommitDisappearing(Collider2D other)
    {
        currentDisappearTime = disappearTime;
        if (sprite == null)
            gameObject.SetActive(false);
        else
            disappear = true;
    }
}