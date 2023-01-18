using Characters;
using FirParser;
using System;
using UnityEngine;

namespace Story
{
    [Serializable]
    public class StoryComponent
    {
        public int Scene;
        public string Function;
        public Sprite Background;
        public CharacterStatus[] Characters;
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
        public StoryComponent(int scene, Sprite background,
            CharacterStatus[] characters, string[] text) : this(text)
        {
            Scene = scene;
            Background = background;
            Characters = characters;
        }

        public void SetValues(string scene, string background, CharacterStatus[] characters, string[] text)
        {
            Scene = string.IsNullOrEmpty(scene) ? -1 : int.Parse(scene);

            if (!string.IsNullOrEmpty(background))
            {
                Background = StringParser.NotSafeFindField<Sprite>(
                    background, StoryInformator.instance.backgrounds);
            }
            else Background = StoryInformator.instance.backgrounds.None;

            Characters = characters;

            Text = text;
        }
    }
}