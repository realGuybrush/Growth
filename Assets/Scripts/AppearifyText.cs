using UnityEngine;

public class AppearifyText : DisappearByStep
{
    [SerializeField]
    private string text;
    protected override void CommitDisappearing()
    {
        if(DisappearingText.Instance != null)
            DisappearingText.Instance.SetText(text);
        base.CommitDisappearing();
    }
}