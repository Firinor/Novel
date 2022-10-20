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
        private ParticleSystem errorParticleSystem0;
        [SerializeField]
        private ParticleSystem errorParticleSystem1;
        private Dictionary<int, KeyValuePair<ParticleSystem, RectTransform>> errorParticleSystem;
        [SerializeField]
        private ParticleSystem successParticleSystem0;
        [SerializeField]
        private ParticleSystem successParticleSystem1;
        private Dictionary<int, KeyValuePair<ParticleSystem, RectTransform>> successParticleSystem;
        float offsetBetweenCursors;

        [SerializeField]
        private DetectiveDeskOperator detectiveDeskOperator;
        private int minimumImagePixelOffsetFromTheEdge = 30;

        [SerializeField]
        private ShakeOperator shakeOperator;

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

        void Awake()
        {
            errorParticleSystem = new Dictionary<int, KeyValuePair<ParticleSystem, RectTransform>>();
            successParticleSystem = new Dictionary<int, KeyValuePair<ParticleSystem, RectTransform>>();

            errorParticleSystem.Add(0, new KeyValuePair<ParticleSystem, RectTransform>(errorParticleSystem0,
                errorParticleSystem0.GetComponent<RectTransform>()));
            errorParticleSystem.Add(1, new KeyValuePair<ParticleSystem, RectTransform>(errorParticleSystem1,
                errorParticleSystem1.GetComponent<RectTransform>()));
            successParticleSystem.Add(0, new KeyValuePair<ParticleSystem, RectTransform>(successParticleSystem0,
                successParticleSystem0.GetComponent<RectTransform>()));
            successParticleSystem.Add(1, new KeyValuePair<ParticleSystem, RectTransform>(successParticleSystem1,
                successParticleSystem1.GetComponent<RectTransform>()));
        }
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
            detectiveDeskOperator.DeleteAllDifference();
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
            detectiveDeskOperator.CreateImages(imageWithDifferences, differencesCount,
                differencePrefab, minimumImagePixelOffsetFromTheEdge, out offsetBetweenCursors);
            doubleCursorOperator.SetOffset(offsetBetweenCursors);
            theTimerIsRunning = leftTime > 0;
        }
        public override void SuccessfullySolvePuzzle()
        {
            victoryButton.SetActive(true);
        }
        public void ActivateDifference(GameObject keyDifference, CursorOnEvidence cursorOnEvidence)
        {
            Particles(true, cursorOnEvidence);

            differencesFound++;
            progressOperator.AddProgress();

            

            if (differencesFound == differencesCount)
            {
                SuccessfullySolvePuzzle();
            }
        }

        public void Particles(bool success, CursorOnEvidence cursorOnEvidence)
        {
            Particles(success, Input.mousePosition, cursorOnEvidence);
        }
        public void Particles(bool success, Vector3 position, CursorOnEvidence cursorOnEvidence)
        {
            Dictionary<int, KeyValuePair<ParticleSystem, RectTransform>> particleSystem
                = success ? successParticleSystem : errorParticleSystem;

            particleSystem[0].Value.localPosition = position;
            particleSystem[1].Value.localPosition = position 
                + new Vector3(offsetBetweenCursors * -(int)cursorOnEvidence, 0,0);

            particleSystem[0].Key.Play();
            particleSystem[1].Key.Play();
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

        public void ErrorShake(CursorOnEvidence cursorOnEvidence)
        {
            Particles(false, cursorOnEvidence);
            shakeOperator.SetErrorImpulse();
        }
    }
}
