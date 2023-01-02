using System;
using UnityEngine;
using UnityEngine.Events;

namespace Puzzle
{
    [Serializable]
    public class PortalBuildPackage : InformationPackage
    {
        public PortalBuildPackage(int puzzleDifficulty, int ingredientsCount, float allottedTime,
            Sprite puzzleBackground, UnityAction successPuzzleDialog = null, UnityAction failedPuzzleDialog = null)
            : base(puzzleBackground, successPuzzleDialog, failedPuzzleDialog)
        {
            if (ingredientsCount < 2)
            {
                ingredientsCount = 2;
            }
            if (puzzleDifficulty > ingredientsCount)
            {
                puzzleDifficulty = ingredientsCount;
            }
            if (puzzleDifficulty < 1)
            {
                puzzleDifficulty = 1;
            }

            this.puzzleDifficulty = puzzleDifficulty;
            this.ingredientsCount = ingredientsCount;
            this.allottedTime = Math.Max(allottedTime, 0);
        }
        [SerializeField]
        [Range(1, 10)]
        private int puzzleDifficulty = 1;
        [SerializeField]
        [Range(10, 50)]
        private int ingredientsCount = 2;
        [SerializeField]
        [Range(0, 1024)]
        private float allottedTime = 0;

        public int RecipeDifficulty { get => puzzleDifficulty; }
        public int IngredientsCount { get => Math.Min(Enum.GetNames(typeof(Atom)).Length, ingredientsCount); }
        public float AllottedTime { get => allottedTime; }
    }
}
