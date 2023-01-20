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
        public StoryComponent(int scene, string function, Sprite background, CharacterInformator character,
            Dictionary<CharacterInformator, CharacterStatus> characters, string[] text)
        {
            Scene = scene;
            Function = function;
            Background = background;
            Character = character;
            Characters = characters;
            Text = text;
        }

        public void AddCharacter(CharacterInformator Character, CharacterStatus characterStatus)
        {
            if (Characters.ContainsKey(Character))
            {
                Characters[Character] = characterStatus;
            }
            else
            {
                Characters.Add(Character, characterStatus);
            }
        }

        public void RemoveCharacter(CharacterInformator Character)
        {
            if (Characters.ContainsKey(Character))
            {
                Characters.Remove(Character);
            }
        }
    }
}