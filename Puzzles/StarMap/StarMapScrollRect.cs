using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarMapScrollRect : ScrollRect, IPointerDownHandler, IPointerUpHandler
{
    private GlassBallViewOperator glassBallViewOperator;
    private Vector2 clickPoint;

    public void SetGlassBallViewOperator(GlassBallViewOperator glassBallViewOperator)
    {
        this.glassBallViewOperator = glassBallViewOperator;
    }

    public override void OnScroll(PointerEventData data)
    {
        glassBallViewOperator.ZoomScroll(Input.mouseScrollDelta);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == 0)
        {
            glassBallViewOperator.StartClick();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (glassBallViewOperator.EndClickOnStartClick())
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(glassBallViewOperator.GetRectTransform(),
                eventData.position, eventData.pressEventCamera, out var localPoint);
            glassBallViewOperator.SetCursorPosition(localPoint);
        }

    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && IsActive())
        {
            glassBallViewOperator.ResetClick();
            base.OnBeginDrag(eventData);
        }
    }
}
