using FirUnityEditor;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Puzzle
{
    public abstract class PuzzleOperator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        protected AllPuzzleInformator allPuzzleInformator;
        protected Image background;

        [SerializeField]
        protected float leftTime = 120;
        protected bool theTimerIsRunning;

        protected virtual void Awake()
        {
            allPuzzleInformator = AllPuzzleInformator.instance;
            background = BackgroundHUB.Image.GetValue();
        }

        protected virtual void OnEnable()
        {
            allPuzzleInformator.HelpButtons.SetActive(true);
            allPuzzleInformator.ExitButton.onClick.RemoveAllListeners();
            allPuzzleInformator.ExitButton.onClick.AddListener(PuzzleExit);
            allPuzzleInformator.OptionsButton.onClick.RemoveAllListeners();
            allPuzzleInformator.OptionsButton.onClick.AddListener(Options);
            ResetTimer();
        }
        public virtual void PuzzleExit()
        {
            DeactivaButtons();
            background.enabled = false;
            gameObject.SetActive(false);
            allPuzzleInformator.HelpButtons.SetActive(false);
        }
        public virtual void LosePuzzle()
        {
            allPuzzleInformator.FailButton.SetActive(true);
        }
        public virtual void Options()
        {
            PuzzleManager.Options();
        }
        public virtual void ClearPuzzle()
        {
            DeactivaButtons();
            allPuzzleInformator.TimerText.enabled = false;
        }

        private void DeactivaButtons()
        {
            allPuzzleInformator.VictoryButton.SetActive(false);
            allPuzzleInformator.FailButton.SetActive(false);
        }
        public virtual void StartPuzzle()
        {

        }

        public virtual void SuccessfullySolvePuzzle()
        {
            DeactivatePuzzle();
            allPuzzleInformator.VictoryButton.SetActive(true);
        }

        protected virtual void DeactivatePuzzle()
        {
            
        }

        protected virtual void SetVictoryEvent(UnityAction victoryAction)
        {
            Button button = allPuzzleInformator.VictoryButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(PuzzleExit);
            if(victoryAction != null)
                button.onClick.AddListener(victoryAction);
        }
        protected virtual void SetFailEvent(UnityAction failAction)
        {
            Button button = allPuzzleInformator.FailButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(PuzzleExit);
            if (failAction != null)
                button.onClick.AddListener(failAction);
        }
        protected virtual void SetBackground(Sprite sprite)
        {
            background.enabled = true;
            background.sprite = sprite;
        }

        protected virtual void TimerTick()
        {
            leftTime -= Time.deltaTime;
            TextLeftTime();
            if (leftTime <= 0)
            {
                theTimerIsRunning = false;
                LosePuzzle();
            }
        }

        protected virtual void TextLeftTime()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(leftTime);
            DateTime dateTime = new DateTime(1, 1, 1, 0, timeSpan.Minutes, timeSpan.Seconds);
            allPuzzleInformator.TimerText.text = $"{dateTime:m:ss}";
        }

        protected virtual void ResetTimer()
        {
            theTimerIsRunning = false;
            bool leftSomeTime = leftTime > 0;
            allPuzzleInformator.TimerText.enabled = leftSomeTime;
            if (leftSomeTime)
                TextLeftTime();
        }
    }
}