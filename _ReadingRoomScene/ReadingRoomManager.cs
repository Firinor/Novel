using System;
using UnityEngine;
using Puzzle;
using Puzzle.FindObject;
using Puzzle.TetraQuestion;
using Puzzle.FindDifferences;
using Puzzle.StarMap;

public enum ReadingRoomMarks { map, dialog, options, off,
    puzzleFindObject, puzzleTetraQuestion, puzzleFindDifferences, puzzleStarMap};

public class ReadingRoomManager : SinglBehaviour<ReadingRoomManager>, IScenePanel
{
    //private static GameObject map;
    private static GameObject dialog;
    private static GameObject puzzleFindObject;
    private static GameObject puzzleTetraQuestion;
    private static GameObject puzzleFindDifference;
    private static GameObject puzzleStarMap;
    private static FindObjectOperator puzzleFindObjectOperator;
    private static TetraQuestionOperator puzzleTetraQuestionOperator;
    private static FindDifferencesOperator puzzleFindDifferencesOperator;
    private static StarMapOperator puzzleStarMapOperator;

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
        puzzleFindDifference = ReadingRoomInformator.GetPuzzleFindDifferences();
        puzzleStarMap = ReadingRoomInformator.GetPuzzleStarMap();

        puzzleFindObjectOperator = ReadingRoomInformator.GetPuzzleFindObjectOperator();
        puzzleTetraQuestionOperator = ReadingRoomInformator.GetPuzzleTetraQuestionOperator();
        puzzleFindDifferencesOperator = ReadingRoomInformator.GetPuzzleFindDifferenceOperator();
        puzzleStarMapOperator = ReadingRoomInformator.GetPuzzleStarMapOperator();
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
            case ReadingRoomMarks.puzzleFindDifferences:
                puzzleFindDifference.SetActive(true);
                break;
            case ReadingRoomMarks.puzzleStarMap:
                puzzleStarMap.SetActive(true);
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
        puzzleFindDifference.SetActive(false);
        puzzleStarMap.SetActive(false);
        SceneManager.DiactiveAllPanels();
    }

    public void BasicPanelSettings()
    {
        SwitchPanels(ReadingRoomMarks.map);
    }

    public static void CheckMap(RectTransform dialogButtonRectTransform)
    {
        ReadingRoomInformator.GetMapCanvasOperator().CorrectScrollbarPosition(dialogButtonRectTransform);
    }

    internal static void SwithToPuzzle(InformationPackage puzzleInformationPackage)
    {
        switch (puzzleInformationPackage)
        {
            case FindRecipeIngredientsPackage findRecipeIngredients:
                puzzleFindObjectOperator.SetPuzzleInformationPackage(findRecipeIngredients);
                SwitchPanels(ReadingRoomMarks.puzzleFindObject);
                break;
            case TetraQuestionPackage tetraQuestion:
                puzzleTetraQuestionOperator.SetPuzzleInformationPackage(tetraQuestion);
                SwitchPanels(ReadingRoomMarks.puzzleTetraQuestion);
                break;
            case FindDifferencePackage findDifferenceImage:
                puzzleFindDifferencesOperator.SetPuzzleInformationPackage(findDifferenceImage);
                SwitchPanels(ReadingRoomMarks.puzzleFindDifferences);
                break;
            case StarMapPackage starMapPackage:
                puzzleStarMapOperator.SetPuzzleInformationPackage(starMapPackage);
                SwitchPanels(ReadingRoomMarks.puzzleStarMap);
                break;
            case null:
                break;
            default:
                break;
        }
        
    }
}
