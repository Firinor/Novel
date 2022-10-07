using System;
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
    private PuzzleFindObjectOperator puzzleFindObjectOperator;
    [SerializeField]
    private PuzzleTetraQuestionOperator puzzleTetraQuestionOperator;
    [SerializeField]
    private PuzzleInformator puzzleInformator;
    [SerializeField]
    private MapCanvasOperator mapCanvasOperator;

    public static GameObject GetMap() => instance.map;
    public static GameObject GetDialog() => instance.dialog;
    public static GameObject GetPuzzleFindObject() => instance.puzzleFindObject;
    public static GameObject GetPuzzleTetraQuestion() => instance.puzzleTetraQuestion;
    public static PuzzleFindObjectOperator GetPuzzleFindObjectOperator() => instance.puzzleFindObjectOperator;
    public static PuzzleTetraQuestionOperator GetPuzzleTetraQuestionOperator() => instance.puzzleTetraQuestionOperator;

    public static MapCanvasOperator GetMapCanvasOperator() => instance.mapCanvasOperator;
    public static PuzzleInformator GetPuzzleInformator() => instance.puzzleInformator;
}
