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

        public GameObject Nand { get => nand; }
    }
}
