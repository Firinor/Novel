using FirMath;
using FirUnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.SearchObjects
{
    public class DetectiveDeskOperator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private SearchObjectsOperator searchObjectsOperator;

        [SerializeField, NullCheck]
        private Image startImage;
        [SerializeField, NullCheck]
        private TextMeshProUGUI textMeshProUGUI;
        [SerializeField, NullCheck]
        private RectTransform rectTransform;

        [SerializeField]
        private Dictionary<GameObject, Rect> differences;

        [SerializeField, NullCheck]
        private Button button;

        [SerializeField, NullCheck]
        private Image puzzleImage;
        [SerializeField, NullCheck]
        private EvidenceOperator evidenceOperator;

        [SerializeField]
        private float differenceShowingTime = 4;

        [SerializeField]
        private float screenWidthOffset = 200;//pixels
        [SerializeField]
        private float screenHeightOffset = 300;//pixels

        public void DisableButton()
        {
            ButtonStatus(false);

        }
        public void EndOfAnimation()
        {
            EnableButton();
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
        internal void CreateImage(ImageWithDifferences imageWithDifferences,
            List<int> trashObjects, List<int> desiredObjects, GameObject searchObjectsPrefab)
        {
            differences = new Dictionary<GameObject, Rect>();

            Sprite mainSprite = imageWithDifferences.Sprite;

            float canvas_x = Screen.width - screenWidthOffset;
            float canvas_y = Screen.height - screenHeightOffset;

            float image_x = mainSprite.textureRect.width;
            float image_y = mainSprite.textureRect.height;

            float ratio_x = canvas_x / image_x;
            float ratio_y = canvas_y / image_y;

            float scaleRatio = Math.Min(ratio_x, ratio_y);

            WorkToImage(puzzleImage, mainSprite, scaleRatio);

            evidenceOperator.enabled = true;
            evidenceOperator.CalculateStartOfImage();

            foreach (var difference in desiredObjects)
            {
                Transform parent = puzzleImage.transform;
                GameObject newDifference = Instantiate(searchObjectsPrefab, parent);

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
            puzzleImage.enabled = false;
            evidenceOperator.enabled = false;
        }
        public void DisableImages()
        {
            evidenceOperator.DisableImage();
        }

        internal void CheckTheEvidence(Vector2 pointOnImage)
        {
            if (!enabled)
                return;

            foreach(KeyValuePair<GameObject, Rect> difference in differences)
            {
                if (difference.Value.Contains(pointOnImage))
                {
                    StartCoroutine(ButtonAnimation(difference));
                    searchObjectsOperator.ActivateDifference(difference.Key);
                    differences.Remove(difference.Key);
                    return;
                }
            }

            searchObjectsOperator.ErrorParticles();
        }

        public void DeleteAllDifference()
        {
            if (differences != null)
            {
                foreach (KeyValuePair<GameObject, Rect> difference in differences)
                    Destroy(difference.Key);

                differences.Clear();
            }

            DeleteAllChild(puzzleImage);
        }

        private void DeleteAllChild(Image image)
        {
            Transform transform = image.transform;
            int i = transform.childCount;
            while (i > 0)
            {
                i--;
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        private IEnumerator ButtonAnimation(KeyValuePair<GameObject, Rect> difference)
        {
            float deltaTime = 0.4f;
            WaitForSeconds wait = new WaitForSeconds(deltaTime);
            float timer = 0;

            while (timer < differenceShowingTime)
            {
                yield return wait;
                timer += deltaTime;
                difference.Key.SetActive(true);
                yield return wait;
                timer += deltaTime;
                difference.Key.SetActive(false);
            }
            Destroy(difference.Key);
        }
    }
}
