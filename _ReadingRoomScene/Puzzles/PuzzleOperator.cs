using System;
using UnityEngine;
using UnityEngine.UI;
using FirMath;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PuzzleOperator : MonoBehaviour
{
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
    private GameObject victoryButton;

    [SerializeField]
    private ParticleSystem errorParticleSystem;
    [SerializeField]
    private ParticleSystem successParticleSystem;

    [SerializeField]
    private Transform ingredientParent;
    [SerializeField]
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
    private float forseToIngredient;
    public float ForseToIngredient { get => forseToIngredient; }

    public bool PointerOnRecipe;

    private List<int> recipe;
    private List<AlchemicalIngredientOperator> recipeList;

    void Awake()
    {
        if(puzzleInformator == null)
        {
            puzzleInformator = GetComponent<PuzzleInformator>();
        }

        CreateRecipe();
    }

    private void CreateRecipe()
    {
        ClearRecipe();
        Sprite[] alchemicalIngredientsSprites = puzzleInformator.AlchemicalIngredientsSprites;

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

    private void ClearRecipe()
    {
        if(recipeList != null)
        foreach(AlchemicalIngredientOperator ingredient in recipeList)
        {
            Destroy(ingredient.gameObject);
        }
    }

    public void SetPuzzleInformationPackage(PuzzleInformationPackage puzzleInformationPackage)
    {
        switch (puzzleInformationPackage)
        {
            case PuzzleFindRecipeIngredientsPackage findRecipeIngredients:
                recipeIngredientCount = findRecipeIngredients.RecipeDifficulty;
                ingredientInBoxCount = findRecipeIngredients.IngredientsCount;
                break;
            case null:
                break;
            default:
                break;
        }
    }

    public void StartFindObjectPuzzle()
    {
        box.sprite = puzzleInformator.OpenAlchemicalBox;
        box.SetNativeSize();
        box.GetComponent<Button>().enabled = false;

        Sprite[] alchemicalIngredientsSprites = puzzleInformator.AlchemicalIngredientsSprites;

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
                newIngridient.AddToRecipe(recipe.IndexOf(i)+1);
            }
        }
    }

    public async void FinishFindObjectPuzzle()
    {
        await HarvestAllIngredients();

        box.sprite = puzzleInformator.ClosedAlchemicalBox;
        box.SetNativeSize();
    }

    private async Task HarvestAllIngredients()
    {
        float border = 0;

        while (allIngredients!=null && allIngredients.Count > 0)
        {
            List<AlchemicalIngredientOperator> ingredientsToDestroy = new List<AlchemicalIngredientOperator>();
            foreach (AlchemicalIngredientOperator ingredient in allIngredients)
            {
                if (ingredient.OnBox(border))
                {
                    ingredientsToDestroy.Add(ingredient);
                    Destroy(ingredient.gameObject, 1f);
                }
                else
                {
                    ingredient.SetImpulse(border, toZeroPoint: true);
                }
            }
            foreach(AlchemicalIngredientOperator ingredient in ingredientsToDestroy)
            {
                allIngredients.Remove(ingredient);
            }
            border += 0.02f;

            await Task.Yield();
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
            FinishFindObjectPuzzle();
            victoryButton.SetActive(true);
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

    public void PuzzleExit()
    {
        gameObject.SetActive(false);
    }

    internal void RemoveIngredient(AlchemicalIngredientOperator alchemicalIngredientOperator)
    {
        allIngredients.Remove(alchemicalIngredientOperator);
    }
}
