using TMPro;
using UnityEngine;
using UnityEngine.UI;
using FirMath;
using System.Collections.Generic;

public class PuzzleTetraQuestionOperator : PuzzleOperator
{
    public enum answer { A, B, C, D }
    [SerializeField]
    private Image background;
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private TextMeshProUGUI answer_A;
    [SerializeField]
    private TextMeshProUGUI answer_B;
    [SerializeField]
    private TextMeshProUGUI answer_C;
    [SerializeField]
    private TextMeshProUGUI answer_D;
    private TextMeshProUGUI[] answersArray;
    [SerializeField]
    private Sprite victoryButtonSprite;
    [SerializeField]
    private Sprite failButtonSprite;
    private int correctAnswer = -1;

    [SerializeField]
    private Question question;

    void Awake()
    {
        answersArray = new TextMeshProUGUI[4] { answer_A, answer_B, answer_C, answer_D};
    }

    public void Answer(int answer)
    {
        
    }

    void OnEnable()
    {
        StartPuzzle();
    }

    public override void PuzzleExit()
    {
        gameObject.SetActive(false);
    }
    public override void LosePuzzle()
    {
        puzzleFailed = true;
        failButton.SetActive(true);
    }
    public override void Options()
    {
        ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
    }
    public override void ClearPuzzle()
    {
        victoryButton.SetActive(false);
        failButton.SetActive(false);
        puzzleFailed = false;
    }
    public override void StartPuzzle()
    {
        questionText.text = question.QuestionText;

        List<int> answers = new List<int>{ -1 };
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
            if (answers[i] == -1)
            {
                answersArray[i].text = question.CorrectAnswer;
            }
            else
            {
                answersArray[i].text = question.WrongAnswers[answers[i]];
            }
        }
    }

    public override void FinishPuzzle()
    {
        victoryButton.SetActive(true);
    }

    internal void SetPuzzleInformationPackage(PuzzleTetraQuestionPackage tetraQuestion)
    {
        question = tetraQuestion.Question;
    }
}
