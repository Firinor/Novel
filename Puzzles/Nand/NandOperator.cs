using FirUnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.Nand
{
    public class NandOperator : MonoBehaviour,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField, NullCheck]
        private Image image;
        [SerializeField, NullCheck]
        private InputOperator signalInput;
        [SerializeField, NullCheck]
        private OutputOperator signalOutputA;
        [SerializeField, NullCheck]
        private OutputOperator signalOutputB;
        [SerializeField, NullCheck]
        private NandManager nandManager;
        [SerializeField, NullCheck]
        private NandInformator nandInformator;
        [SerializeField, NullCheck]
        private LineFieldOperator fieldOperator;

        private bool drag = false;

        private Vector3 startMousePosition;

        public void Update()
        {
            if (Input.GetMouseButtonDown(1) && drag)
            {
                drag = false;
            }
        }

        public void SetNandManager(NandManager nandManager)
        {
            this.nandManager = nandManager;
            nandInformator = nandManager.NandInformator;
            signalInput.NandInformator = nandInformator;
            signalOutputA.NandInformator = nandInformator;
            signalOutputB.NandInformator = nandInformator;
            fieldOperator = nandManager.LineFieldOperator;
            signalInput.LineFieldOperator = fieldOperator;
            signalOutputA.LineFieldOperator = fieldOperator;
            signalOutputB.LineFieldOperator = fieldOperator;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            SetRayCastActivity(false);
            startMousePosition = Input.mousePosition / CanvasManager.ScaleFactor - transform.localPosition;
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                drag = true;
            }
            else
            {
                eventData.pointerDrag = null;
            }
        }
        public void OnDrag(PointerEventData eventData)
        {
            if (drag && eventData.button == PointerEventData.InputButton.Left)
            {
                transform.localPosition
                    = Input.mousePosition / CanvasManager.ScaleFactor - startMousePosition;
            }
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            SetRayCastActivity(true);
            if (nandManager == null)
            {
                Destroy(gameObject);
            }
            else if (!nandManager.PointerOnField)
            {
                Destroy(gameObject);
            }
        }
        private void SetRayCastActivity(bool v)
        {
            image.raycastTarget = v;
            signalInput.SetRaycastTarget(v);
            signalOutputA.SetRaycastTarget(v);
            signalOutputB.SetRaycastTarget(v);
        }
    }
}
