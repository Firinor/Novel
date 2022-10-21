using UnityEngine;

namespace Puzzle
{
    public class TetraQuestionPuzzle : DialogNode
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
            TetraQuestionPackage puzzleTetraQuestionPackage
                = new TetraQuestionPackage(
                    puzzlePackage.Question,
                    puzzleBackground,
                    successPuzzleDialog);
            DialogOperator.SwithToPuzzle(puzzleTetraQuestionPackage);
        }
    }
}

