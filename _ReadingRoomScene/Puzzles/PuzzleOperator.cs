using System;
using UnityEngine;
using UnityEngine.UI;
using FirMath;
using System.Collections.Generic;

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
    private ParticleSystem errorParticleSystem;
    [SerializeField]
    private ParticleSystem successParticleSystem;

    [SerializeField]
    private Transform ingredientParent;
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

    void Awake()
    {
        if(puzzleInformator == null)
        {
            puzzleInformator = GetComponent<PuzzleInformator>();
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

        Sprite[] AlchemicalIngredientsSprites = puzzleInformator.AlchemicalIngredientsSprites;

        List<int> recipe = GenerateNewRecipe(recipeIngredientCount, ingredientInBoxCount);
        List<AlchemicalIngredientOperator> recipeList = new List<AlchemicalIngredientOperator>();
        int keyIngredientNumber = 1;

        for (int i = 0; i < ingredientInBoxCount; i++)
        {
            AlchemicalIngredientOperator newIngridient 
                = Instantiate(ingredientPrefab, ingredientParent)
                .GetComponent<AlchemicalIngredientOperator>();
            newIngridient.SetSprite(AlchemicalIngredientsSprites[i]);
            newIngridient.SetRandomImpulse(forseToIngredient);
            newIngridient.SetPuzzleOperator(this);
            if (recipe.Contains(i))
            {
                //recipeList.Add(newIngridient);
                newIngridient.AddToRecipe(keyIngredientNumber);
                keyIngredientNumber++;
                AlchemicalIngredientOperator newRecipeIngridient
                    = Instantiate(ingredientPrefab, recipeParent)
                    .GetComponent<AlchemicalIngredientOperator>();
                newRecipeIngridient.SetRecipeSprite(AlchemicalIngredientsSprites[i]);
                newRecipeIngridient.black = true;
                recipeList.Add(newRecipeIngridient);
            }
            recipeOperator.SetResipe(recipeList);
        }
    }

    private List<int> GenerateNewRecipe(int recipeIngredientCount, int length)
    {
        return GameMath.AFewCardsFromTheDeck(recipeIngredientCount, length);
    }

    internal void ActivateIngredient(AlchemicalIngredientOperator alchemicalIngredientOperator, int keyIngredientNumber)
    {
        bool TheRecipeIsReady = recipeOperator.ActivateIngredient(alchemicalIngredientOperator, keyIngredientNumber);
        if (TheRecipeIsReady)
        {
            Debug.Log("Finish!");
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
        if (success)
        {
            successParticleSystem.GetComponent<RectTransform>().localPosition = position;
            successParticleSystem.Play();
        }
        else
        {
            errorParticleSystem.GetComponent<RectTransform>().localPosition = position;
            errorParticleSystem.Play();
        }
    }
}
