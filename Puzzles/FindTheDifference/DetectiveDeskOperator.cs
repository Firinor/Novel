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
        private FindDifferencesOperator findDifferencesOperator;

        [SerializeField]
        private Image startImage;
        [SerializeField]
        private TextMeshProUGUI textMeshProUGUI;
        [SerializeField]
        private RectTransform rectTransform;
        [SerializeField]
        private HorizontalLayoutGroup horizontalLayoutGroup;

        [SerializeField]
        private Dictionary<GameObject, Rect> differences;

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
            button.enabled = v;
        }

        public void CreateImages(ImageWithDifferences imageWithDifferences, int differenceCount,
            GameObject differencePrefab, int offset, out float imageOffset)
        {
            differences = new Dictionary<GameObject, Rect>();

            float canvas_x = (rectTransform.rect.width - offset * 3) / 2;//left, center, right (2 images in a row)
            float canvas_y = rectTransform.rect.height - offset * 2;//top, bottom (1 image on collum)

            Sprite mainSprite = imageWithDifferences.Sprite;
            float image_x = mainSprite.textureRect.width;
            float image_y = mainSprite.textureRect.height;

            float ratio_x = canvas_x / image_x;
            float ratio_y = canvas_y / image_y;

            float scaleRatio = Math.Min(ratio_x, ratio_y);
            WorkToImage(leftImage, mainSprite, scaleRatio);
            leftImage.GetComponent<RectTransform>().localPosition = new Vector3(-offset / 2, 0);
            WorkToImage(rightImage, mainSprite, scaleRatio);
            rightImage.GetComponent<RectTransform>().localPosition = new Vector3(offset / 2, 0);

            imageOffset = rightImage.GetComponent<RectTransform>().sizeDelta.x + offset;

            leftEvidenceOperator.enabled = true;
            leftEvidenceOperator.CalculateStartOfImage();
            rightEvidenceOperator.enabled = true;
            rightEvidenceOperator.CalculateStartOfImage();

            List<int> differencesIntList = GameMath.AFewCardsFromTheDeck(differenceCount, imageWithDifferences.Differences.Length);
            foreach (var difference in differencesIntList)
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

                differences.Add(newDifference,
                    new Rect(differenceRectTransform.offsetMin, differenceRectTransform.sizeDelta));
            }
        }

        private void WorkToImage(Image image, Sprite sprite, float scaleRatio)
        {
            image.enabled = true;
            image.sprite = sprite;
            image.SetNativeSize();
            image.GetComponent<RectTransform>().sizeDelta *= scaleRatio;
        }

        public void ClearImages()
        {
            leftImage.enabled = false;
            rightImage.enabled = false;
            leftEvidenceOperator.enabled = false;
            rightEvidenceOperator.enabled = false;
        }

        internal void CheckTheEvidence(Vector2 pointOnImage, CursorOnEvidence cursorOnEvidence)
        {
            foreach(KeyValuePair<GameObject, Rect> difference in differences)
            {
                if (difference.Value.Contains(pointOnImage))
                {
                    findDifferencesOperator.ActivateDifference(difference.Key, cursorOnEvidence);
                    differences.Remove(difference.Key);
                    return;
                }
            }

            findDifferencesOperator.ErrorShake(cursorOnEvidence);
        }

        public void DeleteAllDifference()
        {
            if (differences != null)
            {
                foreach (KeyValuePair<GameObject, Rect> difference in differences)
                    Destroy(difference.Key);

                differences.Clear();
            }
        }
    }
}
