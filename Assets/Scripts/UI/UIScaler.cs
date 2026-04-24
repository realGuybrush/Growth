using System;
using UnityEngine;

public class UIScaler : MonoBehaviour
{
    [SerializeField]
    private RectTransform rect;

    [SerializeField]
    private Vector2 portionOfSize;

    [SerializeField]
    private Vector2 positionBySize;
    private void OnEnable()
    {
        #if !UNITY_EDITOR
        rect.sizeDelta = new Vector2(Screen.currentResolution.width*portionOfSize.x, Screen.currentResolution.height*portionOfSize.y);
        rect.anchoredPosition = new Vector2(Screen.currentResolution.width * positionBySize.x, Screen.currentResolution.height * positionBySize.y);
        #endif
    }
}