using FirUnityEditor;
using UnityEngine;

public class StoryInformator : SinglBehaviour<StoryInformator>
{
    [NullCheck]
    public CharacterInformator Voice;
    [NullCheck]
    public CharacterInformator Skull;
    [NullCheck]
    public CharacterInformator WhiteNecromant;
    [NullCheck]
    public CharacterInformator Yanus;
    [NullCheck]
    public CharacterInformator Archmagister;
    [NullCheck]
    public CharacterInformator Vargus;
    [NullCheck]
    public CharacterInformator LordCarlos;
    [NullCheck]
    public CharacterInformator Karim;
    [NullCheck]
    public CharacterInformator GnomGuard;
    [NullCheck]
    public CharacterInformator HumanGuard;
    [NullCheck]
    public CharacterInformator Tiir;
    [NullCheck]
    public CharacterInformator Ermingarda;
    [NullCheck]
    public CharacterInformator Arguz;
    [NullCheck]
    public CharacterInformator Vacela;
    [NullCheck]
    public CharacterInformator Bathyard;
    [NullCheck]
    public CharacterInformator Nogation;
    [NullCheck]
    public CharacterInformator Hurga;
    [NullCheck]
    public CharacterInformator Mercenary;
    [NullCheck]
    public CharacterInformator MagicianElector;


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
    [NullCheck]
    public Sprite Fun;
    [NullCheck]
    public Sprite Prison;
    [NullCheck]
    public Sprite Prisoners—ell;
    [NullCheck]
    public Sprite BeginOfElvenForest;
    [NullCheck]
    public Sprite ElvenHut;
    [NullCheck]
    public Sprite TiirRoom;
    [NullCheck]
    public Sprite ElvenPalace;
    [NullCheck]
    public Sprite AtElvenPalace;
    [NullCheck]
    public Sprite AtElvenPalace2;

    [Space]
    [NullCheck]
    public Sprite TwoDaysHavePassed;


    void Awake()
    {
        SingletoneCheck(this);
    }
}
