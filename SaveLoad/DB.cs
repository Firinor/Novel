using System.Collections.Generic;
using UnityEngine;

public enum Languages { RU, EN }

public static class LanguagesManager
{
    public const int CountOfLanguages = 2;
}

public class DB : SinglBehaviour<DB>//Top-manager
{
    [SerializeField]
    private List<CharacterInformator> characters;

    void Awake()
    {
        SingletoneCheck(this);
    }
}