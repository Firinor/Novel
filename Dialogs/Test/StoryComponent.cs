using System;
using UnityEngine;

namespace Story
{
    [Serializable]
    public class StoryComponent
    {
        public int Act;
        public Sprite Scene;
        public PositionOnTheStage Position;
        public ViewDirection Direction;
        public CharacterEmotion Emotion;
        public CharacterInformator Character;
        public const int TEXT_COLLUM = 6;
        public string[] Text;

        private StoryComponent(string[] text)
        {
            Text = text;
        }
        public StoryComponent(int act, Sprite scene, PositionOnTheStage position, ViewDirection direction, CharacterEmotion emotion, CharacterInformator character, string[] text) : this(text)
        {
            Act = act;
            Scene = scene;
            Position = position;
            Direction = direction;
            Emotion = emotion;
            Character = character;
        }

        public StoryComponent(string act, string scene, string position, string direction, string emotion, string character, string[] text) : this(text)
        {
            Act = int.Parse(act);
            //Scene = scene;
            //Position = position;
            //Direction = direction;
            //Emotion = emotion;
            //Character = character;
        }
    }
}