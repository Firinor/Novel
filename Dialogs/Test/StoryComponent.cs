using Codice.CM.Common;
using FirParser;
using System;
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

        private StoryComponent(string[] text)
        {
            Text = text;
        }
        public StoryComponent(int scene, Sprite background, PositionOnTheStage position, ViewDirection direction, CharacterEmotion emotion, CharacterInformator character, string[] text) : this(text)
        {
            Scene = scene;
            Background = background;
            Position = position;
            Direction = direction;
            Emotion = emotion;
            Character = character;
        }

        public StoryComponent(string scene, string background, string position, string direction, string emotion, string character, string[] text) : this(text)
        {
            Scene = int.Parse(scene);
            Background = StringParser.NotSafeFindField<Sprite>(
                background, StoryInformator.instance.backgrounds);
            Position = StringParser.ParseTo<PositionOnTheStage>(position);
            Direction = StringParser.ParseTo<ViewDirection>(direction);
            Emotion = StringParser.ParseTo<CharacterEmotion>(emotion);
            Character = StringParser.NotSafeFindField<CharacterInformator>(
                character, StoryInformator.instance.characters);
        }
    }
}