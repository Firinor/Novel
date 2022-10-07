using System;
using UnityEngine;

[Serializable]
public class PuzzleTetraQuestionPackage : PuzzleInformationPackage
{
    public PuzzleTetraQuestionPackage(Question question,
        DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
        : base(successPuzzleDialog, failedPuzzleDialog)
    {
        this.question = question;
    }

    [SerializeField]
    private Question question;

    public Question Question { get => question; }

}