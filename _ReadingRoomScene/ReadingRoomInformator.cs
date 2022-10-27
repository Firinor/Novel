using FirUnityEditor;
using Puzzle.FindDifferences;
using Puzzle.FindObject;
using Puzzle.StarMap;
using Puzzle.TetraQuestion;
using System;
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
    private GameObject puzzleStarMap;
    [SerializeField, NullCheck]
    private FindObjectOperator findObjectOperator;
    [SerializeField, NullCheck]
    private TetraQuestionOperator tetraQuestionOperator;
    [SerializeField, NullCheck]
    private FindDifferencesOperator findDifferencesOperator;
    [SerializeField, NullCheck]
    private StarMapOperator starMapOperator;
    [SerializeField, NullCheck]
    private PuzzleInformator puzzleInformator;
    [SerializeField, NullCheck]
    private MapCanvasOperator mapCanvasOperator;

    public static GameObject GetMap() => instance.map;
    public static GameObject GetDialog() => instance.dialog;

    public static GameObject GetPuzzleFindObject() => instance.puzzleFindObject;
    public static GameObject GetPuzzleTetraQuestion() => instance.puzzleTetraQuestion;
    public static GameObject GetPuzzleFindDifferences() => instance.puzzleFindDifferences;
    public static GameObject GetPuzzleStarMap() => instance.puzzleStarMap;
    public static FindObjectOperator GetPuzzleFindObjectOperator() => instance.findObjectOperator;
    public static TetraQuestionOperator GetPuzzleTetraQuestionOperator() => instance.tetraQuestionOperator;
    public static FindDifferencesOperator GetPuzzleFindDifferenceOperator() => instance.findDifferencesOperator;
    public static StarMapOperator GetPuzzleStarMapOperator() => instance.starMapOperator;

    public static MapCanvasOperator GetMapCanvasOperator() => instance.mapCanvasOperator;
    public static PuzzleInformator GetPuzzleInformator() => instance.puzzleInformator;
}
