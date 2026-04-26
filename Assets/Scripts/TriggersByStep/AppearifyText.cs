using UnityEngine;

public class AppearifyText : DisappearByStep
{
    [SerializeField]
    private string text;
    protected override void CommitDisappearing(Collider2D other)
    {
        if(DisappearingText.Instance != null)
            DisappearingText.Instance.CallTextBox(text);
        base.CommitDisappearing(other);
    }
}