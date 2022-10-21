using UnityEngine;

namespace Puzzle
{
    public class FindRecipeIngredientsPuzzle : DialogNode
    {
        [SerializeField]
        private DialogNode successPuzzleDialog;
        [SerializeField]
        private DialogNode failedPuzzleDialog;
        [SerializeField]
        private Sprite puzzleBackground;
        [SerializeField]
        private FindRecipeIngredientsPackage puzzlePackage;

        public override void StartDialog()
        {
            FindRecipeIngredientsPackage puzzleFindRecipeIngredientsPackage
                = new FindRecipeIngredientsPackage(
                    puzzlePackage.RecipeDifficulty,
                    puzzlePackage.IngredientsCount,
                    puzzlePackage.AllottedTime,
                    puzzleBackground,
                    successPuzzleDialog);
            DialogOperator.SwithToPuzzle(puzzleFindRecipeIngredientsPackage);
        }
    }
}
