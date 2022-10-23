using Puzzle.FindDifferences;
using System;
using UnityEngine;

namespace Puzzle
{

    [Serializable]
    public class FindDifferencePackage : InformationPackage
    {
        public FindDifferencePackage(ImageWithDifferences imageWithDifferences, int differenceCount, float allottedTime,
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
            this.imageWithDifferences = imageWithDifferences;
        }
        [SerializeField]
        private ImageWithDifferences imageWithDifferences;

        [SerializeField]
        [Range(3, 1024)]
        private int differenceCount = 3;
        [SerializeField]
        [Range(0, 1024)]
        private float allottedTime = 0;

        public int DifferenceCount { get => differenceCount; }
        public float AllottedTime { get => allottedTime; }
        public ImageWithDifferences ImageWithDifferences { get => imageWithDifferences; }
    }
}
