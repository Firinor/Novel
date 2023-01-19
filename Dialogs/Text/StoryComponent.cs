using FirNovel.Characters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Story
{
    [Serializable]
    public class StoryComponent
    {
        public int Scene;
        public string Function;
        public Sprite Background;
        public CharacterInformator Character;
        public Dictionary<CharacterInformator, CharacterStatus> Characters;
        public string[] Text;
        public StoryComponent()
        {
            Scene = -1;
            Background = StoryInformator.instance.backgrounds.None;
        }
        private StoryComponent(string[] text)
        {
            Text = text;
        }
        public StoryComponent(int scene, Sprite background, CharacterInformator character,
            Dictionary<CharacterInformator, CharacterStatus> characters, string[] text) : this(text)
        {
            Scene = scene;
            Background = background;
            Character = character;
            Characters = characters;
        }
    }
}