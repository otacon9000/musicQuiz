using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("UI Panel")] [SerializeField] private GameObject _welcomePanel;
    [SerializeField] private GameObject _quizPanel;
    [SerializeField] private GameObject _resultPanel;

    [Header("Question Panel")] 
    [SerializeField]
    private string _currentPlaylistName;
    private int _currentPlaylistIndex;
    [SerializeField] [Range(0, 4)]
    private int _questionCounter;
    [SerializeField] 
    private Question _currentQuestion;

    public void SetCurrentPlaylistName(int playlistIndex)
    {
        _currentPlaylistName = JsonImporter.Instance.GetPlaylistName(playlistIndex);
        _currentPlaylistIndex = playlistIndex;
    }

    public void SerCurrentQuestion()
    {
        _currentQuestion = JsonImporter.Instance.GetQuestion(_currentPlaylistIndex,_questionCounter);
    }
    public Question GetCurrentQuestion()
    {
        return _currentQuestion;
    }

    public void UpdateQuestionCounter()
    {
        _questionCounter++;
        if (_questionCounter > 3)
        {
            //go to result
            //set question counter to 0? 
        }
        else
        {
            
        }
    }

}
