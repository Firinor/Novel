using FirMath;
using Puzzle.FindObject;
using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

namespace Puzzle.FindDifferences
{
    public class FindDifferencesOperator : PuzzleOperator
    {
        #region Fields
        [SerializeField]
        private GameObject differencePrefab;
        [SerializeField]
        private ParticleSystem errorParticleSystem;
        [SerializeField]
        private ParticleSystem successParticleSystem;

        [SerializeField]
        private DetectiveDeskOperator detectiveDeskOperator;
        private int minimumImagePixelOffsetFromTheEdge = 30;
        private List<GameObject> allDifferences;
        [SerializeField]
        private ImageWithDifferences imageWithDifferences;
        [SerializeField]
        private int differencesCount = 5;
        private int differencesFound;
        [SerializeField]
        private ProgressOperator progressOperator;

        [SerializeField]
        private float leftTime = 120;
        [SerializeField]
        private TextMeshProUGUI timerText;
        private bool theTimerIsRunning;

        [SerializeField]
        private DoubleCursorOperator doubleCursorOperator;
        [SerializeField]
        private AnimationManager animationManager;

        private CompositeDisposable disposables;
        #endregion

        void OnEnable()
        {
            ClearPuzzle();
            CreateDifference—ounter();
            PlayStartAnimations();

            disposables = new CompositeDisposable();

            Observable.EveryUpdate()
                .Where(_ => EvidenceOperator.cursorOnImage)
                .Subscribe(_ => MoveCursor())
                .AddTo(disposables);
            Observable.EveryUpdate()
                .Where(_ => theTimerIsRunning && leftTime > 0)
                .Subscribe(_ => TimerTick())
                .AddTo(disposables);
        }
        private void CreateDifference—ounter()
        {
            differencesCount = Math.Min(imageWithDifferences.Differences.Length, differencesCount);
            progressOperator.CreateProgress—ounter(differencesCount);
        }

        private void PlayStartAnimations()
        {
            animationManager.PlayStart();
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

        private void MoveCursor()
        {
            doubleCursorOperator.MoveCursor();
        }

        private void TextLeftTime()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(leftTime);
            DateTime dateTime = new DateTime(1, 1, 1, 0, timeSpan.Minutes, timeSpan.Seconds);
            timerText.text = $"{dateTime:m:ss}";
        }
        public override void LosePuzzle()
        {
            failButton.SetActive(true);
        }
        public override void ClearPuzzle()
        {
            victoryButton.SetActive(false);
            failButton.SetActive(false);
            detectiveDeskOperator.EnableButton();
            detectiveDeskOperator.ClearImages();
            doubleCursorOperator.DisableCursors();
            DeleteAllDifference();
            ResetTimer();
            differencesFound = 0;
        }
        private void ResetTimer()
        {
            theTimerIsRunning = false;
            bool leftSomeTime = leftTime > 0;
            timerText.enabled = leftSomeTime;
            if (leftSomeTime)
                TextLeftTime();
        }
        public void DeleteAllDifference()
        {
            if (allDifferences != null)
            {
                foreach (GameObject difference in allDifferences)
                    Destroy(difference);

                allDifferences.Clear();
            }
        }
        public void SetPuzzleInformationPackage(FindDifferencePackage puzzleInformationPackage)
        {
            imageWithDifferences = puzzleInformationPackage.ImageWithDifferences;
            differencesCount = puzzleInformationPackage.DifferenceCount;
            leftTime = puzzleInformationPackage.AllottedTime;
            SetVictoryDialogNode(puzzleInformationPackage.successPuzzleDialog);
            SetFailDialogNode(puzzleInformationPackage.failedPuzzleDialog);
            SetBackground(puzzleInformationPackage.puzzleBackground);
        }
        public override void StartPuzzle()
        {
            detectiveDeskOperator.DisableButton();
            float offsetBetweenCursors;
            detectiveDeskOperator.CreateImages(imageWithDifferences, differencesCount,
                differencePrefab, minimumImagePixelOffsetFromTheEdge, out allDifferences, out offsetBetweenCursors);
            doubleCursorOperator.SetOffset(offsetBetweenCursors);
            theTimerIsRunning = leftTime > 0;
        }
        public override void SuccessfullySolvePuzzle()
        {
            victoryButton.SetActive(true);
        }
        public void ActivateDifference(GameObject keyDifference)
        {
            differencesFound++;
            progressOperator.AddProgress();

            

            if (differencesFound == differencesCount)
            {
                SuccessfullySolvePuzzle();
            }
        }
        public void Particles(Vector3 position, bool success)
        {
            ParticleSystem particleSystem = success ? successParticleSystem : errorParticleSystem;

            RectTransform rectTransform = particleSystem.GetComponent<RectTransform>();
            rectTransform.localPosition = position;

            particleSystem.Play();
        }

        public void SetCursorOnEvidence(CursorOnEvidence cursorOnEvidence)
        {
            doubleCursorOperator.cursorOnEvidence = cursorOnEvidence;
        }

        public void EnableCursors()
        {
            doubleCursorOperator.EnableCursors();
        }

        public void DisableCursors()
        {
            doubleCursorOperator.DisableCursors();
        }
        public override void PuzzleExit()
        {
            Cursor.visible = true;
            backgroundImage.enabled = false;
            gameObject.SetActive(false);
        }

        internal void CheckTheEvidence(Vector2 pointOnImage)
        {

            foreach (var difference in allDifferences)
            {
                if (difference.GetComponent<RectTransform>().rect.Contains(pointOnImage))
                {
                    Particles(pointOnImage, true);
                    ActivateDifference(difference);
                    return;
                }
            }


            ErrorShake(pointOnImage);
        }

        private void ErrorShake(Vector2 pointOnImage)
        {
            Particles(pointOnImage, false);
        }
    }
}
