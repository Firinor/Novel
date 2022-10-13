using FirMath;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Puzzle.FindDifferences
{
    public class FindDifferencesOperator : PuzzleOperator
    {
        #region Fields
        [SerializeField]
        private ImageOperator imageOperator;
        [SerializeField]
        private GameObject differencePrefab;
        [SerializeField]
        private ParticleSystem errorParticleSystem;
        [SerializeField]
        private ParticleSystem successParticleSystem;

        [SerializeField]
        private Transform differenceParent;
        private List<DifferenceOperator> allDifferences;
        [SerializeField]
        private int differencesCount = 5;
        [SerializeField]
        private int differencesFound;
        [SerializeField]
        private ObjectiveOperator objectiveText;

        [SerializeField]
        private float leftTime = 120;
        [SerializeField]
        private TextMeshProUGUI timerText;
        private bool theTimerIsRunning;

        [SerializeField]
        private AnimationManager animationManager;
        #endregion

        void OnEnable()
        {
            ClearPuzzle();
            PlayStartAnimations();
        }
        private void PlayStartAnimations()
        {
            animationManager.PlayStart();
        }
        void Update()
        {
            if (theTimerIsRunning && leftTime > 0)
            {
                leftTime -= Time.deltaTime;
                TextLeftTime();
                if (leftTime <= 0)
                {
                    theTimerIsRunning = false;
                    LosePuzzle();
                }
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
            puzzleFailed = true;
            failButton.SetActive(true);
        }
        public override void ClearPuzzle()
        {
            victoryButton.SetActive(false);
            failButton.SetActive(false);
            imageOperator.DisableButton();
            ResetTimer();
            ResetObjectives();
            puzzleFailed = false;
        }
        private void ResetTimer()
        {
            theTimerIsRunning = false;
            bool leftSomeTime = leftTime > 0;
            timerText.enabled = leftSomeTime;
            if (leftSomeTime)
                TextLeftTime();
        }
        private void ResetObjectives()
        {

        }
        private void DeleteAllDifference()
        {
            if (allDifferences != null)
            {
                foreach (DifferenceOperator difference in allDifferences)
                    Destroy(difference.gameObject);

                allDifferences.Clear();
            }
        }
        private void CreateNew()
        {

        }
        public void SetPuzzleInformationPackage(FindDifferencePackage puzzleInformationPackage)
        {
            differencesCount = puzzleInformationPackage.DifferenceCount;
            leftTime = puzzleInformationPackage.AllottedTime;
            SetVictoryDialogNode(puzzleInformationPackage.successPuzzleDialog);
            SetFailDialogNode(puzzleInformationPackage.failedPuzzleDialog);
            SetBackground(puzzleInformationPackage.puzzleBackground);
        }
        public override void StartPuzzle()
        {
            OpenBox();
            theTimerIsRunning = leftTime > 0;
        }
        public override void SuccessfullySolvePuzzle()
        {
            victoryButton.SetActive(true);
        }
        private void CloseBox()
        {

        }
        private void OpenBox()
        {
            imageOperator.EnableButton();
        }
        private List<int> GenerateNewRecipe(int recipeIngredientCount, int length)
        {
            return GameMath.AFewCardsFromTheDeck(recipeIngredientCount, length);
        }
        internal void ActivateIngredient(int keyIngredientNumber)
        {
            if (puzzleFailed)
                return;

            bool TheRecipeIsReady = imageOperator.ActivateDifference(keyIngredientNumber);
            if (TheRecipeIsReady)
            {
                SuccessfullySolvePuzzle();
            }
        }
        internal void Particles(Vector3 position, bool success)
        {
            ParticleSystem particleSystem = success ? successParticleSystem : errorParticleSystem;

            RectTransform rectTransform = particleSystem.GetComponent<RectTransform>();
            rectTransform.localPosition = position;

            particleSystem.Play();
        }
        public override void PuzzleExit()
        {
            gameObject.SetActive(false);
        }
        public override void Options()
        {
            ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
        }
    }
}
