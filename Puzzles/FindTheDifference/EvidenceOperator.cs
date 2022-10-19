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
        private DetectiveDeskOperator detectiveDeskOperator;
        [SerializeField]
        private FindDifferencesOperator findDifferencesOperator;
        [SerializeField]
        private CursorOnEvidence cursorOnEvidence;
        [SerializeField]
        private RectTransform fullScreenRectTransform;
        [SerializeField]
        private RectTransform detectiveDeskRectTransform;
        private Vector2 startOfImage;

        public void CalculateStartOfImage()
        {
            Rect fullScreenRect = fullScreenRectTransform.rect;
            Vector2 deskRest = detectiveDeskRectTransform.anchoredPosition;
            Vector2 evidenceRect = GetComponent<RectTransform>().offsetMin;
            startOfImage = new Vector2(-fullScreenRect.x + deskRest.x + evidenceRect.x,
                                    -fullScreenRect.y + deskRest.y +evidenceRect.y);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            cursorOnImage = true;
            Cursor.visible = false;
            findDifferencesOperator.SetCursorOnEvidence(cursorOnEvidence);
            findDifferencesOperator.EnableCursors();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            cursorOnImage = false;
            Cursor.visible = true;
            findDifferencesOperator.DisableCursors();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            findDifferencesOperator.CheckTheEvidence(eventData.position - startOfImage);
        }
    }
}
