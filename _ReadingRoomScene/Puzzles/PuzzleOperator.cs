using System;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;
using FirMath;
using System.Collections.Generic;

public class PuzzleOperator : MonoBehaviour
{
    private PuzzleInformator puzzleInformator;
    [SerializeField]
    private Image box;
    [SerializeField]
    private GameObject ingredientPrefab;
    [SerializeField]
    private Transform ingredientParent;
    [SerializeField]
    private Transform recipeParent;
    [SerializeField]
    private int recipeIngredientCount = 5;
    [SerializeField]
    private float forseToIngredient;

    void Awake()
    {
        if(puzzleInformator == null)
        {
            puzzleInformator = GetComponent<PuzzleInformator>();
        }
    }

    public void StartFindObjectPuzzle()
    {
        box.sprite = puzzleInformator.OpenAlchemicalBox;
        box.SetNativeSize();
        box.GetComponent<Button>().enabled = false;

        Sprite[] AlchemicalIngredientsSprites = puzzleInformator.AlchemicalIngredientsSprites;
        int length = AlchemicalIngredientsSprites.Length;

        List<int> recipe = new List<int>(GenerateNewRecipe(recipeIngredientCount, length));

        for (int i = 0; i < length; i++)
        {
            AlchemicalIngredientOperator newIngridient 
                = Instantiate(ingredientPrefab, ingredientParent)
                .GetComponent<AlchemicalIngredientOperator>();
            newIngridient.SetSprite(AlchemicalIngredientsSprites[i]);
            newIngridient.SetRandomImpulse(forseToIngredient);

            if (recipe.Contains(i))
            {
                AlchemicalIngredientOperator newRecipeIngridient
                    = Instantiate(ingredientPrefab, recipeParent)
                    .GetComponent<AlchemicalIngredientOperator>();
                newRecipeIngridient.SetRecipeSprite(AlchemicalIngredientsSprites[i]);
            }
        }

    }

    private int[] GenerateNewRecipe(int recipeIngredientCount, int length)
    {
        return GameMath.AFewCardsFromTheDeck(recipeIngredientCount, length);
    }
}
