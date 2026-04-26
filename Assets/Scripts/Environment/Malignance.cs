using System;
using UnityEngine;

public class Malignance : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private ItemType instrumentToWorkThis;
    
    [SerializeField]
    private float defaultWorkTime;

    protected float workTime;

    protected PlayerControls player;
    private static readonly int Glow = Animator.StringToHash("Glow");
    
    public static event Action OnUprooted = delegate { };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Uprooted) return;
        player = other.GetComponent<PlayerControls>();
        if (player != null)
        {
            animator.SetBool(Glow, true);
            player.IncludeWorkTile(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerControls>().Equals(player))
        {
            animator.SetBool(Glow, false);
            player.ExcludeWorkTile(this);
        }
    }

    public void Reset()
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        workTime = defaultWorkTime;
        SetTransparency();
    }

    private void SetTransparency()
    {
        sprite.color = new Color(1f, 1f, 1f, workTime/defaultWorkTime);
    }

    public void UpdateWork(float workProgress)
    {
        workTime -= workProgress;
        if (workTime <= 0f) 
        {
            workTime = 0f;
            player.ExcludeWorkTile(this);
            FinishWork();
        }
        SetTransparency();
    }

    protected virtual void FinishWork()
    {
        OnUprooted?.Invoke();
    }

    public bool Uprooted => sprite.color.a <= 0;

    public ItemType InstrumentToWorkThis => instrumentToWorkThis;
}