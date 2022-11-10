using System;
using UnityEngine;
using UnityEngine.Events;

namespace Puzzle
{
    [Serializable]
    public class StarMapPackage : InformationPackage
    {
        public StarMapPackage(float allottedTime,
            Sprite puzzleBackground, UnityAction successPuzzleDialog, UnityAction failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            this.allottedTime = Math.Max(allottedTime, 0);
        }

        [SerializeField]
        [Range(0, 1024)]
        private float allottedTime = 0;

        public float AllottedTime { get => allottedTime; }
    }
}

