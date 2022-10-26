using Puzzle.StarMap;
using System;
using UnityEngine;

namespace Puzzle
{
    [Serializable]
    public class StarMapPackage : InformationPackage
    {
        public StarMapPackage(float allottedTime,
            Sprite puzzleBackground, DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            this.allottedTime = Math.Max(allottedTime, 0);
        }
        [SerializeField]
        [Range(0, 1024)]
        private float allottedTime = 0;
        [SerializeField]
        private Hemisphere hemisphere;

        public float AllottedTime { get => allottedTime; }
        public Hemisphere Hemisphere { get => hemisphere; }
    }
}

