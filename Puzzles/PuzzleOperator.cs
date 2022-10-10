using UnityEngine;
using UnityEngine.UI;

public class PuzzleOperator : MonoBehaviour
{
    protected bool puzzleFailed;
    [SerializeField]
    protected GameObject victoryButton;
    [SerializeField]
    protected GameObject failButton;
    [SerializeField]
    protected Image backgroundImage;

    public virtual void PuzzleExit()
    {
        gameObject.SetActive(false);
    }
    public virtual void LosePuzzle()
    {
        puzzleFailed = true;
        failButton.SetActive(true);
    }
    public virtual void Options()
    {
        ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
    }
    public virtual void ClearPuzzle()
    {
        victoryButton.SetActive(false);
        failButton.SetActive(false);
        puzzleFailed = false;
    }
    public virtual void StartPuzzle()
    {
        
    }

    public virtual void SuccessfullySolvePuzzle()
    {
        victoryButton.SetActive(true);
    }

    protected virtual void SetVictoryDialogNode(DialogNode dialogNode)
    {
        victoryButton.GetComponent<FromPuzzleToDialog>().AddChoice(dialogNode);
    }
    protected virtual void SetFailDialogNode(DialogNode dialogNode)
    {
        failButton.GetComponent<FromPuzzleToDialog>().AddChoice(dialogNode);
    }
    protected virtual void SetBackground(Sprite sprite)
    {
        backgroundImage.sprite = sprite;
    }
}
