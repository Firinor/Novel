using FirUnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.StarMap
{
    public class HelpMapOperator : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] maps;
        [SerializeField, NullCheck]
        private Image image;
        [SerializeField, NullCheck]
        private RectTransform imageRectTransform;
        [SerializeField, NullCheck]
        private Slider slider;
        [SerializeField]
        private float scrollStep = 0.15f;
        [SerializeField, NullCheck]
        private HelpMapScrollRect helpMapScrollRect;

        public void SwitchMap(int i)
        {
            if (maps != null && maps.Length > i)
            {
                image.sprite = maps[i];
            }
        }

        void Awake()
        {
            helpMapScrollRect.SetGlassBallViewOperator(this);
        }

        public void ZoomScroll(Vector2 mouseScrollDelta)
        {
            slider.value += scrollStep * (mouseScrollDelta.y > 0 ? 1 : -1);
            slider.value = Mathf.Clamp(slider.value, slider.minValue, slider.maxValue);
        }

        public void SliderZoom()
        {
            imageRectTransform.localScale = Vector3.one * slider.value;
        }
    }
}
