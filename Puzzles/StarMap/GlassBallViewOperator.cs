using FirUnityEditor;
using Puzzle.StarMap;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GlassBallViewOperator : MonoBehaviour
{
    [SerializeField]
    private float scrollStep = 0.15f;
    [SerializeField, NullCheck]
    private Slider slider;
    [SerializeField, NullCheck]
    private StarMapInGlassBallOperator starMapInGlassBallOperator;
    [SerializeField, NullCheck]
    private StarMapScrollRect starMapScrollRect;
    [SerializeField, NullCheck]
    private StarMapOperator starMapOperator;

    private Vector2 mousePoint;
    [SerializeField]
    private int maxMouseDisplacement;

    void Awake()
    {
        starMapScrollRect.SetGlassBallViewOperator(this);
    }

    public void ZoomScroll(Vector2 mouseScrollDelta)
    {
        slider.value += scrollStep * (mouseScrollDelta.y > 0 ? 1 : -1);
        slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue);
    }

    public void SliderZoom()
    {
        starMapInGlassBallOperator.SetImageScale(slider.value);
    }

    public RectTransform GetRectTransform()
    {
        return starMapInGlassBallOperator.GetRectTransform();
    }

    public void SetCursorPosition(Vector2 localPoint)
    {
        starMapInGlassBallOperator.SetCursorPosition(localPoint);
        starMapOperator.SetButtonActivity();
    }

    public void StartClick()
    {
        mousePoint = Input.mousePosition;
    }
    public bool EndClickOnStartClick()
    {
        Vector2 currentMousePosition = Input.mousePosition;
        bool result = math.abs(mousePoint.x - currentMousePosition.x) < maxMouseDisplacement
            && math.abs(mousePoint.y - currentMousePosition.y) < maxMouseDisplacement;

        ResetClick();

        return result;
    }
    public void ResetClick()
    {
        mousePoint = new Vector2(-1, -1);
    }
}
