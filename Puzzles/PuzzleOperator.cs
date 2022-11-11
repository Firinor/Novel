using FirUnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Puzzle
{
    public class PuzzleOperator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        protected GameObject victoryButton;
        [SerializeField, NullCheck]
        protected GameObject failButton;
        [SerializeField, NullCheck]
        protected Image backgroundImage;

        public virtual void PuzzleExit()
        {
            backgroundImage.enabled = false;
            gameObject.SetActive(false);
        }
        public virtual void LosePuzzle()
        {
            failButton.SetActive(true);
        }
        public virtual void Options()
        {
            PuzzleManager.Options();
        }
        public virtual void ClearPuzzle()
        {
            victoryButton.SetActive(false);
            failButton.SetActive(false);
        }
        public virtual void StartPuzzle()
        {

        }

        public virtual void SuccessfullySolvePuzzle()
        {
            DeactivatePuzzle();
            victoryButton.SetActive(true);
        }

        protected virtual void DeactivatePuzzle()
        {
            
        }

        protected virtual void SetVictoryEvent(UnityAction victoryAction)
        {
            Button button = victoryButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(PuzzleExit);
            if(victoryAction != null)
                button.onClick.AddListener(victoryAction);
        }
        protected virtual void SetFailEvent(UnityAction failAction)
        {
            Button button = failButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(PuzzleExit);
            if (failAction != null)
                button.onClick.AddListener(failAction);
        }
        protected virtual void SetBackground(Sprite sprite)
        {
            backgroundImage.enabled = true;
            backgroundImage.sprite = sprite;
        }
    }
}