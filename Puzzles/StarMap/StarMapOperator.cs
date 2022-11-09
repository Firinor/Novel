using FirUnityEditor;
using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField, NullCheck]
        private TargetOperator targetOperator;
        [SerializeField, NullCheck]
        private Image targetImage;
        [SerializeField, NullCheck]
        private GlassBallViewOperator glassBallViewOperator;
        [SerializeField, NullCheck]
        private StarMapInGlassBallOperator starMapInGlassBallOperator;
        [SerializeField, NullCheck]
        private StarMapInformator starMapInformator;

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

            StartPuzzle();
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
            ResetPointerAndButton();
            ResetTimer();
        }
        public void CheckAnswer()
        {
            glassBallViewOperator.ActivePuzzle = false;
            targetImage.enabled = true;
            Vector2Int point = starMapInGlassBallOperator.GetCursorPoint();
            Color answer = targetImage.sprite.texture.GetPixel(point.x, point.y);
            if(answer.a > 0.4f)
            {
                SuccessfullySolvePuzzle();
            }
            else
            {
                LosePuzzle();
            }
        }
        private void ResetPointerAndButton()
        {
            targetOperator.SetButtonActivity(false);
            starMapInGlassBallOperator.SetTargetActivity(false);
            starMapInGlassBallOperator.SetCursorActivity(false);
        }
        public void SetButtonActivity()
        {
            targetOperator.SetButtonActivity(true);
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
            SetNewConstellation();
            SetVictoryDialogNode(spatMapPackage.successPuzzleDialog);
            SetFailDialogNode(spatMapPackage.failedPuzzleDialog);
            SetBackground(spatMapPackage.puzzleBackground);
        }

        private void SetNewConstellation()
        {
            Hemisphere hemisphere = starMapInformator.ChoseHemisphere();
            StarMapInformator.ConstellationsVariant.AnswerSprite answerSprite = starMapInformator.ChoseAnswerSprite(hemisphere);
            SetStarMapPuzzleContent(hemisphere);
            SetStarMapAnswerSprite(answerSprite.sprite);
            SetStarMapKeySprite(answerSprite.constellation);
        }

        private void SetStarMapKeySprite(Constellation constellation)
        {
            Sprite sprite = starMapInformator[constellation];
            targetOperator.SetAnswerKey(sprite);
        }

        private void SetStarMapAnswerSprite(Sprite sprite)
        {
            starMapInGlassBallOperator.SetAnswerSprite(sprite);
        }

        private void SetStarMapPuzzleContent(Hemisphere hemisphere)
        {
            Sprite sprite = starMapInformator[hemisphere].HemispherePuzzleSprite;
            starMapInGlassBallOperator.SetPuzzleSprite(sprite);
        }

        public override void StartPuzzle()
        {
            //keyOperator.CreateHint();
            theTimerIsRunning = leftTime > 0;
            glassBallViewOperator.ActivePuzzle = true;
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
