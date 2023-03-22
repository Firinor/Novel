﻿using Puzzle.TetraQuestion;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Puzzle
{
    [Serializable]
    public class TetraQuestionPackage : InformationPackage
    {
        public TetraQuestionPackage(QuestionsQueue question,
            Sprite puzzleBackground, UnityAction successPuzzleDialog = null, UnityAction failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            this.question = question;
        }

        [SerializeField]
        private QuestionsQueue question;

        public QuestionsQueue Questions => question;

    }
}