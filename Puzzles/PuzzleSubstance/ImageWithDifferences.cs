﻿using System;
//using UnityEditor.U2D.Sprites;
using UnityEngine;

namespace Puzzle
{
    [CreateAssetMenu(menuName = "Puzzles/ImageWithDifferences", fileName = "new image with differences")]
    public class ImageWithDifferences : ScriptableObject
    {
        [SerializeField]
        private Sprite sprite;
        public Sprite Sprite { get => sprite; }

        [SerializeField]
        public Texture2D differencesTexture2D;

        [SerializeField]
        private DifferencesStruct[] differences;
        public DifferencesStruct[] Differences { get => differences; set => differences = value; }

        public ImageWithDifferences(Sprite sprite, DifferencesStruct[] differences)
        {
            this.sprite = sprite;
            this.differences = differences;
        }

        [ContextMenu("Fill numbers")]
        public void FillNumbers()
        {

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
