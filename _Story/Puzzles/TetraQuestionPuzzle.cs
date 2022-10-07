using UnityEngine;

public class TetraQuestionPuzzle : DialogNode
{
    [SerializeField]
    private DialogNode successPuzzleDialog;
    [SerializeField]
    private DialogNode failedPuzzleDialog;
    [SerializeField]
    private PuzzleTetraQuestionPackage puzzlePackage;

    public override void StartDialog()
    {
        PuzzleTetraQuestionPackage puzzleTetraQuestionPackage
            = new PuzzleTetraQuestionPackage(
                puzzlePackage.Question,
                successPuzzleDialog);
        DialogOperator.SwithToPuzzle(puzzleTetraQuestionPackage);
    }
}

