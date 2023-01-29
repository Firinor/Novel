using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.Nand
{
    public class NandOperator : MonoBehaviour,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private Image imageInputA;
        [SerializeField]
        private Image imageInputB;
        [SerializeField]
        private Image imageOutput;
        [SerializeField]
        private GameObject dragAndDropObject;
        [SerializeField]
        private NandManager nandManager;

        private bool drag = false;

        private Vector3 startMousePosition;

        public void Start()
        {
            if (dragAndDropObject == null)
                dragAndDropObject = gameObject;
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
            else if(!nandManager.PointerOnField)
            {
                Destroy(gameObject);
            }
        }
        private void SetRayCastActivity(bool v)
        {
            image.raycastTarget = v;
            imageInputA.raycastTarget = v;
            imageInputB.raycastTarget = v;
            imageOutput.raycastTarget = v;
        }
    }
}
