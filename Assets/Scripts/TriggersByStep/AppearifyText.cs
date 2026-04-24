using UnityEngine;

public class AppearifyText : DisappearByStep
{
    [SerializeField]
    private string text;
    protected override void CommitDisappearing()
    {
        if(DisappearingText.Instance != null)
            DisappearingText.Instance.CallTextBox(text);
        base.CommitDisappearing();
    }
}