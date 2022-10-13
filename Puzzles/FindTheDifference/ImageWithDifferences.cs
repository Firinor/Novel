using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
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
        private Sprite[] differences;
        public Sprite[] Differences { get => differences; }

        public ImageWithDifferences(Sprite sprite, Sprite[] differences)
        {
            this.sprite = sprite;
            this.differences = differences;
        }
    }
}
