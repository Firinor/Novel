using UnityEngine;

public class FindRecipeIngredientsPuzzle : DialogNode
{
    [SerializeField]
    private DialogNode successPuzzleDialog;
    [SerializeField]
    private DialogNode failedPuzzleDialog;
    [SerializeField]
    private Sprite puzzleBackground;
    [SerializeField]
    private PuzzleFindRecipeIngredientsPackage puzzlePackage;

    public override void StartDialog()
    {
        PuzzleFindRecipeIngredientsPackage puzzleFindRecipeIngredientsPackage
            = new PuzzleFindRecipeIngredientsPackage(
                puzzlePackage.RecipeDifficulty,
                puzzlePackage.IngredientsCount,
                puzzlePackage.AllottedTime,
                puzzleBackground,
                successPuzzleDialog);
        DialogOperator.SwithToPuzzle(puzzleFindRecipeIngredientsPackage);
    }
}
