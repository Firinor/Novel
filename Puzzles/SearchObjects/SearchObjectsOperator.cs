using FirUnityEditor;
using System;
using TMPro;
using UniRx;
//using UnityEditor.U2D.Sprites;
using UnityEngine;

namespace Puzzle.SearchObjects
{
    public class SearchObjectsOperator : PuzzleOperator
    {
        #region Fields
        [SerializeField, NullCheck]
        private GameObject searchObjectsPrefab;
        [SerializeField, NullCheck]
        private ParticleSystem errorParticleSystem;
        [SerializeField, NullCheck]
        private ParticleSystem successParticleSystem;

        [SerializeField, NullCheck]
        private DetectiveDeskOperator detectiveDeskOperator;

        [SerializeField]
        private ImageWithDifferences imageWithDifferences;
        [SerializeField]
        private int differencesCount = 5;
        private int differencesFound;
        
        [SerializeField]
        private float leftTime = 120;
        [SerializeField, NullCheck]
        private TextMeshProUGUI timerText;
        private bool theTimerIsRunning;

        [SerializeField, NullCheck]
        private ProgressOperator progressOperator;
        [SerializeField, NullCheck]
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
                .Where(_ => theTimerIsRunning && leftTime > 0)
                .Subscribe(_ => TimerTick())
                .AddTo(disposables);
        }
        private void CreateDifference—ounter()
        {
        //    var factory = new SpriteDataProviderFactories();
        //    factory.Init();
        //    var dataProvider = factory.GetSpriteEditorDataProviderFromObject(imageWithDifferences.differences2);
        //    dataProvider.InitSpriteEditorDataProvider();

        //    var spriteRects = dataProvider.GetSpriteRects();

            //
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
            detectiveDeskOperator.ClearImages();
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
        public void SetPuzzleInformationPackage(ImageWithDifferencesPackage puzzleInformationPackage)
        {
            imageWithDifferences = puzzleInformationPackage.ImageWithDifferences;
            differencesCount = puzzleInformationPackage.DifferenceCount;
            leftTime = puzzleInformationPackage.AllottedTime;
            SetVictoryEvent(puzzleInformationPackage.successPuzzleAction);
            SetFailEvent(puzzleInformationPackage.failedPuzzleAction);
            SetBackground(puzzleInformationPackage.PuzzleBackground);
        }
        public override void StartPuzzle()
        {
            detectiveDeskOperator.enabled = true;
            detectiveDeskOperator.DisableButton();
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
            detectiveDeskOperator.DisableImages();
            detectiveDeskOperator.enabled = false;
        }
        public void ActivateDifference(GameObject keyDifference)
        {
            Particles(true);

            differencesFound++;
            progressOperator.AddProgress();

            if (differencesFound == differencesCount)
            {
                SuccessfullySolvePuzzle();
            }
        }

        public void Particles(bool success)
        {
            Particles(success, Input.mousePosition);
        }
        public void Particles(bool success, Vector3 position)
        {
            ParticleSystem particleSystem = success ? successParticleSystem : errorParticleSystem;

            particleSystem.transform.localPosition = position;

            particleSystem.Play();
        }

        public override void PuzzleExit()
        {
            Cursor.visible = true;
            backgroundImage.enabled = false;
            gameObject.SetActive(false);
        }

        public void ErrorParticles()
        {
            Particles(false);
        }
    }
}
