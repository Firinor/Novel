using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarMapScrollRect : ScrollRect
{
    private GlassBallViewOperator glassBallViewOperator;

    public void SetGlassBallViewOperator(GlassBallViewOperator glassBallViewOperator)
    {
        this.glassBallViewOperator = glassBallViewOperator;
    }

    public override void OnScroll(PointerEventData data)
    {
        glassBallViewOperator.ZoomScroll(Input.mouseScrollDelta);
    }
}
