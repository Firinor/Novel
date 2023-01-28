using UnityEngine;
using UnityEngine.EventSystems;

namespace FirDragAndDrop
{
    public class CardDragAndDropOperator : MonoBehaviour,
        IBeginDragHandler, IDragHandler, IEndDragHandler,
        IPointerEnterHandler, IPointerExitHandler
    {
        private new Camera camera;

        [SerializeField]
        private static float maxRayDistance = 100f;
        [SerializeField]
        private LayerMask GroundLayerMask;
        [SerializeField]
        private GameObject dragAndDropObject;

        private bool dragCard = false;
        private bool cursorOnCard = false;

        public void Start()
        {
            camera = Camera.main;
            if(dragAndDropObject == null)
                dragAndDropObject = gameObject;
        }
        public void Update()
        {
            if (Input.GetMouseButtonDown(1) && dragCard)
            {
                dragCard = false;
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                dragCard = true;
            }
            else
            {
                eventData.pointerDrag = null;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (dragCard && eventData.button == PointerEventData.InputButton.Left)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out RaycastHit hit, maxRayDistance, GroundLayerMask);

                Vector3 pos = hit.point;
                dragAndDropObject.transform.localPosition = pos;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            cursorOnCard = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            cursorOnCard = false;
        }
    }
}
