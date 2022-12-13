using FirUnityEditor;
using System;
using UnityEngine;

public class StoryInformator : SinglBehaviour<StoryInformator>
{
    public Characters characters;
    public Backgrounds backgrounds;
    public SpecialImages specialImages;

    [Serializable]
    public class Characters
    {
        [NullCheck]
        public CharacterInformator Voice;
        [NullCheck]
        public CharacterInformator Skull;
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
    }

    [Serializable]
    public class Backgrounds
    {
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
        [NullCheck]
        public Sprite ThroneRoom;
        [NullCheck]
        public Sprite DesertPortalOn;
        [NullCheck]
        public Sprite Tents;
        [NullCheck]
        public Sprite BattleCamp;
        [NullCheck]
        public Sprite CommanderInChiefsTent;
        [NullCheck]
        public Sprite OrcEncampment;
        [NullCheck]
        public Sprite OrcCommanderInChiefsTent;
        [NullCheck]
        public Sprite Desert;
        [NullCheck]
        public Sprite OrcCamp;
    }
    [Serializable]
    public class SpecialImages
    {
        [NullCheck]
        public Sprite TwoDaysHavePassed;
        [NullCheck]
        public Sprite OrcParty;
        [NullCheck]
        public Sprite War;
    }


    void Awake()
    {
        SingletoneCheck(this);
    }
}