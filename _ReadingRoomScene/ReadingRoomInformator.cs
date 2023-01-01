using FirUnityEditor;
using Puzzle.BossBattle;
using Puzzle.FindDifferences;
using Puzzle.FindObject;
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
    private GameObject puzzleStarMap;
    [SerializeField, NullCheck]
    private GameObject puzzleBossBattle;
    [SerializeField, NullCheck]
    private FindObjectManager findObjectOperator;
    [SerializeField, NullCheck]
    private TetraQuestionManager tetraQuestionOperator;
    [SerializeField, NullCheck]
    private FindDifferencesManager findDifferencesOperator;
    [SerializeField, NullCheck]
    private SearchObjectsManager searchObjectsOperator;
    [SerializeField, NullCheck]
    private StarMapManager starMapOperator;
    [SerializeField, NullCheck]
    private BossBattleManager bossBattleOperator;
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
    public static GameObject GetPuzzleStarMap() => instance.puzzleStarMap;
    public static GameObject GetPuzzleBossBattle() => instance.puzzleBossBattle;

    public static FindObjectManager GetPuzzleFindObjectOperator() => instance.findObjectOperator;
    public static TetraQuestionManager GetPuzzleTetraQuestionOperator() => instance.tetraQuestionOperator;
    public static FindDifferencesManager GetPuzzleFindDifferenceOperator() => instance.findDifferencesOperator;
    public static SearchObjectsManager GetPuzzleSearchObjectsOperator() => instance.searchObjectsOperator;
    public static StarMapManager GetPuzzleStarMapOperator() => instance.starMapOperator;
    public static BossBattleManager GetPuzzleBossBattleOperator() => instance.bossBattleOperator;

    public static MapCanvasOperator GetMapCanvasOperator() => instance.mapCanvasOperator;
    public static PuzzleInformator GetPuzzleInformator() => instance.puzzleInformator;

}
