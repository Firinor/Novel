using System;
using UnityEngine;

public class ReadingRoomInformator : SinglBehaviour<ReadingRoomInformator>
{
    [SerializeField]
    private GameObject map;
    [SerializeField]
    private GameObject dialog;
    [SerializeField]
    private GameObject puzzle;
    [SerializeField]
    private PuzzleOperator puzzleOperator;
    [SerializeField]
    private PuzzleInformator puzzleInformator;
    [SerializeField]
    private MapCanvasOperator mapCanvasOperator;

    public static GameObject GetMap() => instance.map;
    public static GameObject GetDialog() => instance.dialog;
    public static GameObject GetPuzzle() => instance.puzzle;
    public static PuzzleOperator GetPuzzleOperator() => instance.puzzleOperator;

    public static MapCanvasOperator GetMapCanvasOperator() => instance.mapCanvasOperator;
    public static PuzzleInformator GetPuzzleInformator() => instance.puzzleInformator;
}
