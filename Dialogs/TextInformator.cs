using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text", fileName = "text")]
public class TextInformator : ScriptableObject
{
    public Languages language;
    [Multiline]
    public string text;
}
