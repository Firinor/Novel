using UnityEngine;

public enum PuzzleEnum {FindRecipeIngredients, FindСonstellation, AQuestionWithAnswers };

public abstract class PuzzleInformationPackage
{
    protected PuzzleInformationPackage(Sprite puzzleBackground, 
        DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
    {
        this.successPuzzleDialog = successPuzzleDialog;
        this.failedPuzzleDialog = failedPuzzleDialog;
        this.puzzleBackground = puzzleBackground;

        puzzleInformator = ReadingRoomInformator.GetPuzzleInformator();
    }

    public DialogNode successPuzzleDialog { get; }
    public DialogNode failedPuzzleDialog { get; }
    public Sprite puzzleBackground { get; }

    protected PuzzleInformator puzzleInformator { get; }
    
}

