using Puzzle.TetraQuestion;
using System;
using UnityEngine;

namespace Puzzle
{
    [Serializable]
    public class TetraQuestionPackage : InformationPackage
    {
        public TetraQuestionPackage(Question question,
            Sprite puzzleBackground, DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            this.question = question;
        }

        [SerializeField]
        private Question question;

        public Question Question { get => question; }

    }
}