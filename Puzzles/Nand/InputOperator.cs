using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Nand
{
    public class InputOperator : MonoBehaviour, IPointerClickHandler, IPointerUpHandler
    {
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick");
        }
        
        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("OnPointerUp");
        }
    }
}
