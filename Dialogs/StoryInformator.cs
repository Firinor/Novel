using FirStory;
using FirUnityEditor;
using System;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StoryInformator : SinglBehaviour<StoryInformator>
{
    public Characters characters;
    public Backgrounds backgrounds;
    [SerializeField]
    private TextAsset[] storyFiles;
    [SerializeField]
    private FullStory Story;
    
    private const int StoryActCount = 7;

    public Episode GetScene(int act, int scene)
    {
        if (act > StoryActCount || act < 1)
            throw new Exception($"There is no act with number \"{act}\" in the history!");

        if (scene > Story[act - 1].Count || scene < 1)
            throw new Exception($"There is no scene with number \"{scene}\" in the act \"{act}\"!");

        return Story[act - 1][scene - 1];
    }

    [Serializable]
    public class Characters : ICharacters
    {
        [NullCheck]
        public string narrator;
        [NullCheck]
        public string silently;
        public string Narrator => narrator;
        public string Silently => silently;

        [NullCheck]
        public CharacterInformator Error;
        CharacterInformator ICharacters.None => Error;

        [NullCheck]
        public CharacterInformator Inessa;
        [NullCheck]
        public CharacterInformator Graugalorafor;
        [NullCheck]
        public CharacterInformator Cristopher;
        [NullCheck]
        public CharacterInformator Vargus;
        [NullCheck]
        public CharacterInformator Karim;
        [NullCheck]
        public CharacterInformator Guard;
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
        public CharacterInformator Mage;

        
    }

    [Serializable]
    public class Backgrounds : IBackgrounds
    {
        [NullCheck]
        public Sprite Error;
        Sprite IBackgrounds.None => Error;

        #region Main backgrounds
        [NullCheck]
        public Sprite Lab;
        [NullCheck]
        public Sprite World;
        [NullCheck]
        public Sprite InessaRoom;
        [NullCheck]
        public Sprite Black;
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
        #endregion //Main backgrounds

        #region Spesial backgrounds
        [NullCheck]
        public Sprite TwoDaysHavePassed;
        [NullCheck]
        public Sprite OrcParty;
        [NullCheck]
        public Sprite War;
        #endregion //Spesial backgrounds
    }

    void Awake()
    {
        SingletoneCheck(this);
    }

    [ContextMenu("ReadFullStory")]
    private void GetStory()
    {
        Story = StoryReader.GetFullStory(storyFiles, characters, backgrounds);
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}