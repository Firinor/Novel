using FirUnityEditor;
using Story;
using System;
using System.Collections.Generic;
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

    #region Story architecture
    [Serializable]
    public class FullStory
    {
        public List<Act> Acts;
        public Act this[int index]
        {
            get => Acts[index];
            set => Acts[index] = value;
        }

        public static implicit operator FullStory(List<List<List<StoryComponent>>> storyFromComponents)
        {
            List<Act> acts = new List<Act>();
            foreach (var act in storyFromComponents)
            {
                List<Episode> scenes = new List<Episode>();
                foreach (var scene in act)
                {
                    scenes.Add(scene);
                }
                acts.Add(scenes);
            }
            return new FullStory { Acts = acts };
        }
        public static implicit operator FullStory(List<List<Episode>> storyFromScenes)
        {
            List<Act> acts = new List<Act>();
            foreach (var act in storyFromScenes)
            {
                acts.Add(act);
            }
            return new FullStory() { Acts = acts };
        }
        public static implicit operator FullStory(List<Act> acts)
        {
            return new FullStory() { Acts = acts };
        }
    }
    [Serializable]
    public class Act
    {
        public List<Episode> Scenes;
        public Episode this[int index]
        {
            get => Scenes[index];
            set => Scenes[index] = value;
        }
        public int Count { get => Scenes.Count; }

        public static implicit operator Act(List<List<StoryComponent>> scenesFromComponents)
        {
            List<Episode> scenes = new List<Episode>();
            foreach (var scene in scenesFromComponents)
            {
                scenes.Add(scene);
            }
            return new Act() { Scenes = scenes };
        }
        public static implicit operator Act(List<Episode> scenes)
        {
            return new Act() { Scenes = scenes };
        }
    }
    [Serializable]
    public class Episode
    {
        public List<StoryComponent> Replicas;
        public List<MultiText> Choices;
        public int Count { get => Replicas.Count; }
        public StoryComponent this[int index]
        {
            get => Replicas[index];
            set => Replicas[index] = value;
        }

        public static implicit operator Episode(List<StoryComponent> replicas)
        {
            return new Episode() { Replicas = replicas };
        }

        internal void AddReplica(StoryComponent newReplica)
        {
            if(Replicas == null)
            {
                Replicas = new List<StoryComponent>();
            }
            Replicas.Add(newReplica);
        }

        internal void AddChoice(MultiText texts)
        {
            if (Choices == null)
            {
                Choices = new List<MultiText>();
            }
            Choices.Add(texts);
        }
    }
    #endregion

    [Serializable]
    public class Characters
    {
        [NullCheck]
        public CharacterInformator None;
        [NullCheck]
        public CharacterInformator Choise;
        [NullCheck]
        public CharacterInformator Narrator;
        [NullCheck]
        public CharacterInformator InessaSilently;
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
    public class Backgrounds
    {
        [NullCheck]
        public Sprite None;

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
        Story = StoryReader.GetFullStory(storyFiles, this);
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }
}