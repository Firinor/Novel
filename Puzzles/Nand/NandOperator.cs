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
        private OutputOperator signalOutput;
        [SerializeField, NullCheck]
        private InputOperator signalInputA;
        [SerializeField, NullCheck]
        private InputOperator signalInputB;
        [SerializeField, NullCheck]
        private NandManager nandManager;
        [SerializeField, NullCheck]
        private NandInformator nandInformator;
        [SerializeField, NullCheck]
        private LineFieldOperator fieldOperator;

        private bool drag = false;
        private bool loop—heck = false;

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
            signalOutput.NandInformator = nandInformator;
            signalInputA.NandInformator = nandInformator;
            signalInputB.NandInformator = nandInformator;
            fieldOperator = nandManager.LineFieldOperator;
            signalOutput.LineFieldOperator = fieldOperator;
            signalInputA.LineFieldOperator = fieldOperator;
            signalInputB.LineFieldOperator = fieldOperator;
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

            signalInputA.SetEndPoint();
            signalInputB.SetEndPoint();
            signalOutput.SetEndPoint();
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
                signalInputA.ResetLine();
                signalInputB.ResetLine();
                signalOutput.ResetLine();
                Destroy(gameObject);
            }
        }
        private void SetRayCastActivity(bool v)
        {
            image.raycastTarget = v;
            signalOutput.SetRaycastTarget(v);
            signalInputA.SetRaycastTarget(v);
            signalInputB.SetRaycastTarget(v);
        }

        public void SetSignal()
        {
            if (loop—heck)
            {
                return;
            }

            signalOutput.Signal = !(signalInputA.GetSignal() && signalInputB.GetSignal());
        }
    }
}
