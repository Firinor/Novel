public enum PuzzleEnum {FindRecipeIngredients, FindСonstellation, AQuestionWithAnswers };

public abstract class PuzzleInformationPackage
{
    protected PuzzleInformationPackage(DialogNode successPuzzleDialog, DialogNode failedPuzzleDialog = null)
    {
        this.successPuzzleDialog = successPuzzleDialog;
        this.failedPuzzleDialog = failedPuzzleDialog;

        puzzleInformator = ReadingRoomInformator.GetPuzzleInformator();
    }

    public DialogNode successPuzzleDialog { get; }
    public DialogNode failedPuzzleDialog { get; }

    protected PuzzleInformator puzzleInformator { get; }
}

