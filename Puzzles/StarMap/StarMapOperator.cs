using FirUnityEditor;
using System;
using TMPro;
using UniRx;
using UnityEngine;

namespace Puzzle.StarMap
{
    public enum Hemisphere { Northern, Southern, Winter, Spring, Summer, Autumn}

    public class StarMapOperator : PuzzleOperator
    {
        #region Fields
        [SerializeField, NullCheck]
        private GameObject targetConstellation;
        [SerializeField, NullCheck]
        private GameObject starMap;
        [SerializeField, NullCheck]
        private GameObject helpMap;

        [SerializeField]
        private float leftTime = 120;
        [SerializeField, NullCheck]
        private TextMeshProUGUI timerText;
        private bool theTimerIsRunning;

        private CompositeDisposable disposables;
        #endregion

        void OnEnable()
        {
            ClearPuzzle();

            disposables = new CompositeDisposable();

            Observable.EveryUpdate()
                .Where(_ => theTimerIsRunning && leftTime > 0)
                .Subscribe(_ => TimerTick())
                .AddTo(disposables);
        }

        void TimerTick()
        {
                leftTime -= Time.deltaTime;
                TextLeftTime();
                if (leftTime <= 0)
                {
                    theTimerIsRunning = false;
                    LosePuzzle();
                }
        }
        private void TextLeftTime()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(leftTime);
            DateTime dateTime = new DateTime(1, 1, 1, 0, timeSpan.Minutes, timeSpan.Seconds);
            timerText.text = $"{dateTime:m:ss}";
        }
        public override void LosePuzzle()
        {
            DeactivatePuzzle();
            failButton.SetActive(true);
        }
        public override void ClearPuzzle()
        {
            victoryButton.SetActive(false);
            failButton.SetActive(false);
            ResetTimer();
        }
        private void ResetTimer()
        {
            theTimerIsRunning = false;
            bool leftSomeTime = leftTime > 0;
            timerText.enabled = leftSomeTime;
            if (leftSomeTime)
                TextLeftTime();
        }
        public void SetPuzzleInformationPackage(StarMapPackage spatMapPackage)
        {
            leftTime = spatMapPackage.AllottedTime;
            SetVictoryDialogNode(spatMapPackage.successPuzzleDialog);
            SetFailDialogNode(spatMapPackage.failedPuzzleDialog);
            SetBackground(spatMapPackage.puzzleBackground);
        }
        public override void StartPuzzle()
        {
            //keyOperator.CreateHint();
            theTimerIsRunning = leftTime > 0;
        }
        public override void SuccessfullySolvePuzzle()
        {
            DeactivatePuzzle();
            victoryButton.SetActive(true);
        }
        protected override void DeactivatePuzzle()
        {
            theTimerIsRunning = false;
        }

        public override void PuzzleExit()
        {
            backgroundImage.enabled = false;
            gameObject.SetActive(false);
        }

        public void OpenHelpMap()
        {
            if (!helpMap.activeSelf)
            {
                EnabledPuzzle(false);
                EnabledHelpMap(true);
            }
        }
        public void OpenStarMap()
        {
            EnabledHelpMap(false);
            EnabledPuzzle(true);
        }
        private void EnabledHelpMap(bool v)
        {
            helpMap.SetActive(v);
        }

        private void EnabledPuzzle(bool v)
        {
            targetConstellation.SetActive(v);
            starMap.SetActive(v);
        }
    }
}
