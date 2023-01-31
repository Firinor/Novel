using FirMath;
using FirUnityEditor;
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
        private LineFieldOperator fieldOperator;

        private Vector2 mousePosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            line.positionCount = 2;
            line.SetPosition(0, Vector3.zero);
            mousePosition = GameTransform.GetGlobalPoint(transform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            line.SetPosition(1, eventData.position - mousePosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(fieldOperator.pickedInput == null)
            {
                line.positionCount = 0;
                return;
            }

            line.SetPosition(1, GameTransform.GetGlobalPoint(fieldOperator.pickedInput.transform) - mousePosition);
        }
    }
}
