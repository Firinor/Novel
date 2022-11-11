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
            bool successFunc = successPuzzleDialog != null;
            bool failFunc = failedPuzzleDialog != null;

            DialogOperator.skipText = false;
            StarMapPackage sparMapPackage;

            if (failFunc)
            {
                sparMapPackage
                    = new StarMapPackage(
                        puzzlePackage.AllottedTime,
                        puzzleBackground,
                        successPuzzleDialog.StartDialog,
                        failedPuzzleDialog.StartDialog);
            }
            else if (successFunc)
            {
                sparMapPackage
                    = new StarMapPackage(
                        puzzlePackage.AllottedTime,
                        puzzleBackground,
                        successPuzzleDialog.StartDialog);
            }
            else
            {
                sparMapPackage
                    = new StarMapPackage(
                        puzzlePackage.AllottedTime,
                        puzzleBackground);
            }
            DialogManager.SwithToPuzzle(sparMapPackage);
        }
    }
}
