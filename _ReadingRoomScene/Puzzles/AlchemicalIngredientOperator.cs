using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AlchemicalIngredientOperator : MonoBehaviour, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private bool dragCard = false;
    //private new Camera camera;

    //void Awake()
    //{
    //    camera = Camera.main;
    //}

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
            //if (hit.point )
            //Vector3 pos = hit.point;
            Vector3 pos = Input.mousePosition;
            //pos.z = 0;
            transform.localPosition = pos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    internal void SetSprite(Sprite sprite)
    {
        throw new NotImplementedException();
    }

    internal void SetWinEvent()
    {
        throw new NotImplementedException();
    }
}
