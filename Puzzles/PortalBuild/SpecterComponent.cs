using System;
using UnityEngine;

namespace Puzzle.PortalBuild
{
    [Serializable]
    public class SpecterComponent
    {
        [SerializeField]
        private string designation;
        [SerializeField]
        private Color color;
        [SerializeField]
        private Sprite sprite;

        public string Designation { get => designation; }
        public Color Color { get => color; }
        public Sprite Sprite { get => sprite; }

    }
}
