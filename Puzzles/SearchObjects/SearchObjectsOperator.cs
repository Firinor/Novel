using FirMath;
using FirUnityEditor;
using System.Collections.Generic;
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
        [SerializeField]
        private int trashCount = 10;
        private int differencesFound;

        private List<int> desiredObjects;
        private List<int> trashObjects;
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

            trashObjects = GenerateNewTrashList(trashCount, imageWithDifferences.Differences.Length);
            desiredObjects = GenerateNewDesiredList(differencesCount, trashObjects);
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

        private List<int> GenerateNewTrashList(int count, int length)
        {
            return GameMath.AFewCardsFromTheDeck(count, length);
        }
        private List<int> GenerateNewDesiredList(int count, List<int> trashObjects)
        {
            List<int> desiredList = GameMath.AFewCardsFromTheDeck(count, trashObjects.Count);
            List<int> result = new List<int>();
            for (int i = 0; i< count; i++)
            {
                result.Add(trashObjects[desiredList[i]]);
            }

            return result;
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
            trashCount = puzzleInformationPackage.TrashCount;
            leftTime = puzzleInformationPackage.AllottedTime;
            SetVictoryEvent(puzzleInformationPackage.successPuzzleAction);
            SetFailEvent(puzzleInformationPackage.failedPuzzleAction);
            SetBackground(puzzleInformationPackage.PuzzleBackground);
        }
        public override void StartPuzzle()
        {
            detectiveDeskOperator.enabled = true;
            detectiveDeskOperator.DisableButton();
            detectiveDeskOperator.CreateImage(imageWithDifferences, trashObjects,
                searchObjectsPrefab);
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
