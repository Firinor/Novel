using System;
using UnityEngine;

[Serializable]
public class PuzzleFindRecipeIngredientsPackage : PuzzleInformationPackage
{
    public PuzzleFindRecipeIngredientsPackage(int recipeDifficulty, int ingredientsCount,
        DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
        : base(successPuzzleDialog, failedPuzzleDialog)
    {
        if(ingredientsCount > puzzleInformator.AlchemicalIngredientsSprites.Length)
        {
            ingredientsCount = puzzleInformator.AlchemicalIngredientsSprites.Length;
        }
        if(ingredientsCount < 2)
        {
            ingredientsCount = 2;
        }
        if (recipeDifficulty > ingredientsCount)
        {
            recipeDifficulty = ingredientsCount;
        }
        if(recipeDifficulty < 1)
        {
            recipeDifficulty = 1;
        }

        this.recipeDifficulty = recipeDifficulty;
        this.ingredientsCount = ingredientsCount;
    }
    [SerializeField]
    [Range(1, 10)]
    private int recipeDifficulty = 1;
    [SerializeField]
    [Range(10, 1024)]
    private int ingredientsCount = 2;
    public int RecipeDifficulty { get => recipeDifficulty; }
    public int IngredientsCount { get => ingredientsCount; }
}