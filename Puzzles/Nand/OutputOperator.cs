using FirMath;
using FirUnityEditor;
using PlasticGui.Configuration.CloudEdition.Welcome;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.Nand
{
    [RequireComponent(typeof(LineRenderer))]
    public class OutputOperator : MonoBehaviour,
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

        private InputOperator pickedInput;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(pickedInput != null)
            {
                pickedInput.OnChangeValue -= LineColorBySignal;
            }
            pickedInput = null;
            line.positionCount = 2;
            Vector3 zeroPoint = new Vector3(0, -rectTransform.rect.height / 2, 0);
            line.SetPosition(0, zeroPoint);
            LineColorBySignal();
            basePosition = GameTransform.GetGlobalPoint(transform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            line.SetPosition(1, ((Vector2)Input.mousePosition - basePosition) / CanvasManager.ScaleFactor);
            Debug.Log(basePosition);
            Debug.Log(eventData.position);
            Debug.Log(((Vector2)Input.mousePosition - basePosition) / CanvasManager.ScaleFactor);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(fieldOperator.pickedInput == null)
            {
                line.positionCount = 0;
                return;
            }

            pickedInput = fieldOperator.pickedInput;


            line.SetPosition(1, (((Vector2)GameTransform.GetGlobalPoint(pickedInput.transform) - basePosition)
                / CanvasManager.ScaleFactor) + (Vector2)pickedInput.GetConnectPoint());
            LineColorBySignal();
            pickedInput.OnChangeValue += LineColorBySignal;
        }

        private void LineColorBySignal()
        {
            Color color;
            if (pickedInput != null && pickedInput.Signal)
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
            if (pickedInput != null)
            {
                signal = pickedInput.Signal;
            }
            image.sprite = nandInformator.GetSignalSprite(signal);
        }
    }
}
