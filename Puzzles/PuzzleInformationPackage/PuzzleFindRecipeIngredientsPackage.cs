using System;
using UnityEngine;

[Serializable]
public class PuzzleFindRecipeIngredientsPackage : PuzzleInformationPackage
{
    public PuzzleFindRecipeIngredientsPackage(int recipeDifficulty, int ingredientsCount, float allottedTime,
        Sprite puzzleBackground, DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
        : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
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
        this.allottedTime = Math.Max(allottedTime, 0);
    }
    [SerializeField]
    [Range(1, 10)]
    private int recipeDifficulty = 1;
    [SerializeField]
    [Range(10, 1024)]
    private int ingredientsCount = 2;
    [SerializeField]
    [Range(0, 1024)]
    private float allottedTime = 0;

    public int RecipeDifficulty { get => recipeDifficulty; }
    public int IngredientsCount { get => ingredientsCount; }
    public float AllottedTime { get => allottedTime; }
}