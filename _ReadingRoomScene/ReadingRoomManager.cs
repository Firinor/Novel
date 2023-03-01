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
    #region Instances
    private static GameObject dialog
    {
        get
        {
            return DialogHUB.DialogObject.GetValue();
        }
    }
    private static GameObject puzzleFindObject
    {
        get
        {
            return PuzzleHUB.FindObject.GetValue();
        }
    }
    private static GameObject puzzleTetraQuestion
    {
        get
        {
            return PuzzleHUB.TetraQuestion.GetValue();
        }
    }
    private static GameObject puzzleFindDifference
    {
        get
        {
            return PuzzleHUB.FindDifference.GetValue();
        }
    }
    private static GameObject puzzleSearchObjects
    {
        get
        {
            return PuzzleHUB.SearchObjects.GetValue();
        }
    }
    private static GameObject puzzleSpectralAnalysis
    {
        get
        {
            return PuzzleHUB.SpectralAnalysis.GetValue();
        }
    }
    private static GameObject puzzleStarMap
    {
        get
        {
            return PuzzleHUB.StarMap.GetValue();
        }
    }
    private static GameObject puzzleBossBattle
    {
        get
        {
            return PuzzleHUB.BossBattle.GetValue();
        }
    }
    private static FindObjectManager puzzleFindObjectManager
    {
        get
        {
            return (FindObjectManager)PuzzleHUB.FindObjectManager.GetValue();
        }
    }
    private static TetraQuestionManager puzzleTetraQuestionManager
    {
        get
        {
            return (TetraQuestionManager)PuzzleHUB.TetraQuestionManager.GetValue();
        }
    }
    private static FindDifferencesManager puzzleFindDifferencesManager
    {
        get
        {
            return (FindDifferencesManager)PuzzleHUB.FindDifferencesManager.GetValue();
        }
    }
    private static SearchObjectsManager puzzleSearchObjectsManager
    {
        get
        {
            return (SearchObjectsManager)PuzzleHUB.SearchObjectsManager.GetValue();
        }
    }
    private static SpectralAnalysisManager puzzleSpectralAnalysisManager
    {
        get
        {
            return (SpectralAnalysisManager)PuzzleHUB.SpectralAnalysisManager.GetValue();
        }
    }
    private static StarMapManager puzzleStarMapManager
    {
        get
        {
            return (StarMapManager)PuzzleHUB.StarMapManager.GetValue();
        }
    }
    private static BossBattleManager puzzleBossBattleManager
    {
        get
        {
            return (BossBattleManager)PuzzleHUB.BossBattleManager.GetValue();
        }
    }
    private static MapCanvasOperator mapCanvasOperator
    {
        get
        {
            return (MapCanvasOperator)ReadingRoomHUB.MapCanvasOperator.GetValue();
        }
    }
    #endregion

    //private CanvasManager canvasManager;

    void Awake()
    {
        if(!(SceneManager.CurrentScene == SceneMarks.readingRoom
            || SceneManager.CurrentScene == SceneMarks.puzzles))
        {
            gameObject.SetActive(false);
        }
    }

    public void SetAllInstance()
    {
        SingletoneCheck(this);
        SceneHUB.ReadingRoomSceneManager.SetValue(this);
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
        mapCanvasOperator.CorrectScrollbarPosition(dialogButtonRectTransform);
    }

    public async void SwithToPuzzle(InformationPackage puzzleInformationPackage, string additional = "")
    {
        switch (puzzleInformationPackage)
        {
            case FindRecipeIngredientsPackage findRecipeIngredients:
                await MemoryManager.LoadScene(SceneMarks.findObject);
                puzzleFindObjectManager.SetPuzzleInformationPackage(findRecipeIngredients);
                SwitchPanels(ReadingRoomMarks.puzzleFindObject);
                break;
            case TetraQuestionPackage tetraQuestion:
                puzzleTetraQuestionManager.SetPuzzleInformationPackage(tetraQuestion);
                SwitchPanels(ReadingRoomMarks.puzzleTetraQuestion);
                break;
            case ImageWithDifferencesPackage findDifferenceImage:
                if(additional == "search")
                {
                    puzzleSearchObjectsManager.SetPuzzleInformationPackage(findDifferenceImage);
                    SwitchPanels(ReadingRoomMarks.puzzleSearchObjects);
                }
                else
                {
                    puzzleFindDifferencesManager.SetPuzzleInformationPackage(findDifferenceImage);
                    SwitchPanels(ReadingRoomMarks.puzzleFindDifferences);
                }
                break;
            case StarMapPackage starMapPackage:
                puzzleStarMapManager.SetPuzzleInformationPackage(starMapPackage);
                SwitchPanels(ReadingRoomMarks.puzzleStarMap);
                break;
            case SpectralAnalysisPackage spectralAnalysisPackage:
                puzzleSpectralAnalysisManager.SetPuzzleInformationPackage(spectralAnalysisPackage);
                SwitchPanels(ReadingRoomMarks.puzzleSpectralAnalysis);
                break;
            case BossBattlePackage bossBattlePackage:
                puzzleBossBattleManager.SetPuzzleInformationPackage(bossBattlePackage);
                SwitchPanels(ReadingRoomMarks.puzzleBossBattle);
                break;
            case null:
                break;
            default:
                break;
        }
        
    }
}
