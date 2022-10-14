using System;
using UnityEngine;

namespace Puzzle.FindDifferences
{
    [CreateAssetMenu(menuName = "Puzzles/ImageWithDifferences", fileName = "new image with differences")]
    public class ImageWithDifferences : ScriptableObject
    {
        [SerializeField]
        private Sprite sprite;
        public Sprite Sprite { get => sprite; }

        [SerializeField]
        private Image[] differences;
        public Image[] Differences { get => differences; }

        public ImageWithDifferences(Sprite sprite, Image[] differences)
        {
            this.sprite = sprite;
            this.differences = differences;
        }

        [Serializable]
        public struct Image
        {
            public Sprite sprite;
            public int xShift;
            public int yShift;

            public Image(Sprite sprite, Vector2 size)
            {
                this.sprite = sprite;
                xShift = (int)size.x;
                yShift = (int)size.y;
            }
        }
    }
}
