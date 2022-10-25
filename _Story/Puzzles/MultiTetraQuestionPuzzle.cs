using UnityEngine;

namespace Puzzle
{
    public class MultiTetraQuestionPuzzle : DialogNode
    {
        [SerializeField]
        private DialogNode successPuzzleDialog;
        [SerializeField]
        private DialogNode failedPuzzleDialog;
        [SerializeField]
        private Sprite puzzleBackground;
        [SerializeField]
        private TetraQuestionPackage puzzlePackage;

        public override void StartDialog()
        {
            DialogOperator.skipText = false;
            TetraQuestionPackage puzzleTetraQuestionPackage
                = new TetraQuestionPackage(
                    puzzlePackage.Question,
                    puzzleBackground,
                    successPuzzleDialog,
                    failedPuzzleDialog);
            DialogOperator.SwithToPuzzle(puzzleTetraQuestionPackage);
        }
    }
}

