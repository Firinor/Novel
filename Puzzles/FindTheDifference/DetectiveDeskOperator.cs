using FirMath;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.FindDifferences
{
    public class DetectiveDeskOperator : MonoBehaviour
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

        private List<Rect> differencesRects;

        private Button button;

        [SerializeField]
        private Image leftImage;
        [SerializeField]
        private Image rightImage;
        private EvidenceOperator leftEvidenceOperator;
        private EvidenceOperator rightEvidenceOperator;

        void Awake()
        {
            button = GetComponent<Button>();
            leftEvidenceOperator = leftImage.GetComponent<EvidenceOperator>();
            rightEvidenceOperator = rightImage.GetComponent<EvidenceOperator>();
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

        public void CreateImages(ImageWithDifferences imageWithDifferences, int differenceCount,
            GameObject differencePrefab, int offset, out float imageOffset)
        {
            differencesRects = new List<Rect>();

            horizontalLayoutGroup.spacing = offset;
            float canvas_x = (rectTransform.rect.width - offset * 3) / 2;//left, center, right (2 images in a row)
            float canvas_y = rectTransform.rect.height - offset * 2;//top, bottom (1 image on collum)

            Sprite mainSprite = imageWithDifferences.Sprite;
            float image_x = mainSprite.textureRect.width;
            float image_y = mainSprite.textureRect.height;

            float ratio_x = canvas_x / image_x;
            float ratio_y = canvas_y / image_y;

            float scaleRatio = Math.Min(ratio_x, ratio_y);

            leftImage.enabled = true;
            leftImage.sprite = mainSprite;
            leftImage.SetNativeSize();
            leftImage.GetComponent<RectTransform>().sizeDelta *= scaleRatio;
            leftImage.GetComponent<RectTransform>().localPosition = new Vector3(-offset/2, 0);
            rightImage.enabled = true;
            rightImage.sprite = mainSprite;
            rightImage.SetNativeSize();
            rightImage.GetComponent<RectTransform>().sizeDelta *= scaleRatio;
            rightImage.GetComponent<RectTransform>().localPosition = new Vector3(offset / 2, 0);

            imageOffset = rightImage.GetComponent<RectTransform>().sizeDelta.x + offset;

            leftEvidenceOperator.enabled = true;
            rightEvidenceOperator.enabled = true;

            List<int> differences = GameMath.AFewCardsFromTheDeck(differenceCount, imageWithDifferences.Differences.Length);
            foreach (var difference in differences)
            {
                Transform parent = GameMath.HeadsOrTails() ? leftImage.transform : rightImage.transform;
                GameObject newDifference = Instantiate(differencePrefab, parent);

                var differenceComponent = imageWithDifferences.Differences[difference];

                Image differenceImage = newDifference.GetComponent<Image>();
                differenceImage.sprite = differenceComponent.sprite;
                differenceImage.SetNativeSize();

                RectTransform differenceRectTransform = newDifference.GetComponent<RectTransform>();
                differenceRectTransform.sizeDelta *= scaleRatio;
                differenceRectTransform.anchoredPosition =
                    new Vector2(differenceComponent.xShift * scaleRatio, differenceComponent.yShift * scaleRatio);

                differencesRects.Add(new Rect(differenceRectTransform.offsetMin, differenceRectTransform.sizeDelta));
            }
        }

        public void ClearImages()
        {
            leftImage.enabled = false;
            rightImage.enabled = false;
            leftEvidenceOperator.enabled = false;
            rightEvidenceOperator.enabled = false;
        }
    }
}
