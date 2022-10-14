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
        private Canvas canvas;
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

        public void CreateImages(ImageWithDifferences imageWithDifferences, GameObject differencePrefab)
        {
            //var i = startImage.rootCanvasRect.size;
        }

        public void ClearImages()
        {
            leftImage.enabled = false;
            rightImage.enabled = false;
        }
    }
}
