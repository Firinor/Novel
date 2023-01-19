using FirParser;

namespace FirNovel.Characters
{
    public class CharacterStatus
    {
        public CharacterEmotion Emotion;
        public ViewDirection viewDirection;
        public PositionOnTheStage position;

        public CharacterStatus(string position, string direction,
            string emotion)
        {
            this.position = StringParser.ParseTo<PositionOnTheStage>(position);
            viewDirection = StringParser.ParseTo<ViewDirection>(direction);
            Emotion = StringParser.ParseTo<CharacterEmotion>(emotion);
        }
    }
}
