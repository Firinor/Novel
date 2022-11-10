using FirUnityEditor;
using Puzzle;
using System;
using UnityEngine;

namespace Puzzle
{
    public class ToDialog : DialogNode
    {
        [SerializeField, NullCheck]
        private PuzzleOperator puzzleOperator;

        public override void StartDialog()
        {
            puzzleOperator.PuzzleExit();
            StartDialog(index: 0);
        }
    }
}
