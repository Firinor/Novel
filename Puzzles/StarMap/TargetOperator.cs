using FirUnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.StarMap
{
    public class TargetOperator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private Button button;
        [SerializeField, NullCheck]
        private StarMapOperator starMapOperator;
        [SerializeField, NullCheck]
        private Image keyImage;
        [SerializeField, NullCheck]
        private TextMeshProUGUI keyText;

        public void CheckAnswer()
        {
            SetButtonActivity(false);
            starMapOperator.CheckAnswer();
        }

        public void SetButtonActivity(bool v)
        {
            button.gameObject.SetActive(v);
        }

        public void SetAnswerKey(Sprite sprite)
        {
            keyImage.sprite = sprite;
            keyText.text = sprite.name;
        }
    }
}