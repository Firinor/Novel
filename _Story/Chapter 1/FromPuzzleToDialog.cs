using UnityEngine;

public class FromPuzzleToDialog : DialogNode
{
    [SerializeField]
    private PuzzleFindObjectOperator puzzleOperator;
    public override void StartDialog()
    {
        puzzleOperator.PuzzleExit();
        StartDialog(index: 0);
    }
}
