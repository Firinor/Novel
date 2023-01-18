using FirParser;

namespace Characters
{
    public class CharacterStatus
    {
        public CharacterInformator Character;
        public CharacterEmotion Emotion;
        public ViewDirection viewDirection;
        public PositionOnTheStage position;

        public CharacterStatus(string position, string direction,
            string emotion, string character)
        {
            this.position = StringParser.ParseTo<PositionOnTheStage>(position);
            viewDirection = StringParser.ParseTo<ViewDirection>(direction);
            Emotion = StringParser.ParseTo<CharacterEmotion>(emotion);

            if (!string.IsNullOrEmpty(character))
            {
                Character = StringParser.NotSafeFindField<CharacterInformator>(
                    character, StoryInformator.instance.characters);
            }
            else Character = StoryInformator.instance.characters.None;
        }
    }
}
