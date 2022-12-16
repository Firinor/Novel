using System.Collections.Generic;
using UnityEngine;

public enum Gender { Male, Female }
public enum DialogProgressStatus { Open, Closed, Hiden }
public enum HeroPredisposition { Warrior, Sage, Diplomat }

public class PlayerProgressController : MonoBehaviour
{
    public Gender HeroGender;
    public Dictionary<GameObject, DialogProgressStatus> DialogProgress;
    public HeroPredisposition HeroClass;
    public List<string> Events;

}
