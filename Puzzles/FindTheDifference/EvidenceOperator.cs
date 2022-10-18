using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.FindDifferences
{
    [RequireComponent(typeof(Image))]
    public class EvidenceOperator : MonoBehaviour,
        IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public static bool cursorOnImage = false;

        [SerializeField]
        private FindDifferencesOperator findDifferencesOperator;
        [SerializeField]
        private CursorOnEvidence cursorOnEvidence;

        public void OnPointerEnter(PointerEventData eventData)
        {
            cursorOnImage = true;
            Cursor.visible = false;
            findDifferencesOperator.SetCursorOnEvidence(cursorOnEvidence);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            cursorOnImage = false;
            Cursor.visible = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}
