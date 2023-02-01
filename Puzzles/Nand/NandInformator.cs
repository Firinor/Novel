using FirUnityEditor;
using UnityEngine;

namespace Puzzle.Nand
{
    public class NandInformator : MonoBehaviour
    {
        [SerializeField, NullCheck]
        private Sprite signal_0;
        [SerializeField, NullCheck]
        private Sprite signal_1;
        [SerializeField, NullCheck]
        private GameObject nand;
        [SerializeField]
        private Color onColor;
        public Color OnColor { get => onColor; }
        [SerializeField]
        private Color offColor;
        public Color OffColor { get => offColor; }

        [SerializeField, NullCheck]
        private Sprite onSprite;
        [SerializeField, NullCheck]
        private Sprite offSprite;

        public GameObject Nand { get => nand; }

        public Sprite GetSignalSprite(bool signal)
        {
            return signal ? onSprite : offSprite;
        }
    }
}
