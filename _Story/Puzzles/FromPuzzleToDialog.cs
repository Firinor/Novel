using Puzzle;
using UnityEngine;

public class FromPuzzleToDialog : DialogNode
{
    [SerializeField]
    private PuzzleOperator puzzleOperator;
    public override void StartDialog()
    {
        puzzleOperator.PuzzleExit();
        StartDialog(index: 0);
    }
}
