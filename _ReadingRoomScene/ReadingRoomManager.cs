using System;
using UnityEngine;
using Puzzle;
using Puzzle.FindObject;
using Puzzle.TetraQuestion;
using Puzzle.FindDifferences;
using Puzzle.StarMap;
using Puzzle.SearchObjects;
using Puzzle.BossBattle;
using Puzzle.PortalBuild;

public enum ReadingRoomMarks { map, dialog, options, off,
    puzzleFindObject, puzzleTetraQuestion, puzzleFindDifferences, puzzleSearchObjects,
    puzzleSpectralAnalysis, puzzleDNA, puzzleNand, puzzleChemical, puzzleStarMap, puzzleBossBattle
};

public class ReadingRoomManager : SinglBehaviour<ReadingRoomManager>, IScenePanel, IReadingSceneManager
{
    //private static GameObject map;
    private static GameObject dialog;
    private static GameObject puzzleFindObject;
    private static GameObject puzzleTetraQuestion;
    private static GameObject puzzleFindDifference;
    private static GameObject puzzleSearchObjects;
    private static GameObject puzzleSpectralAnalysis;
    private static GameObject puzzleStarMap;
    private static GameObject puzzleBossBattle;
    private static FindObjectManager puzzleFindObjectOperator;
    private static TetraQuestionManager puzzleTetraQuestionOperator;
    private static FindDifferencesManager puzzleFindDifferencesOperator;
    private static SearchObjectsManager puzzleSearchObjectsOperator;
    private static SpectralAnalysisManager puzzleSpectralAnalysisOperator;
    private static StarMapManager puzzleStarMapOperator;
    private static BossBattleManager puzzleBossBattleOperator;

    private ReadingRoomInformator readingRoomInformator;
    //private CanvasManager canvasManager;

    public void SetAllInstance()
    {
        SingletoneCheck(this);
        SceneManager.ScenePanel = this;

        readingRoomInformator = GetComponent<ReadingRoomInformator>();
        readingRoomInformator.SingletoneCheck(readingRoomInformator);//Singltone

        //canvasManager = GetComponent<CanvasManager>();
        //canvasManager.SingletoneCheck(canvasManager);

        //map = ReadingRoomInformator.GetMap();
        dialog = ReadingRoomInformator.GetDialog();

        puzzleFindObject = ReadingRoomInformator.GetPuzzleFindObject();
        puzzleTetraQuestion = ReadingRoomInformator.GetPuzzleTetraQuestion();
        puzzleFindDifference = ReadingRoomInformator.GetPuzzleFindDifferences();
        puzzleSearchObjects = ReadingRoomInformator.GetPuzzleSearchObjects();
        puzzleSpectralAnalysis = ReadingRoomInformator.GetPuzzleSpectralAnalysis();
        puzzleStarMap = ReadingRoomInformator.GetPuzzleStarMap();
        puzzleBossBattle = ReadingRoomInformator.GetPuzzleBossBattle();

        puzzleFindObjectOperator = ReadingRoomInformator.GetPuzzleFindObjectManager();
        puzzleTetraQuestionOperator = ReadingRoomInformator.GetPuzzleTetraQuestionManager();
        puzzleFindDifferencesOperator = ReadingRoomInformator.GetPuzzleFindDifferenceManager();
        puzzleSearchObjectsOperator = ReadingRoomInformator.GetPuzzleSearchObjectsManager();
        puzzleSpectralAnalysisOperator = ReadingRoomInformator.GetPuzzleSpectralAnalysisManager();
        puzzleStarMapOperator = ReadingRoomInformator.GetPuzzleStarMapManager();
        puzzleBossBattleOperator = ReadingRoomInformator.GetPuzzleBossBattleManager();
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
            case ReadingRoomMarks.puzzleSearchObjects:
                puzzleSearchObjects.SetActive(true);
                break;
            case ReadingRoomMarks.puzzleSpectralAnalysis:
                puzzleSpectralAnalysis.SetActive(true);
                break;
            case ReadingRoomMarks.puzzleStarMap:
                puzzleStarMap.SetActive(true);
                break;
            case ReadingRoomMarks.puzzleBossBattle:
                puzzleStarMap.SetActive(true);
                break;
            case ReadingRoomMarks.options:
                SceneManager.SwitchPanel(SceneDirection.options);
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
    public void SwitchPanelsToOptions()
    {
        SwitchPanels(ReadingRoomMarks.options);
    }
    public void DiactiveAllPanels()
    {
        //map.SetActive(false);
        dialog.SetActive(false);
        puzzleFindObject.SetActive(false);
        puzzleTetraQuestion.SetActive(false);
        puzzleFindDifference.SetActive(false);
        puzzleSearchObjects.SetActive(false);
        puzzleSpectralAnalysis.SetActive(false);
        puzzleStarMap.SetActive(false);
        puzzleBossBattle.SetActive(false);
        SceneManager.DiactiveAllPanels();
    }

    public void BasicPanelSettings()
    {
        SwitchPanels(ReadingRoomMarks.map);
    }

    public void CheckMap(RectTransform dialogButtonRectTransform)
    {
        ReadingRoomInformator.GetMapCanvasOperator().CorrectScrollbarPosition(dialogButtonRectTransform);
    }

    public void SwithToPuzzle(InformationPackage puzzleInformationPackage, string additional = "")
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
            case ImageWithDifferencesPackage findDifferenceImage:
                if(additional == "search")
                {
                    puzzleSearchObjectsOperator.SetPuzzleInformationPackage(findDifferenceImage);
                    SwitchPanels(ReadingRoomMarks.puzzleSearchObjects);
                }
                else
                {
                    puzzleFindDifferencesOperator.SetPuzzleInformationPackage(findDifferenceImage);
                    SwitchPanels(ReadingRoomMarks.puzzleFindDifferences);
                }
                break;
            case StarMapPackage starMapPackage:
                puzzleStarMapOperator.SetPuzzleInformationPackage(starMapPackage);
                SwitchPanels(ReadingRoomMarks.puzzleStarMap);
                break;
            case SpectralAnalysisPackage spectralAnalysisPackage:
                puzzleSpectralAnalysisOperator.SetPuzzleInformationPackage(spectralAnalysisPackage);
                SwitchPanels(ReadingRoomMarks.puzzleSpectralAnalysis);
                break;
            case BossBattlePackage bossBattlePackage:
                puzzleBossBattleOperator.SetPuzzleInformationPackage(bossBattlePackage);
                SwitchPanels(ReadingRoomMarks.puzzleBossBattle);
                break;
            case null:
                break;
            default:
                break;
        }
        
    }
}
