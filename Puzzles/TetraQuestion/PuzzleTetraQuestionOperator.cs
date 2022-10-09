using TMPro;
using UnityEngine;
using UnityEngine.UI;
using FirMath;
using System.Collections.Generic;
using System;
using System.Collections;

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

    private int correctAnswer;

    [SerializeField]
    private Question question;

    void Awake()
    {
        answersArray = new TextMeshProUGUI[4] { answer_A, answer_B, answer_C, answer_D};
    }

    void OnEnable()
    {
        StartPuzzle();
    }

    public override void PuzzleExit()
    {
        gameObject.SetActive(false);
    }

    public override void Options()
    {
        ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
    }
    //public override void ClearPuzzle()
    //{
    //    victoryButton.SetActive(false);
    //    failButton.SetActive(false);
    //    puzzleFailed = false;
    //}
    public override void StartPuzzle()
    {
        ClearPuzzle();

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
            Button.ButtonClickedEvent buttonEvent = answersArray[i].GetComponentInParent<Button>().onClick;
            buttonEvent.RemoveAllListeners();
            if (answers[i] == -1)
            {
                correctAnswer = i;
                answersArray[i].text = question.CorrectAnswer;
                buttonEvent.AddListener(SuccessfullySolvePuzzle);
            }
            else
            {
                answersArray[i].text = question.WrongAnswers[answers[i]];
                buttonEvent.AddListener(LosePuzzle);
            }
        }
    }

    public override void SuccessfullySolvePuzzle()
    {
        if(!puzzleFailed)
            victoryButton.SetActive(true);

    }
    public override void LosePuzzle()
    {
        puzzleFailed = true;
        failButton.SetActive(true);
    }

    internal void SetPuzzleInformationPackage(PuzzleTetraQuestionPackage tetraQuestion)
    {
        question = tetraQuestion.Question;
    }

    private IEnumerator AnswerCoroutine()
    {
        var wait = new WaitForSeconds(1);
        yield return wait;

        
    }

    public void SetPlayerAnswer(int button)
    {
        bool success = correctAnswer == button;

    }
}
