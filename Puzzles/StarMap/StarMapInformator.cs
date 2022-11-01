using Puzzle.StarMap;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMapInformator : MonoBehaviour
{
    public ConstellationsVariant[] Constellations;
    [SerializeField]
    public KeyValuePair<string, Sprite>[] KeyConstellation;
}

[Serializable]
public class ConstellationsVariant
{
    public Hemisphere Hemisphere;
    [SerializeField]
    public KeyValuePair<string, Sprite>[] AnswerConstellation;
}