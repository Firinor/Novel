using FirUnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Puzzle.Nand
{
    public class LineFieldOperator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, NullCheck]
        private NandManager nandManager;
        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("RecipeOperator pointer enter");
            nandManager.PointerOnField = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("RecipeOperator pointer exit");
            nandManager.PointerOnField = false;
        }
    }
}
