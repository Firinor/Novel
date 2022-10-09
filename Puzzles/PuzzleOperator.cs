using System.Collections.Generic;
using UnityEngine;

public class PuzzleOperator : MonoBehaviour
{
    protected bool puzzleFailed;
    [SerializeField]
    protected GameObject victoryButton;
    [SerializeField]
    protected GameObject failButton;

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
}
