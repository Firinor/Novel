using UnityEngine;

namespace Puzzle.FindObject
{
    public class PuzzleInformator : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] alchemicalIngredientsSprites;
        public Sprite[] AlchemicalIngredientsSprites { get => alchemicalIngredientsSprites; }

        [SerializeField]
        private Sprite closedAlchemicalBox;
        public Sprite ClosedAlchemicalBox { get => closedAlchemicalBox; }

        [SerializeField]
        private Sprite openAlchemicalBox;
        public Sprite OpenAlchemicalBox { get => openAlchemicalBox; }

        [SerializeField]
        private RectTransform recipe;
    }
}
