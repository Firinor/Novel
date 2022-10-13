using Puzzle;
using UnityEngine;

public class FindDifferencePuzzle : DialogNode
{
    [SerializeField]
    private DialogNode successPuzzleDialog;
    [SerializeField]
    private DialogNode failedPuzzleDialog;
    [SerializeField]
    private Sprite puzzleBackground;
    [SerializeField]
    private FindDifferencePackage puzzlePackage;

    public override void StartDialog()
    {
        FindDifferencePackage puzzleFindDifferencePackage
            = new FindDifferencePackage(
                puzzlePackage.DifferenceCount,
                puzzlePackage.AllottedTime,
                puzzleBackground,
                successPuzzleDialog);
        DialogOperator.SwithToPuzzle(puzzleFindDifferencePackage);
    }
}
