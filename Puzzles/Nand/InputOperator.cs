using FirUnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Nand
{
    public class InputOperator : MonoBehaviour,
        IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, NullCheck]
        private LineFieldOperator fieldOperator;

        public void OnPointerEnter(PointerEventData eventData)
        {
            fieldOperator.pickedInput = this;
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            fieldOperator.pickedInput = null;
        }
    }
}
