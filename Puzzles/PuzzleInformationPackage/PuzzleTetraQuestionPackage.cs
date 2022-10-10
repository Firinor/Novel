using System;
using UnityEngine;

[Serializable]
public class PuzzleTetraQuestionPackage : PuzzleInformationPackage
{
    public PuzzleTetraQuestionPackage(Question question,
        Sprite puzzleBackground, DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
        : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
    {
        this.question = question;
    }

    [SerializeField]
    private Question question;

    public Question Question { get => question; }

}