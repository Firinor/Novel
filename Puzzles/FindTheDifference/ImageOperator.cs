using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.FindDifferences
{
    public class ImageOperator : MonoBehaviour
    {
        [SerializeField]
        private Image startImage;
        [SerializeField]
        private TextMeshProUGUI textMeshProUGUI;
        [SerializeField]
        private RectTransform rectTransform;
        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private HorizontalLayoutGroup horizontalLayoutGroup;
        private int frontLayer = 4200;
        private int backLayer = 4100;

        private Button button;

        [SerializeField]
        private Image leftImage;
        [SerializeField]
        private Image rightImage;

        void Awake()
        {
            button = GetComponent<Button>();
        }
        internal bool ActivateDifference(int keyIngredientNumber)
        {
            return true;
        }

        public void DisableButton()
        {
            ButtonStatus(false);

        }

        public void EnableButton()
        {
            ButtonStatus(true); 
        }

        private void ButtonStatus(bool v)
        {
            textMeshProUGUI.enabled = v;
            canvas.sortingOrder = v ? frontLayer : backLayer;
            button.enabled = v;
        }

        public void CreateImages(ImageWithDifferences imageWithDifferences, GameObject differencePrefab, int offset)
        {
            horizontalLayoutGroup.spacing = offset;
            float canvas_x = rectTransform.rect.width - offset * 3;//left, center, right
            float canvas_y = rectTransform.rect.height - offset * 2;//top, bottom

            Sprite mainSprite = imageWithDifferences.Sprite;
            float image_x = mainSprite.textureRect.width;
            float image_y = mainSprite.textureRect.height;

            float ratio_x =  canvas_x / image_x;
            float ratio_y =  canvas_y / image_y;

            float scaleRatio = Math.Max(ratio_x, ratio_y);

            leftImage.enabled = true;
            leftImage.sprite = mainSprite;
            leftImage.SetNativeSize();
            leftImage.GetComponent<RectTransform>().sizeDelta *= scaleRatio;
            rightImage.enabled = true;
            rightImage.sprite = mainSprite;
            rightImage.SetNativeSize();
            rightImage.GetComponent<RectTransform>().sizeDelta *= scaleRatio;
        }

        public void ClearImages()
        {
            leftImage.enabled = false;
            rightImage.enabled = false;
        }
    }
}
