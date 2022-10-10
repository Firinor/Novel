using System;
using UnityEngine;

public class TetraQuestionPuzzle : DialogNode
{
    [SerializeField]
    private DialogNode successPuzzleDialog;
    [SerializeField]
    private DialogNode failedPuzzleDialog;
    [SerializeField]
    private Sprite puzzleBackground;
    [SerializeField]
    private PuzzleTetraQuestionPackage puzzlePackage;

    public override void StartDialog()
    {
        PuzzleTetraQuestionPackage puzzleTetraQuestionPackage
            = new PuzzleTetraQuestionPackage(
                puzzlePackage.Question,
                puzzleBackground,
                successPuzzleDialog);
        DialogOperator.SwithToPuzzle(puzzleTetraQuestionPackage);
    }
}

