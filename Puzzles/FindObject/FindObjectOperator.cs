using System;
using UnityEngine;
using UnityEngine.UI;
using FirMath;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using FirUnityEditor;

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
        private float recipeOffset;

        [SerializeField, NullCheck]
        private Image box;
        [SerializeField, NullCheck]
        private GameObject ingredientPrefab;

        [SerializeField, NullCheck]
        private ParticleSystem errorParticleSystem;
        [SerializeField, NullCheck]
        private ParticleSystem successParticleSystem;

        [SerializeField, NullCheck]
        private Transform ingredientParent;
        private List<AlchemicalIngredientOperator> allIngredients;
        [SerializeField, NullCheck]
        private RectTransform helpButtonsRectTransform;
        [SerializeField, NullCheck]
        private RectTransform recipeParent;
        [SerializeField, NullCheck]
        private RecipeOperator recipeOperator;
        private Sprite[] alchemicalIngredientsSprites;
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

        [SerializeField, NullCheck]
        private TextMeshProUGUI timerText;
        private bool theTimerIsRunning;

        private List<int> recipe;
        private List<AlchemicalIngredientOperator> recipeList;

        [SerializeField, NullCheck]
        private AnimationManager animationManager;
        #endregion

        void Awake()
        {
            float screenOffset = Screen.height / 2;
            recipeOffset = recipeParent.sizeDelta.y - screenOffset;

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
            alchemicalIngredientsSprites = puzzleInformationPackage.Ingredients;
            recipeIngredientCount = puzzleInformationPackage.RecipeDifficulty;
            ingredientInBoxCount = puzzleInformationPackage.IngredientsCount;
            leftTime = puzzleInformationPackage.AllottedTime;
            SetVictoryEvent(puzzleInformationPackage.successPuzzleAction);
            SetFailEvent(puzzleInformationPackage.failedPuzzleAction);
            SetBackground(puzzleInformationPackage.PuzzleBackground);
        }

        public override void StartPuzzle()
        {
            OpenBox();
            theTimerIsRunning = leftTime > 0;

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
            bool TheRecipeIsReady = recipeOperator.ActivateIngredient(keyIngredientNumber);
            if (TheRecipeIsReady)
            {
                SuccessfullySolvePuzzle();
            }
        }

        internal Vector3 CheckImpulse(ref Vector3 pos, ref Vector3 impulse)
        {
            if(BrakingField(ref pos))
                impulse *= ingredientFrictionBraking;

            if (Math.Abs(impulse.x) < ingredientBorder && Math.Abs(impulse.y) < ingredientBorder)
            {
                return Vector3.zero;
            }

            return impulse;
        }

        private bool BrakingField(ref Vector3 pos)
        {
            return pos.y > recipeOffset;
        }

        internal void Particles(Vector3 position, bool success)
        {
            ParticleSystem particleSystem = success ? successParticleSystem : errorParticleSystem;

            RectTransform rectTransform = particleSystem.GetComponent<RectTransform>();
            rectTransform.localPosition = position;

            particleSystem.Play();
        }

        internal void RemoveIngredient(AlchemicalIngredientOperator alchemicalIngredientOperator)
        {
            allIngredients.Remove(alchemicalIngredientOperator);
        }

        public void SkipPuzzle()
        {
            SuccessfullySolvePuzzle();
        }
    }
}