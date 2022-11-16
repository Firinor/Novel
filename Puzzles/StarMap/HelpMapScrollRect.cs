using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Puzzle.StarMap
{
    public class HelpMapScrollRect : ScrollRect
    {
        private HelpMapOperator helpMapOperator;

        public void SetGlassBallViewOperator(HelpMapOperator helpMapOperator)
        {
            this.helpMapOperator = helpMapOperator;
        }

        public override void OnScroll(PointerEventData data)
        {
            helpMapOperator.ZoomScroll(Input.mouseScrollDelta);
        }
    }
}