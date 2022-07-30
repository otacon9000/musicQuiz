using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour, IPanel
{ 
    private Question _question;
    public Text[] answerText;
    public void ProcessInfo()
    {
        _question = UIManager.Instance.GetCurrentQuestion();
        AudioManager.Instance.DowloadAudioClip();
        for (int i = 0; i < _question.choices.Length; i++)
        {
            answerText[i].text = _question.choices[i].artist +"\n" +_question.choices[i].title;
        }
    }
    
    private void OnEnable()
    {
        ProcessInfo();
        AudioManager.Instance.PlayAudio();
    }
    
   
}
