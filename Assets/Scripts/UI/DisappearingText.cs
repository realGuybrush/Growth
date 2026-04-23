using System.Collections;
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
    private Color defaultBGColor, defaultTextColor;

    private void Awake()
    {
        Instance = this;
        disappear = false;
        defaultTextColor = text.color;
        defaultBGColor = sprite.color;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        text.color = defaultTextColor;
        sprite.color = defaultBGColor;
        timeRemainedBeforeDisappear = disappearancePeriod;
        disappear = false;
        StartCoroutine("Exist");
    }

    private IEnumerator Exist()
    {
        yield return new WaitForSeconds(existencePeriod);
        disappear = true;
    }

    private void Update()
    {
        if(disappear)
        {
            float alpha = timeRemainedBeforeDisappear / disappearancePeriod;
            timeRemainedBeforeDisappear -= Time.deltaTime;
            text.color = new Color(defaultTextColor.r, defaultTextColor.g, defaultTextColor.b, alpha);
            sprite.color = new Color(defaultBGColor.r, defaultBGColor.g, defaultBGColor.b, alpha);
            if (timeRemainedBeforeDisappear <= 0)
                gameObject.SetActive(false);
        }
    }
    
    public void SetText(string newText)
    {
        text.text = newText;
        gameObject.SetActive(true);
    }
}