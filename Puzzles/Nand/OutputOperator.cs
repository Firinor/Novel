using FirUnityEditor;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Nand
{
    [RequireComponent(typeof(LineRenderer))]
    public class OutputOperator : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField, NullCheck]
        private LineRenderer line;
        [SerializeField, NullCheck]
        private RectTransform fullScreenTransform;

        private Vector2 mousePosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            line.positionCount = 2;
            line.SetPosition(0, Vector3.zero);
            Vector2 rectPosition = Camera.main.WorldToScreenPoint(transform.position);
            mousePosition = eventData.position - (eventData.position - rectPosition);
        }

        public void OnDrag(PointerEventData eventData)
        {
            line.SetPosition(1, eventData.position - mousePosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            line.positionCount = 0;
        }
    }
}
