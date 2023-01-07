using FirUnityEditor;
using Puzzle.BossBattle;
using Puzzle.FindDifferences;
using Puzzle.FindObject;
using Puzzle.PortalBuild;
using Puzzle.SearchObjects;
using Puzzle.StarMap;
using Puzzle.TetraQuestion;
using UnityEngine;

public class ReadingRoomInformator : SinglBehaviour<ReadingRoomInformator>
{
    [SerializeField, NullCheck]
    private GameObject map;
    [SerializeField, NullCheck]
    private GameObject dialog;
    [SerializeField, NullCheck]
    private GameObject puzzleFindObject;
    [SerializeField, NullCheck]
    private GameObject puzzleTetraQuestion;
    [SerializeField, NullCheck]
    private GameObject puzzleFindDifferences;
    [SerializeField, NullCheck]
    private GameObject puzzleSearchObjects;
    [SerializeField, NullCheck]
    private GameObject puzzleSpectralAnalysis;
    [SerializeField, NullCheck]
    private GameObject puzzleStarMap;
    [SerializeField, NullCheck]
    private GameObject puzzleBossBattle;
    [SerializeField, NullCheck]
    private FindObjectManager findObjectManager;
    [SerializeField, NullCheck]
    private TetraQuestionManager tetraQuestionManager;
    [SerializeField, NullCheck]
    private FindDifferencesManager findDifferencesManager;
    [SerializeField, NullCheck]
    private SearchObjectsManager searchObjectsManager;
    [SerializeField, NullCheck]
    private SpectralAnalysisManager spectralAnalysisManager;
    [SerializeField, NullCheck]
    private StarMapManager starMapManager;
    [SerializeField, NullCheck]
    private BossBattleManager bossBattleManager;
    [SerializeField, NullCheck]
    private PuzzleInformator puzzleInformator;
    [SerializeField, NullCheck]
    private MapCanvasOperator mapCanvasOperator;
    public static GameObject GetMap() => instance.map;
    public static GameObject GetDialog() => instance.dialog;

    public static GameObject GetPuzzleFindObject() => instance.puzzleFindObject;
    public static GameObject GetPuzzleTetraQuestion() => instance.puzzleTetraQuestion;
    public static GameObject GetPuzzleFindDifferences() => instance.puzzleFindDifferences;
    public static GameObject GetPuzzleSearchObjects() => instance.puzzleSearchObjects;
    public static GameObject GetPuzzleSpectralAnalysis() => instance.puzzleSpectralAnalysis;
    public static GameObject GetPuzzleStarMap() => instance.puzzleStarMap;
    public static GameObject GetPuzzleBossBattle() => instance.puzzleBossBattle;

    public static FindObjectManager GetPuzzleFindObjectManager() => instance.findObjectManager;
    public static TetraQuestionManager GetPuzzleTetraQuestionManager() => instance.tetraQuestionManager;
    public static FindDifferencesManager GetPuzzleFindDifferenceManager() => instance.findDifferencesManager;
    public static SearchObjectsManager GetPuzzleSearchObjectsManager() => instance.searchObjectsManager;
    public static SpectralAnalysisManager GetPuzzleSpectralAnalysisManager() => instance.spectralAnalysisManager;
    public static StarMapManager GetPuzzleStarMapManager() => instance.starMapManager;
    public static BossBattleManager GetPuzzleBossBattleManager() => instance.bossBattleManager;

    public static MapCanvasOperator GetMapCanvasOperator() => instance.mapCanvasOperator;
    public static PuzzleInformator GetPuzzleInformator() => instance.puzzleInformator;
}
