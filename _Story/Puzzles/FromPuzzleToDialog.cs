using FirUnityEditor;
using UnityEngine;

namespace Puzzle
{
    public class FromPuzzleToDialog : DialogNode
    {
        [SerializeField, NullCheck]
        private PuzzleOperator puzzleOperator;
        public override void StartDialog()
        {
            puzzleOperator.PuzzleExit();
            StartDialog(index: 0);
        }
    }
}
