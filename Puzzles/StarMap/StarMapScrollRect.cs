using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Codice.CM.WorkspaceServer.WorkspaceTreeDataStore;

namespace Puzzle.StarMap
{
    public class StarMapScrollRect : ScrollRect, IPointerDownHandler, IPointerUpHandler
    {
        private GlassBallViewOperator glassBallViewOperator;

        public void SetGlassBallViewOperator(GlassBallViewOperator glassBallViewOperator)
        {
            this.glassBallViewOperator = glassBallViewOperator;
        }

        public override void OnScroll(PointerEventData data)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(glassBallViewOperator.GetRectTransform(),
                    Input.mousePosition, data.pressEventCamera, out Vector2 pointBeforeScaling);
            float deltaScale = glassBallViewOperator.ZoomScroll(Input.mouseScrollDelta);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(glassBallViewOperator.GetRectTransform(),
                    Input.mousePosition, data.pressEventCamera, out Vector2 pointAfterScaling);
            Vector2 delta = pointBeforeScaling - pointAfterScaling;
            delta *= deltaScale;
            content.anchoredPosition -= delta;
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
                    eventData.position, eventData.pressEventCamera, out Vector2 localPoint);
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
}