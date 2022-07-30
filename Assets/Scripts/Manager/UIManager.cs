using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [Header("UI Panel")] 
    [SerializeField] 
    private GameObject _welcomePanel;
    [SerializeField] 
    private GameObject _quizPanel;
    [SerializeField] 
    private GameObject _resultPanel;

    [Header("Question Panel")] 
    [SerializeField] 
    private GameObject _questionPanel;
    [SerializeField]
    private string _currentPlaylistName;
    private int _currentPlaylistIndex;
    [SerializeField] [Range(0, 4)]
    private int _questionCounter = 0;
    [SerializeField] 
    private Question _currentQuestion;

    [Header("Result")] 
    public Sprite correctSprite;
    public Sprite wrongSprite;
    [SerializeField]
    private List<Song> _songsList = new List<Song>();
    public void SetCurrentPlaylistName(int playlistIndex)
    {
        _currentPlaylistName = JsonImporter.Instance.GetPlaylistName(playlistIndex);
        _currentPlaylistIndex = playlistIndex;
        
        _welcomePanel.SetActive(false);
        SetCurrentQuestion();
        _songsList.Add(_currentQuestion.song);
        _quizPanel.SetActive(true);
    }

    public void SetCurrentQuestion()
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
        if (_questionCounter > 4)
        {
            //go to result
            _quizPanel.SetActive(false);
            _resultPanel.SetActive(true);
            //set question counter to 0? 
            _questionCounter = 0;
        }
        else
        {
            //go to next question or update field
            SetCurrentQuestion();
            _songsList.Add(_currentQuestion.song);
            _questionPanel.SetActive(false);
            _questionPanel.SetActive(true);
        }
    }
    
    //test to check with the correct answer
    public void CheckAnswer(int buttonIndex)
    {
        if (buttonIndex != _currentQuestion.answerIndex)
        {
            //bad feedback
            Debug.Log("wrong");
            GameManager.Instance.AddResult(_questionCounter, false);
        }
        else
        {
            //good feedback
            Debug.Log("correct");
            GameManager.Instance.AddResult(_questionCounter, true);
        }
        //go to the next question
        UpdateQuestionCounter();
    }

    public List<Song> GetSongListResult()
    {
        return _songsList;
    }



    public void RestartGame()
    {
        _songsList.Clear();
        GameManager.Instance.ResetGame();
        _resultPanel.SetActive(false);
        _welcomePanel.SetActive(true);
    }

}
