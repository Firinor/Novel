using FirMath;
using FirUnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.TetraQuestion
{
    public class TetraQuestionManager : PuzzleOperator
    {
        [SerializeField, NullCheck]
        private Image questionImage;
        [SerializeField, NullCheck]
        private TextMeshProUGUI questionText;
        [SerializeField]
        private Answer answer_A;
        [SerializeField]
        private Answer answer_B;
        [SerializeField]
        private Answer answer_C;
        [SerializeField]
        private Answer answer_D;
        private Answer[] answersArray;
        [SerializeField, NullCheck]
        private Sprite defaultButtonSprite;
        [SerializeField, NullCheck]
        private Sprite pickedButtonSprite;
        [SerializeField, NullCheck]
        private Sprite victoryButtonSprite;
        [SerializeField, NullCheck]
        private Sprite failButtonSprite;

        private int correctAnswer;

        [SerializeField]
        private QuestionsQueue questionsQueue;

        private Question question;

        protected void Awake()
        {
            answersArray = new Answer[4] { answer_A, answer_B, answer_C, answer_D };
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            StartPuzzle();
        }
        public override void ClearPuzzle()
        {
            questionImage.enabled = false;
            SetEnabledAllButtons(true);
            SetDefaultSpriteToAllButtons();
            VictoryButton.SetActive(false);
            FailButton.SetActive(false);
        }
        public override void StartPuzzle()
        {
            ClearPuzzle();

            questionText.text = question.QuestionText;

            if (question.Sprite != null)
            {
                questionImage.enabled = true;
                questionImage.sprite = question.Sprite;
                questionImage.SetNativeSize();
            }


            List<int> answers = new List<int> { -1 };
            //{-1}

            List<int> wrongAnswers = GameMath.AFewCardsFromTheDeck(3, question.WrongAnswers.Length);
            //question.WrongAnswers.Length may be more than 3.
            //{3, 0, 1}

            foreach (int wrongAnswer in wrongAnswers)
                answers.Add(wrongAnswer);
            //{-1, 3, 0, 1}

            answers = GameMath.ShuffleTheCards(answers);
            //{1, -1, 3, 0}

            for (int i = 0; i < 4; i++)
            {
                Button.ButtonClickedEvent buttonEvent = answersArray[i].Button.onClick;
                buttonEvent.RemoveAllListeners();
                if (answers[i] == -1)
                {
                    correctAnswer = i;
                    answersArray[i].Text.text = question.CorrectAnswer;
                }
                else
                {
                    answersArray[i].Text.text = question.WrongAnswers[answers[i]];
                }
            }
        }
        public override void SuccessfullySolvePuzzle()
        {
            VictoryButton.SetActive(true);
        }
        public override void LosePuzzle()
        {
            FailButton.SetActive(true);
        }
        public void SetPuzzleInformationPackage(TetraQuestionPackage tetraQuestion)
        {
            questionsQueue = tetraQuestion.Questions; //GetRandomQuestion();
            SetVictoryEvent(tetraQuestion.successPuzzleAction);
            SetFailEvent(tetraQuestion.failedPuzzleAction);
            SetBackground(tetraQuestion.PuzzleBackground);
        }

        private IEnumerator ButtonAnimating(int button, Sprite newSprite, Action action = null)
        {
            Image image = answersArray[button].Image;
            Sprite oldImage = image.sprite;

            WaitForSeconds wait = new WaitForSeconds(.4f);

            yield return wait;
            image.sprite = newSprite;
            yield return wait;
            image.sprite = oldImage;
            yield return wait;
            image.sprite = newSprite;
            yield return wait;
            image.sprite = oldImage;
            yield return wait;
            image.sprite = newSprite;

            action?.Invoke();
        }

        public void SetPlayerAnswer(int button)
        {
            SetEnabledAllButtons(false);
            answersArray[button].Image.sprite = pickedButtonSprite;
            if (button != correctAnswer)
            {
                StartCoroutine(ButtonAnimating(correctAnswer, victoryButtonSprite));
                StartCoroutine(ButtonAnimating(button, failButtonSprite, LosePuzzle));
            }
            else
            {
                StartCoroutine(ButtonAnimating(correctAnswer, victoryButtonSprite, SuccessfullySolvePuzzle));
            }
        }
        private void SetEnabledAllButtons(bool enabled)
        {
            foreach (Answer answer in answersArray)
            {
                answer.Button.enabled = enabled;
            }
        }
        private void SetDefaultSpriteToAllButtons()
        {
            foreach (Answer answer in answersArray)
            {
                answer.Image.sprite = defaultButtonSprite;
            }
        }

        [Serializable]
        private class Answer
        {
            public TextMeshProUGUI Text;
            public Image Image;
            public Button Button;
        }
    }
}
