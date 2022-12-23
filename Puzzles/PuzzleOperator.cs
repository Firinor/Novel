﻿using FirUnityEditor;
using System;
using TMPro;
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

        [SerializeField]
        protected float leftTime = 120;
        [SerializeField, NullCheck]
        protected TextMeshProUGUI timerText;
        protected bool theTimerIsRunning;

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
            timerText.text = $"{dateTime:m:ss}";
        }

        protected virtual void ResetTimer()
        {
            theTimerIsRunning = false;
            bool leftSomeTime = leftTime > 0;
            timerText.enabled = leftSomeTime;
            if (leftSomeTime)
                TextLeftTime();
        }
    }
}