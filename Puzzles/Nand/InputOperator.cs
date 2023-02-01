using FirUnityEditor;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.Nand
{
    [RequireComponent(typeof(Image))]
    public class InputOperator : MonoBehaviour,
        IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private bool interactive;
        [SerializeField]
        private bool signal;
        public bool Signal { get { return signal; } }
        [Space(15)]
        [SerializeField, NullCheck]
        private RectTransform rectTransform;
        [SerializeField, NullCheck]
        private LineFieldOperator fieldOperator;
        public LineFieldOperator LineFieldOperator { set { fieldOperator = value; } }
        [SerializeField, NullCheck]
        private NandInformator nandInformator;
        public NandInformator NandInformator { set { nandInformator = value; } }
        
        [SerializeField, NullCheck]
        private Image image;

        public event Action OnChangeValue;

        void Awake()
        {
            signal = false;
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }

        private void RefreshSprite()
        {
            image.sprite = nandInformator.GetSignalSprite(signal);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (interactive)
                SwitchSignal();
        }

        private void SwitchSignal()
        {
            signal = !signal;
            RefreshSprite();
            OnChangeValue?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            fieldOperator.pickedInput = this;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            fieldOperator.pickedInput = null;
        }

        public void SetRaycastTarget(bool v)
        {
            image.raycastTarget = v;
        }

        public Vector3 GetConnectPoint()
        {
            return new Vector3(0, rectTransform.rect.height / 2, 0);
        }
    }
}
