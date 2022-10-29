using FirUnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarMapInGlassBallOperator : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouseOnImage;
    [SerializeField, NullCheck]
    private GlassBallViewOperator glassBallViewOperator;
    [SerializeField, NullCheck]
    private RectTransform rectTransform;
    private Vector2 defaultSize;

    void Awake()
    {
        defaultSize = rectTransform.sizeDelta;
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    mouseOnImage = true;
    //    Debug.Log("OnPointerEnter");
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    mouseOnImage = false;
    //    Debug.Log("OnPointerExit");
    //}

    //void Update()
    //{
    //    if (mouseOnImage)
    //    {
    //        Debug.Log(Input.mouseScrollDelta);
    //    }
    //        if (mouseOnImage && Input.mouseScrollDelta != Vector2.zero)
    //    {
    //        glassBallViewOperator.ZoomScroll(Input.mouseScrollDelta);
    //    }
    //}

    public void SetImageScale(float value)
    {
        rectTransform.sizeDelta = defaultSize * value;
    }
}
