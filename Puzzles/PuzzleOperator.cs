using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Puzzle
{
    public abstract class PuzzleOperator : MonoBehaviour
    {
        public Image background { get => BackgroundHUB.Image; }

        [SerializeField]
        protected float leftTime = 120;
        protected bool theTimerIsRunning;

        public GameObject HelpButtons { get => AllPuzzleHUB.HelpButtons; }
        private Button exitButton;
        public Button ExitButton
        {
            get
            {
                if (exitButton == null)
                    exitButton = AllPuzzleHUB.ExitButton.GetComponent<Button>();
                
                return exitButton;
            }
        }
        private Button optionsButton;
        public Button OptionsButton
        {
            get
            {
                if (optionsButton == null)
                    optionsButton = AllPuzzleHUB.OptionsButton.GetComponent<Button>();

                return optionsButton;
            }
        }

        public GameObject FailButton { get => AllPuzzleHUB.FailButton; }
        public GameObject VictoryButton { get => AllPuzzleHUB.VictoryButton; }
        public GameObject RetryButton { get => AllPuzzleHUB.RetryButton; }

        public TextMeshProUGUI TimerText { get => AllPuzzleHUB.TimerText; }

        protected virtual void OnEnable()
        {
            PreparePuzzle();
        }

        private void PreparePuzzle()
        {
            HelpButtons.SetActive(true);
            ExitButton.onClick.RemoveAllListeners();
            ExitButton.onClick.AddListener(PuzzleExit);
            OptionsButton.onClick.RemoveAllListeners();
            OptionsButton.onClick.AddListener(Options);
            ResetTimer();
        }

        public virtual void PuzzleExit()
        {
            DeactivaButtons();
            background.enabled = false;
            gameObject.SetActive(false);
            HelpButtons.SetActive(false);
        }
        public virtual void LosePuzzle()
        {
            FailButton.SetActive(true);
        }
        public virtual void Options()
        {
            PuzzleManager.Options();
        }
        public virtual void ClearPuzzle()
        {
            DeactivaButtons();
            TimerText.enabled = false;
        }

        private void DeactivaButtons()
        {
            VictoryButton.SetActive(false);
            FailButton.SetActive(false);
        }
        public virtual void StartPuzzle()
        {

        }

        public virtual void SuccessfullySolvePuzzle()
        {
            DeactivatePuzzle();
            VictoryButton.SetActive(true);
        }

        protected virtual void DeactivatePuzzle()
        {
            
        }

        protected virtual void SetVictoryEvent(UnityAction victoryAction)
        {
            Button button = VictoryButton.GetComponent<Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(PuzzleExit);
            if(victoryAction != null)
                button.onClick.AddListener(victoryAction);
        }
        protected virtual void SetFailEvent(UnityAction failAction)
        {
            Button button = FailButton.GetComponent<Button>();
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
            TimerText.text = $"{dateTime:m:ss}";
        }

        protected virtual void ResetTimer()
        {
            theTimerIsRunning = false;
            bool leftSomeTime = leftTime > 0;
            TimerText.enabled = leftSomeTime;
            if (leftSomeTime)
                TextLeftTime();
        }
    }
}