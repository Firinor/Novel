using UnityEngine;

public enum CursorOnEvidence { left = -1, right = 1 }

namespace Puzzle.FindDifferences
{
    public class DoubleCursorOperator : MonoBehaviour
    {
        [SerializeField]
        private Transform leftCursor;
        [SerializeField]
        private Transform rightCursor;

        private float offset;

        [HideInInspector]
        public CursorOnEvidence cursorOnEvidence;

        public void MoveCursor()
        {
            switch (cursorOnEvidence)
            {
                case CursorOnEvidence.left:
                    leftCursor.localPosition = Input.mousePosition;
                    rightCursor.localPosition = Input.mousePosition + new Vector3(offset, 0, 0);
                    break;
                case CursorOnEvidence.right:
                    rightCursor.localPosition = Input.mousePosition;
                    leftCursor.localPosition = Input.mousePosition - new Vector3(offset, 0, 0);
                    break;
            }
        }

        public void SetOffset(float offset)
        {
            this.offset = offset;
        }
    }
}
