using UnityEngine;

namespace Puzzle
{
    public enum PuzzleEnum { FindRecipeIngredients, FindСonstellation, AQuestionWithAnswers };

    public abstract class InformationPackage
    {
        protected InformationPackage(Sprite puzzleBackground,
            DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
        {
            this.successPuzzleDialog = successPuzzleDialog;
            this.failedPuzzleDialog = failedPuzzleDialog;
            this.puzzleBackground = puzzleBackground;
        }

        public DialogNode successPuzzleDialog { get; }
        public DialogNode failedPuzzleDialog { get; }
        public Sprite puzzleBackground { get; }

    }
}
