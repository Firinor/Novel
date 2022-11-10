using Puzzle.TetraQuestion;
using System;
using UnityEngine;
using FirMath;
using UnityEngine.Events;

namespace Puzzle
{
    [Serializable]
    public class TetraQuestionPackage : InformationPackage
    {
        public TetraQuestionPackage(Question[] question,
            Sprite puzzleBackground, UnityAction successPuzzleDialog, UnityAction failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            this.question = question;
        }

        [SerializeField]
        private Question[] question;

        public Question[] Question { get => question; }

        public Question GetRandomQuestion()
        {
            return question[GameMath.RandomCardFromTheDeck(question.Length)];
        }
    }
}