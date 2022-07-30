using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour, IPanel
{
    [SerializeField]
    private Question _question;

    [SerializeField] 
    [Range(0,4)]
    private int _index;

    public Text[] answerText;
    public void ProcessInfo()
    {
        _question = JsonImporter.Instance.GetQuestion(GameManager.Instance.playlistSelected,_index);
        //_question = JsonImporter.Instance.GetQuestion(0,0);
        for (int i = 0; i < _question.choices.Length; i++)
        {
            answerText[i].text = _question.choices[i].artist +"\n" +_question.choices[i].title;
        }
    }

    private void Start()
    {
        ProcessInfo();
    }
}
