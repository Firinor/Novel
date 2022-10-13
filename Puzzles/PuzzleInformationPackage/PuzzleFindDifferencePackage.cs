using System;
using UnityEngine;

namespace Puzzle
{

    [Serializable]
    public class FindDifferencePackage : InformationPackage
    {
        public FindDifferencePackage(int differenceCount, float allottedTime,
            Sprite puzzleBackground, DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            if (differenceCount > 15)//max difference on image
            {
                differenceCount = 15;
            }
            if (differenceCount < 3)//min difference on image
            {
                differenceCount = 3;
            }

            this.differenceCount = differenceCount;
            this.allottedTime = Math.Max(allottedTime, 0);
        }
        [SerializeField]
        [Range(3, 1024)]
        private int differenceCount = 3;
        [SerializeField]
        [Range(0, 1024)]
        private float allottedTime = 0;

        public int DifferenceCount { get => differenceCount; }
        public float AllottedTime { get => allottedTime; }

    }
}
