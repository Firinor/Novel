using FirMath;
using System;
using System.Collections.Generic;

namespace Puzzle.TetraQuestion
{
    [Serializable]
    public class QuestionsQueue
    {
        public List<QuestionVariant> questionsQueue;

        public int Length => questionsQueue.Count;

        public Question GetRandomQuestion(int index)
        {
            if(index < 0 || index > questionsQueue.Count)
                throw new ArgumentOutOfRangeException("index");

            QuestionVariant questionVariant = questionsQueue[index];

            return questionVariant.Variants[GameMath.RandomCardFromTheDeck(questionVariant.Length)];
        }
    }
}
