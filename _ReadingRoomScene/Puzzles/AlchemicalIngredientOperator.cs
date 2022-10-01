using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Unity.Mathematics;

public class AlchemicalIngredientOperator : MonoBehaviour, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private float frictionBraking;
    [SerializeField]
    private float border;
    [SerializeField]
    private Image image;

    private bool dragCard = false;

    private Vector3 impulse;
    private Vector3 lastPosition;
    private bool ingredientDrag;
    private int screenHeight;
    private int screenWidth;

    private static Vector3 adjustment;
    private static bool adjustmentBool = true;

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

        screenHeight = Screen.height/2;
        screenWidth = Screen.width/2;
        if (adjustmentBool)
        {
            adjustment = new Vector3(screenWidth, screenHeight, 0);
            adjustmentBool = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ingredientDrag = true;
        lastPosition = Input.mousePosition - adjustment;
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
            Vector3 pos = Input.mousePosition - adjustment;
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
        return pos.x < -screenWidth || pos.x > screenWidth || pos.y < -screenHeight || pos.y > screenHeight;
    }
    private void BackToScreen()
    {
        if (transform.localPosition.x < -screenWidth)
        {
            transform.localPosition = new Vector3(-screenWidth, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x > screenWidth)
        {
            transform.localPosition = new Vector3(screenWidth, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.y < -screenHeight)
        {
            transform.localPosition = new Vector3( transform.localPosition.x, -screenHeight, transform.localPosition.z);
        }
        if (transform.localPosition.y > screenHeight)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, screenHeight, transform.localPosition.z);
        }
    }

    private void CheckScreenBorders(Vector3 pos)
    {
        float x = pos.x + impulse.x;
        if (x < -screenWidth || x > screenWidth)
        {
            impulse.x = -impulse.x;
        }
        float y = pos.y + impulse.y;
        if (y < -screenHeight || y > screenHeight)
        {
            impulse.y = -impulse.y;
        }
    }

    internal void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
        image.SetNativeSize();
    }

    internal void SetRandomImpulse(float forse)
    {
        float randomForce = Random.value * forse;
        float randomDirection = Random.value * 360 * Mathf.Deg2Rad;

        impulse = new Vector3(math.cos(randomDirection), math.sin(randomDirection), 0) * randomForce;
    }

    internal void SetRecipeSprite(Sprite sprite)
    {
        SetSprite(sprite);
        image.color = Color.black;
    }
}
