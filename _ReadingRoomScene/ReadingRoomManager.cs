using System;
using UnityEngine;

public enum ReadingRoomMarks { map, dialog, puzzleFindObject, puzzleTetraQuestion, options, off };

public class ReadingRoomManager : SinglBehaviour<ReadingRoomManager>, IScenePanel
{
    //private static GameObject map;
    private static GameObject dialog;
    private static GameObject puzzleFindObject;
    private static GameObject puzzleTetraQuestion;
    private static PuzzleFindObjectOperator puzzleFindObjectOperator;
    private static PuzzleTetraQuestionOperator puzzleTetraQuestionOperator;

    private ReadingRoomInformator readingRoomInformator;

    public void SetAllInstance()
    {
        SingletoneCheck(this);
        SceneManager.ScenePanel = this;

        readingRoomInformator = GetComponent<ReadingRoomInformator>();
        readingRoomInformator.SingletoneCheck(readingRoomInformator);//Singltone

        //map = ReadingRoomInformator.GetMap();
        dialog = ReadingRoomInformator.GetDialog();
        puzzleFindObject = ReadingRoomInformator.GetPuzzleFindObject();
        puzzleTetraQuestion = ReadingRoomInformator.GetPuzzleTetraQuestion();
        puzzleFindObjectOperator = ReadingRoomInformator.GetPuzzleFindObjectOperator();
        puzzleTetraQuestionOperator = ReadingRoomInformator.GetPuzzleTetraQuestionOperator();
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
            case ReadingRoomMarks.puzzleFindObject:
                puzzleFindObject.SetActive(true);
                break;
            case ReadingRoomMarks.puzzleTetraQuestion:
                puzzleTetraQuestion.SetActive(true);
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
        puzzleFindObject.SetActive(false);
        puzzleTetraQuestion.SetActive(false);
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
        switch (puzzleInformationPackage)
        {
            case PuzzleFindRecipeIngredientsPackage findRecipeIngredients:
                puzzleFindObjectOperator.SetPuzzleInformationPackage(findRecipeIngredients);
                SwitchPanels(ReadingRoomMarks.puzzleFindObject);
                break;
            case PuzzleTetraQuestionPackage tetraQuestion:
                puzzleTetraQuestionOperator.SetPuzzleInformationPackage(tetraQuestion);
                SwitchPanels(ReadingRoomMarks.puzzleTetraQuestion);
                break;
            case null:
                break;
            default:
                break;
        }
        
    }
}
