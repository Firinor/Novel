﻿using System;
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
        private DifferencesStruct[] differences;
        public DifferencesStruct[] Differences { get => differences; }

        public ImageWithDifferences(Sprite sprite, DifferencesStruct[] differences)
        {
            this.sprite = sprite;
            this.differences = differences;
        }

        [Serializable]
        public struct DifferencesStruct
        {
            public Sprite sprite;
            public int xShift;
            public int yShift;

            public DifferencesStruct(Sprite sprite, Vector2 size)
            {
                this.sprite = sprite;
                xShift = (int)size.x;
                yShift = (int)size.y;
            }
        }
    }
}
