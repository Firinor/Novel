using FirUnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.Nand
{
    public class NandOperator : MonoBehaviour,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private enum NandState { Normal, Loop, Refresh }
        private NandState _state = NandState.Normal;

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
        private bool? outSignal = true;

        private Vector3 startMousePosition;

        private void Awake()
        {
            signalOutput.SetSignal(true);
        }

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

            signalInputA.NandOperator = this;
            signalInputB.NandOperator = this;
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

            signalInputA.OnMoveAction();
            signalInputB.OnMoveAction();
            signalOutput.OnMove();
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
                signalOutput.OnRemove();
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

        public void CalculateSignal()
        {
            bool? signalA = signalInputA.GetSignal();
            bool? signalB = signalInputB.GetSignal();

            bool? newOutSignal;
            if (signalA == null || signalB == null)
                newOutSignal = null;
            else
                newOutSignal = !(signalA.Value && signalB.Value);

            if(newOutSignal != outSignal)
            {
                if (outSignal == null && _state != NandState.Refresh)
                {
                    return;
                }
                if (_state == NandState.Loop)
                {
                    newOutSignal = null;
                }
                //recursion begin
                if(_state == NandState.Refresh)
                {
                    signalOutput.ResetAction();
                }

                _state = NandState.Loop;

                outSignal = newOutSignal;
                signalOutput.SetSignal(newOutSignal);
                //recursion end
            }
            _state = NandState.Normal;
        }

        public void ResetSignal()
        {
            _state = NandState.Refresh;
            outSignal = true;
            signalOutput.SetSignal(outSignal);
        }
    }
}
