using FirParser;
using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Story
{
    [Serializable]
    public class StoryComponent
    {
        public int Scene;
        public Sprite Background;
        public PositionOnTheStage Position;
        public ViewDirection Direction;
        public CharacterEmotion Emotion;
        public CharacterInformator Character;
        public string[] Text;
        public StoryComponent()
        {
            Scene = -1;
            Background = StoryInformator.instance.backgrounds.None;
            Character = StoryInformator.instance.characters.None;
        }
        private StoryComponent(string[] text)
        {
            Text = text;
        }
        public StoryComponent(int scene, Sprite background, PositionOnTheStage position,
            ViewDirection direction, CharacterEmotion emotion,
            CharacterInformator character, string[] text) : this(text)
        {
            Scene = scene;
            Background = background;
            Position = position;
            Direction = direction;
            Emotion = emotion;
            Character = character;
        }

        public void SetValues(string scene, string background, string position, string direction,
            string emotion, string character, string[] text)
        {
            Scene = string.IsNullOrEmpty(scene) ? -1 : int.Parse(scene);

            if (!string.IsNullOrEmpty(background))
            {
                Background = StringParser.NotSafeFindField<Sprite>(
                    background, StoryInformator.instance.backgrounds);
            }
            else Background = StoryInformator.instance.backgrounds.None;

            Position = StringParser.ParseTo<PositionOnTheStage>(position);
            Direction = StringParser.ParseTo<ViewDirection>(direction);
            Emotion = StringParser.ParseTo<CharacterEmotion>(emotion);

            if (!string.IsNullOrEmpty(character))
            {
                Character = StringParser.NotSafeFindField<CharacterInformator>(
                    character, StoryInformator.instance.characters);
            }
            else Character = StoryInformator.instance.characters.None;

            Text = text;
        }

        internal Task Action()
        {
            throw new NotImplementedException();
        }
    }
}