using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    public Question currentQuestion;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI A;
    [SerializeField] private TextMeshProUGUI B;
    [SerializeField] private TextMeshProUGUI C;
    [SerializeField] private TextMeshProUGUI D;



    private void Start()
    {
        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        SetCurrentQuestion();
        //Debug.Log(currentQuestion.question);
        //Debug.Log(questions[0].question + questions[0].options[0]);
    }

    public void SetCurrentQuestion()
    {
        int randomIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomIndex];
        
        unansweredQuestions.RemoveAt(randomIndex);

        A.text = currentQuestion.options[0];
        B.text = currentQuestion.options[1];
        C.text = currentQuestion.options[2];
        D.text = currentQuestion.options[3];

        questionText.text = currentQuestion.question;
        
    }
}
