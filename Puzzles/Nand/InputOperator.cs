using FirMath;
using FirUnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.Nand
{
    [RequireComponent(typeof(LineRenderer))]
    public class InputOperator : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField, NullCheck]
        private RectTransform rectTransform;
        [SerializeField, NullCheck]
        private LineRenderer line;
        [SerializeField, NullCheck]
        private LineFieldOperator fieldOperator;
        public LineFieldOperator LineFieldOperator { set { fieldOperator = value; } }
        [SerializeField, NullCheck]
        private NandInformator nandInformator;
        public NandInformator NandInformator { set { nandInformator = value; } }
        [SerializeField, NullCheck]
        private Image image;

        private Vector2 basePosition;

        private OutputOperator pickedOutput;
        public bool GetSignal()
        {
            if(pickedOutput == null)
                return false;
            return pickedOutput.Signal;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            ResetLine();
            line.positionCount = 2;
            Vector3 zeroPoint = new Vector3(0, -rectTransform.rect.height / 2, 0);
            line.SetPosition(0, zeroPoint);
            LineColorBySignal();
            basePosition = GameTransform.GetGlobalPoint(transform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            line.SetPosition(1, ((Vector2)Input.mousePosition - basePosition) / CanvasManager.ScaleFactor);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (fieldOperator.pickedOutput == null)
            {
                ResetLine();
                return;
            }

            pickedOutput = fieldOperator.pickedOutput;
            SetEndPoint();
            LineColorBySignal();
            pickedOutput.OnChangeValue += LineColorBySignal;
            pickedOutput.OnMove += SetEndPoint;
            pickedOutput.OnRemove += ResetLine;
        }

        public void ResetLine()
        {
            line.positionCount = 0;
            if (pickedOutput != null)
            {
                pickedOutput.OnChangeValue -= LineColorBySignal;
                pickedOutput.OnMove -= SetEndPoint;
                pickedOutput.OnRemove -= ResetLine;
            }
            pickedOutput = null;
            LineColorBySignal();
        }

        public void SetEndPoint()
        {
            if (pickedOutput == null)
            {
                return;
            }
            line.SetPosition(1, (((Vector2)GameTransform.GetGlobalPoint(pickedOutput.transform)
                - (Vector2)GameTransform.GetGlobalPoint(transform))
                / CanvasManager.ScaleFactor) + (Vector2)pickedOutput.GetConnectPoint());
        }

        private void LineColorBySignal()
        {
            Color color;
            if (pickedOutput != null && pickedOutput.Signal)
            {
                color = nandInformator.OnColor;
            }
            else
            {
                color = nandInformator.OffColor;
            }
            line.startColor = color;
            line.endColor = color;
            RefreshSprite();
        }

        public void SetRaycastTarget(bool v)
        {
            image.raycastTarget = v;
        }

        private void RefreshSprite()
        {
            bool signal = false;
            if (pickedOutput != null)
            {
                signal = pickedOutput.Signal;
            }
            image.sprite = nandInformator.GetSignalSprite(signal);
        }
    }
}
