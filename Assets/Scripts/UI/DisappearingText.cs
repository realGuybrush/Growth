using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisappearingText : MonoBehaviour
{
    public static DisappearingText Instance;
    
    [SerializeField]
    private Image sprite;
    
    [SerializeField]
    private TextMeshProUGUI text;
    
    [SerializeField]
    private float disappearancePeriod, existencePeriod;

    private float timeRemainedBeforeDisappear;

    private bool disappear;
    private List<bool> disappearanceRequest= new List<bool>();
    private Color defaultBGColor, defaultTextColor;

    private void Awake()
    {
        Instance = this;
        defaultTextColor = text.color;
        defaultBGColor = sprite.color;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(disappear)
        {
            UpdateAlpha(timeRemainedBeforeDisappear / disappearancePeriod);
            timeRemainedBeforeDisappear -= Time.deltaTime;
            if (timeRemainedBeforeDisappear <= 0)
                gameObject.SetActive(false);
        }
    }

    private void UpdateAlpha(float alpha)
    {
        text.color = new Color(defaultTextColor.r, defaultTextColor.g, defaultTextColor.b, alpha);
        sprite.color = new Color(defaultBGColor.r, defaultBGColor.g, defaultBGColor.b, alpha);
    }

    public void CallTextBox(string newText)
    {
        text.text = newText;
        UpdateAlpha(1f);
        MakeSingularlyValidDisappearanceRequest();
        gameObject.SetActive(true);
        StartCoroutine("Exist", disappearanceRequest.Count-1);
    }

    private void MakeSingularlyValidDisappearanceRequest()
    {
        CancelPreviousRequests();
        TryClearList();
        disappearanceRequest.Add(true);
    }

    private void CancelPreviousRequests()
    {
        disappear = false;
        timeRemainedBeforeDisappear = disappearancePeriod;
        if(disappearanceRequest.Count > 0)
            disappearanceRequest[^1] = false;
    }

    private void TryClearList()
    {
        if(!disappearanceRequest.Select(req => req).Any())
            disappearanceRequest.Clear();
    }

    private IEnumerator Exist(int index)
    {
        yield return new WaitForSeconds(existencePeriod);
        if (disappearanceRequest[index])
        {
            disappear = true;
            disappearanceRequest[index] = false;
        }
    }
}