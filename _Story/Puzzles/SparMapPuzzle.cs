using UnityEngine;

namespace Puzzle
{
    public class SparMapPuzzle : DialogNode
    {
        [SerializeField]
        private DialogNode successPuzzleDialog;
        [SerializeField]
        private DialogNode failedPuzzleDialog;
        [SerializeField]
        private Sprite puzzleBackground;
        [SerializeField]
        private StarMapPackage puzzlePackage;

        public override void StartDialog()
        {
            DialogOperator.skipText = false;
            StarMapPackage sparMapPackage
                = new StarMapPackage(
                    puzzlePackage.AllottedTime,
                    puzzleBackground,
                    successPuzzleDialog,
                    failedPuzzleDialog);
            DialogOperator.SwithToPuzzle(sparMapPackage);
        }
    }
}
