using Puzzle.FindDifferences;
using Puzzle.FindObject;
using Puzzle.TetraQuestion;
using UnityEngine;

public class ReadingRoomInformator : SinglBehaviour<ReadingRoomInformator>
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject dialog;
    [SerializeField]
    private GameObject puzzleFindObject;
    [SerializeField]
    private GameObject puzzleTetraQuestion;
    [SerializeField]
    private GameObject puzzleFindDifferences;
    [SerializeField]
    private FindObjectOperator findObjectOperator;
    [SerializeField]
    private TetraQuestionOperator tetraQuestionOperator;
    [SerializeField]
    private FindDifferencesOperator findDifferencesOperator;
    [SerializeField]
    private PuzzleInformator puzzleInformator;
    [SerializeField]
    private MapCanvasOperator mapCanvasOperator;

    public static GameObject GetMap() => instance.map;
    public static GameObject GetDialog() => instance.dialog;
    public static GameObject GetPuzzleFindObject() => instance.puzzleFindObject;
    public static GameObject GetPuzzleTetraQuestion() => instance.puzzleTetraQuestion;
    public static GameObject GetPuzzleFindDifferences() => instance.puzzleFindDifferences;
    public static FindObjectOperator GetPuzzleFindObjectOperator() => instance.findObjectOperator;
    public static TetraQuestionOperator GetPuzzleTetraQuestionOperator() => instance.tetraQuestionOperator;
    public static FindDifferencesOperator GetFindDifferenceOperator() => instance.findDifferencesOperator;

    public static MapCanvasOperator GetMapCanvasOperator() => instance.mapCanvasOperator;
    public static PuzzleInformator GetPuzzleInformator() => instance.puzzleInformator;
}
