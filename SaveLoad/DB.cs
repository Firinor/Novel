using System.Collections.Generic;
using UnityEngine;

public enum Languages { RU, EN }

public class DB : SinglBehaviour<DB>//Top-manager
{
    [SerializeField]
    private List<CharacterInformator> characters;

    void Awake()
    {
        SingletoneCheck(this);
    }
}