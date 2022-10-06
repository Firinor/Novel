using System;
using UnityEngine;

public enum ReadingRoomMarks { map, dialog, puzzle, options, off };

public class ReadingRoomManager : SinglBehaviour<ReadingRoomManager>, IScenePanel
{
    private static GameObject map;
    private static GameObject dialog;
    private static GameObject puzzle;
    private static PuzzleFindObjectOperator puzzleOperator;

    private ReadingRoomInformator readingRoomInformator;

    public void SetAllInstance()
    {
        SingletoneCheck(this);
        SceneManager.ScenePanel = this;

        readingRoomInformator = GetComponent<ReadingRoomInformator>();
        readingRoomInformator.SingletoneCheck(readingRoomInformator);//Singltone

        map = ReadingRoomInformator.GetMap();
        dialog = ReadingRoomInformator.GetDialog();
        puzzle = ReadingRoomInformator.GetPuzzle();
        puzzleOperator = ReadingRoomInformator.GetPuzzleOperator();
    }

    public static void SwitchPanels(ReadingRoomMarks mark)
    {
        if(mark != ReadingRoomMarks.options)
            instance.DiactiveAllPanels();

        switch (mark)
        {
            case ReadingRoomMarks.map:
                //map.SetActive(true);
                break;
            case ReadingRoomMarks.dialog:
                dialog.SetActive(true);
                break;
            case ReadingRoomMarks.puzzle:
                puzzle.SetActive(true);
                break;
            case ReadingRoomMarks.options:
                SceneManager.SwitchPanels(SceneDirection.options);
                break;
            case ReadingRoomMarks.off:
                break;
            default:
                new Exception("Unrealized bookmark!");
                break;
        }
    }

    public void SwitchPanels(int mark)
    {
        SwitchPanels((ReadingRoomMarks)mark);
    }

    public void DiactiveAllPanels()
    {
        //map.SetActive(false);
        dialog.SetActive(false);
        puzzle.SetActive(false);
        SceneManager.DiactiveAllPanels();
    }

    public void BasicPanelSettings()
    {
        SwitchPanels(ReadingRoomMarks.map);
    }

    public static void CheckMap(float dialogButtonXPosition)
    {
        ReadingRoomInformator.GetMapCanvasOperator().CorrectScrollbarPosition(dialogButtonXPosition);
    }

    internal static void SwithToPuzzle(PuzzleInformationPackage puzzleInformationPackage)
    {
        puzzleOperator.SetPuzzleInformationPackage(puzzleInformationPackage);
        SwitchPanels(ReadingRoomMarks.puzzle);
    }
}
