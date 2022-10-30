using FirUnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarMapInGlassBallOperator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private GlassBallViewOperator glassBallViewOperator;
    [SerializeField, NullCheck]
    private RectTransform rectTransform;
    [SerializeField, NullCheck]
    private RectTransform cursorRectTransform;
    private Vector2 defaultSize;

    void Awake()
    {
        defaultSize = rectTransform.sizeDelta;
    }

    public void SetImageScale(float value)
    {
        rectTransform.sizeDelta = defaultSize * value;
    }

    public RectTransform GetRectTransform()
    {
        return rectTransform;
    }

    public void SetCursorPosition(Vector2 point)
    {
        cursorRectTransform.anchoredPosition = point;
    }
}
