using FirUnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarMapInGlassBallOperator : MonoBehaviour
{
    [SerializeField, NullCheck]
    private GlassBallViewOperator glassBallViewOperator;
    [SerializeField, NullCheck]
    private RectTransform rectTransform;
    [SerializeField, NullCheck]
    private RectTransform cursorRectTransform;
    [SerializeField, NullCheck]
    private Image cursorImage;
    private Vector2 defaultSize;

    [SerializeField, NullCheck]
    private Image targetImage;

    void Awake()
    {
        defaultSize = rectTransform.sizeDelta;
    }

    public void SetImageScale(float value)
    {
        rectTransform.localScale = Vector3.one * value;
        cursorRectTransform.localScale = Vector3.one / value;
    }

    public RectTransform GetRectTransform()
    {
        return rectTransform;
    }

    public void SetCursorPosition(Vector2 point)
    {
        cursorRectTransform.anchoredPosition = point;
        if(!cursorImage.enabled)
            SetCursorActivity(true);
    }

    public void SetCursorActivity(bool v)
    {
        cursorImage.enabled = v;
    }

    public void SetTargetActivity(bool v)
    {
        targetImage.enabled = v;
    }

    public Vector2Int GetCursorPoint()
    {
        return new Vector2Int((int)(cursorRectTransform.anchoredPosition.x + defaultSize.x / 2),
                              (int)(cursorRectTransform.anchoredPosition.y + defaultSize.y / 2));
    }
}
