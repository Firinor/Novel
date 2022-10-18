using System;
using UnityEngine;
using UnityEngine.UI;
using FirMath;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;

namespace Puzzle.FindObject
{
    public class FindObjectOperator : PuzzleOperator
    {
        #region Fields
        private PuzzleInformator puzzleInformator;

        [SerializeField]
        private float ingredientFrictionBraking;
        [SerializeField]
        private float ingredientBorder;

        [SerializeField]
        private Image box;
        [SerializeField]
        private GameObject ingredientPrefab;

        [SerializeField]
        private ParticleSystem errorParticleSystem;
        [SerializeField]
        private ParticleSystem successParticleSystem;

        [SerializeField]
        private Transform ingredientParent;
        private List<AlchemicalIngredientOperator> allIngredients;
        [SerializeField]
        private Transform recipeParent;
        [SerializeField]
        private RecipeOperator recipeOperator;
        [SerializeField]
        private int recipeIngredientCount = 5;
        [SerializeField]
        private int ingredientInBoxCount = 250;
        [SerializeField]
        private float leftTime = 120;
        [SerializeField]
        private float forseToIngredient;
        private float acceleration = 0.02f;
        public float ForseToIngredient { get => forseToIngredient; }

        [HideInInspector]
        public bool PointerOnRecipe;

        [SerializeField]
        private TextMeshProUGUI timerText;
        private bool theTimerIsRunning;

        private List<int> recipe;
        private List<AlchemicalIngredientOperator> recipeList;

        [SerializeField]
        private AnimationManager animationManager;
        #endregion

        void Awake()
        {
            if (puzzleInformator == null)
            {
                puzzleInformator = GetComponent<PuzzleInformator>();
            }
        }

        void OnEnable()
        {
            ClearPuzzle();
            CreateNewRecipe();
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
            DeleteIngredientsInList(allIngredients);
            failButton.SetActive(true);
        }
        public override void ClearPuzzle()
        {
            victoryButton.SetActive(false);
            failButton.SetActive(false);
            CloseBox();
            box.GetComponent<Button>().enabled = true;
            DeleteAllIngredients();
            ResetTimer();
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
        private void DeleteAllIngredients()
        {
            DeleteIngredientsInList(recipeList);
            DeleteIngredientsInList(allIngredients);

        }
        private void DeleteIngredientsInList(List<AlchemicalIngredientOperator> ingredientsList)
        {
            if (ingredientsList != null)
            {
                foreach (AlchemicalIngredientOperator ingredient in ingredientsList)
                    Destroy(ingredient.gameObject);

                ingredientsList.Clear();
            }
        }

        private void CreateNewRecipe()
        {
            DeleteIngredientsInList(recipeList);
            Sprite[] alchemicalIngredientsSprites = puzzleInformator.AlchemicalIngredientsSprites;

            ingredientInBoxCount = Math.Min(ingredientInBoxCount, alchemicalIngredientsSprites.Length);

            recipe = GenerateNewRecipe(recipeIngredientCount, ingredientInBoxCount);
            recipeList = new List<AlchemicalIngredientOperator>();

            foreach (int i in recipe)
            {
                AlchemicalIngredientOperator newRecipeIngridient
                    = Instantiate(ingredientPrefab, recipeParent)
                    .GetComponent<AlchemicalIngredientOperator>();
                newRecipeIngridient.SetRecipeSprite(alchemicalIngredientsSprites[i]);
                newRecipeIngridient.SetPuzzleOperator(this);
                recipeList.Add(newRecipeIngridient);
            }
            recipeOperator.SetResipe(recipeList);
        }
        public void SetPuzzleInformationPackage(FindRecipeIngredientsPackage puzzleInformationPackage)
        {
            recipeIngredientCount = puzzleInformationPackage.RecipeDifficulty;
            ingredientInBoxCount = puzzleInformationPackage.IngredientsCount;
            leftTime = puzzleInformationPackage.AllottedTime;
            SetVictoryDialogNode(puzzleInformationPackage.successPuzzleDialog);
            SetFailDialogNode(puzzleInformationPackage.failedPuzzleDialog);
            SetBackground(puzzleInformationPackage.puzzleBackground);
        }

        public override void StartPuzzle()
        {
            OpenBox();
            theTimerIsRunning = leftTime > 0;

            Sprite[] alchemicalIngredientsSprites = puzzleInformator.AlchemicalIngredientsSprites;
            allIngredients = new List<AlchemicalIngredientOperator>();

            for (int i = 0; i < ingredientInBoxCount; i++)
            {
                AlchemicalIngredientOperator newIngridient
                    = Instantiate(ingredientPrefab, ingredientParent)
                    .GetComponent<AlchemicalIngredientOperator>();
                allIngredients.Add(newIngridient);
                newIngridient.SetSprite(alchemicalIngredientsSprites[i]);
                newIngridient.SetRandomImpulse(forseToIngredient);
                newIngridient.SetPuzzleOperator(this);
                if (recipe.Contains(i))
                {
                    newIngridient.AddToRecipe(recipe.IndexOf(i) + 1);
                }
            }
        }

        public override async void SuccessfullySolvePuzzle()
        {
            await HarvestAllIngredients();
            CloseBox();

            await Task.Delay(500);
            victoryButton.SetActive(true);
        }

        private void CloseBox()
        {
            box.sprite = puzzleInformator.ClosedAlchemicalBox;
            box.SetNativeSize();
        }
        private void OpenBox()
        {
            box.sprite = puzzleInformator.OpenAlchemicalBox;
            box.SetNativeSize();
            box.GetComponent<Button>().enabled = false;
        }

        private async Task HarvestAllIngredients()
        {
            float border = 0;
            float force = 0;

            List<AlchemicalIngredientOperator> ingredientsToDestroy = new List<AlchemicalIngredientOperator>();

            while (allIngredients != null && allIngredients.Count > 0)
            {
                foreach (AlchemicalIngredientOperator ingredient in allIngredients)
                {
                    if (ingredient.OnBox(border))
                    {
                        ingredient.SetImpulse(0, toZeroPoint: true);
                        ingredientsToDestroy.Add(ingredient);
                    }
                    else
                    {
                        ingredient.SetImpulse(force, toZeroPoint: true);
                    }
                }
                foreach (AlchemicalIngredientOperator ingredient in ingredientsToDestroy)
                {
                    allIngredients.Remove(ingredient);
                }
                border += acceleration;
                force += acceleration;

                await Task.Yield();
            }
            foreach (AlchemicalIngredientOperator ingredient in ingredientsToDestroy)
            {
                Destroy(ingredient.gameObject);
            }
        }

        private List<int> GenerateNewRecipe(int recipeIngredientCount, int length)
        {
            return GameMath.AFewCardsFromTheDeck(recipeIngredientCount, length);
        }

        internal void ActivateIngredient(int keyIngredientNumber)
        {
            if (puzzleFailed)
                return;

            bool TheRecipeIsReady = recipeOperator.ActivateIngredient(keyIngredientNumber);
            if (TheRecipeIsReady)
            {
                SuccessfullySolvePuzzle();
            }
        }

        internal Vector3 CheckImpulse(Vector3 impulse)
        {
            impulse *= ingredientFrictionBraking;
            if (Math.Abs(impulse.x) < ingredientBorder && Math.Abs(impulse.y) < ingredientBorder)
            {
                return Vector3.zero;
            }

            return impulse;
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

        internal void RemoveIngredient(AlchemicalIngredientOperator alchemicalIngredientOperator)
        {
            allIngredients.Remove(alchemicalIngredientOperator);
        }

        public override void Options()
        {
            ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
        }
    }
}