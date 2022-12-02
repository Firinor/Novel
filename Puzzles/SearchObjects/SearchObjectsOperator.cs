using FirMath;
using FirUnityEditor;
using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
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

        private List<int> desiredObjects;
        private List<ObjectToSearchOperator> progressList;

        [SerializeField, NullCheck]
        private ProgressOperator progressOperator;
        [SerializeField, NullCheck]
        private AnimationManager animationManager;

        private CompositeDisposable disposables;
        #endregion

        void OnEnable()
        {
            ClearPuzzle();
            CreateNewObjectsToSearch();
            PlayStartAnimations();

            disposables = new CompositeDisposable();

            Observable.EveryUpdate()
                .Where(_ => theTimerIsRunning && leftTime > 0)
                .Subscribe(_ => TimerTick())
                .AddTo(disposables);
        }

        private void CreateNewObjectsToSearch()
        {
            DeleteIngredientsInList(progressList);

            desiredObjects = GenerateNewDesiredList(differencesCount, imageWithDifferences.Differences.Length);
            progressList = new List<ObjectToSearchOperator>();

            foreach (int i in desiredObjects)
            {
                ObjectToSearchOperator newObjectToSearch
                    = Instantiate(searchObjectsPrefab, progressOperator.ObjectsParent)
                    .GetComponent<ObjectToSearchOperator>();
                newObjectToSearch.SetRecipeSprite(imageWithDifferences.Differences[i].sprite);
                progressList.Add(newObjectToSearch);
            }
            progressOperator.SetObjects(progressList);
        }

        private List<int> GenerateNewDesiredList(int differencesCount, int length)
        {
            return GameMath.AFewCardsFromTheDeck(differencesCount, length);
        }

        private void DeleteIngredientsInList(List<ObjectToSearchOperator> ingredientsList)
        {
            if (ingredientsList != null)
            {
                foreach (ObjectToSearchOperator ingredient in ingredientsList)
                    Destroy(ingredient.gameObject);

                ingredientsList.Clear();
            }
        }

        private void PlayStartAnimations()
        {
            animationManager.PlayStart();
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
