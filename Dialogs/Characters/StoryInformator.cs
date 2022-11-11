using FirUnityEditor;
using UnityEngine;

public class StoryInformator : SinglBehaviour<StoryInformator>
{
    [NullCheck]
    public CharacterInformator Skull;
    [NullCheck]
    public CharacterInformator WhiteNecromant;
    [NullCheck]
    public CharacterInformator Yanus;
    [NullCheck]
    public CharacterInformator Archmagister;
    [NullCheck]
    public CharacterInformator Varus;
    [NullCheck]
    public CharacterInformator LordCarlos;
    [NullCheck]
    public CharacterInformator Karim;
    [NullCheck]
    public CharacterInformator GnomGuard;
    [NullCheck]
    public CharacterInformator Tiir;

    [Space]
    [NullCheck]
    public Sprite Lab;
    [NullCheck]
    public Sprite World;
    [NullCheck]
    public Sprite FirePlace;
    [NullCheck]
    public Sprite Memorial;
    [NullCheck]
    public Sprite Office;
    [NullCheck]
    public Sprite GnomeDoor;
    [NullCheck]
    public Sprite KarimRoom;
    [NullCheck]
    public Sprite Quarry;
    [NullCheck]
    public Sprite PortalOff;
    [NullCheck]
    public Sprite PortalOn;
    [NullCheck]
    public Sprite Castle;

    void Awake()
    {
        SingletoneCheck(this);
    }
}
