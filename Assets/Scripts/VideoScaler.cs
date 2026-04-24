using UnityEngine;

public class VideoScaler : MonoBehaviour
{
    [SerializeField]
    private RectTransform panel;
    private void OnEnable()
    {
        panel.anchorMin = new Vector2(0.5f,0.5f);
        panel.anchorMax = new Vector2(0.5f,0.5f);
        float size = Mathf.Min(Screen.currentResolution.height, Screen.currentResolution.width);
        panel.sizeDelta = new Vector2(size, size);
    }

}