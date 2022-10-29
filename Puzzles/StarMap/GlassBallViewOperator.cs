using FirUnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
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
}
