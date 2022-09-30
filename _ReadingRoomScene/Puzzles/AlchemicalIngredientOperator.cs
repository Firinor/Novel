using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

public class AlchemicalIngredientOperator : MonoBehaviour, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private float frictionBraking;
    [SerializeField]
    private float border;

    private bool dragCard = false;

    private Vector3 impulse;
    private Vector3 lastPosition;
    private bool ingredientDrag;
    private int screenHeight;
    private int screenWidth;

    private CompositeDisposable disposables = new CompositeDisposable();

    void Awake()
    {
       this.FixedUpdateAsObservable()
                .Where(_ => !ingredientDrag && impulse != Vector3.zero)
                .Subscribe(_ => ForseToIngredient())
                .AddTo(disposables);
        this.FixedUpdateAsObservable()
                .Where(_ => !ingredientDrag && CheckOutOfBounce(transform.localPosition))
                .Subscribe(_ => BackToScreen())
                .AddTo(disposables);

        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ingredientDrag = true;
        lastPosition = Input.mousePosition;
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
            lastPosition = transform.localPosition;
            transform.localPosition = pos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ingredientDrag = false;
        impulse = transform.localPosition - lastPosition;
        //Debug.Log(impulse + " " + impulse.x + " " + impulse.y);
    }

    private void ForseToIngredient()
    {
        Vector3 pos = transform.localPosition;
        CheckScreenBorders(pos);
        pos += impulse;

        impulse *= frictionBraking;
        if (Math.Abs(impulse.x) < border && Math.Abs(impulse.y) < border)
        {
            impulse = Vector3.zero;
        }

        CheckOutOfBounce(pos);

        transform.localPosition = pos;
    }

    private bool CheckOutOfBounce(Vector3 pos)
    {
        return pos.x < 0 || pos.x > screenWidth || pos.y < 0 || pos.y > screenHeight;
    }
    private void BackToScreen()
    {
        if (transform.localPosition.x < 0)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x > screenWidth)
        {
            transform.localPosition = new Vector3(screenWidth, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.y < 0)
        {
            transform.localPosition = new Vector3( transform.localPosition.x, 0, transform.localPosition.z);
        }
        if (transform.localPosition.y > screenHeight)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, screenHeight, transform.localPosition.z);
        }
    }

    private void CheckScreenBorders(Vector3 pos)
    {
        float x = pos.x + impulse.x;
        if (x < 0 || x > screenWidth)
        {
            impulse.x = -impulse.x;
        }
        float y = pos.y + impulse.y;
        if (y < 0 || y > screenHeight)
        {
            impulse.y = -impulse.y;
        }
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
