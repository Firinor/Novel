using FirUnityEditor;
using UnityEngine;

namespace Puzzle.Nand
{
    public class NandManager : PuzzleOperator
    {
        [SerializeField, NullCheck]
        private NandInformator nandInformator;
        [SerializeField, NullCheck]
        private RectTransform nandParent;
        [SerializeField, NullCheck]
        private RectTransform newNandTransform;

        [HideInInspector]
        public bool PointerOnField;

        public GameObject CreateNewNand()
        {
            var nand = Instantiate(nandInformator.Nand, newNandTransform);
            nand.transform.parent = nandParent;
            return nand;
        }
    }
}
