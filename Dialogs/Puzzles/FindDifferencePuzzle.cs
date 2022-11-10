using UnityEngine;

namespace Puzzle
{
    public class FindDifferencePuzzle : DialogNode
    {
        [SerializeField]
        private DialogNode successPuzzleDialog;
        [SerializeField]
        private DialogNode failedPuzzleDialog;
        [SerializeField]
        private Sprite puzzleBackground;
        [SerializeField]
        private FindDifferencePackage puzzlePackage;

        public override void StartDialog()
        {
            DialogOperator.skipText = false;
            FindDifferencePackage puzzleFindDifferencePackage
                = new FindDifferencePackage(
                    puzzlePackage.ImageWithDifferences,
                    puzzlePackage.DifferenceCount,
                    puzzlePackage.AllottedTime,
                    puzzleBackground,
                    successPuzzleDialog.StartDialog,
                    failedPuzzleDialog.StartDialog);
            DialogManager.SwithToPuzzle(puzzleFindDifferencePackage);
        }
    }
}
