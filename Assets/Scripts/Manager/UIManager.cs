using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool waitForResult = false;
    [SerializeField] 
    private Image[] _spriteButton;
    // [SerializeField] 
    // private Button[] _questionButton;
    [SerializeField] 
    private Sprite _baseSpriteButton;
    [SerializeField] 
    private Sprite _correctSpriteButton;
    [SerializeField] 
    private Sprite _wrongSpriteButton;



    [Header("Result")] 
    public Sprite correctAnswerCheckmark;
    public Sprite wrongAnswerCheckmark;
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
        GameManager.IsInputEnabled = true;
    }
    public Question GetCurrentQuestion()
    {
        return _currentQuestion;
    }
    
    public void UpdateQuestionCounter()
    {
        _questionCounter++;
        SetBaseSpriteButton();
        if (_questionCounter > 4)
        {
            //go to result
            AudioManager.Instance.StopAudio();
            _quizPanel.SetActive(false);
            _resultPanel.SetActive(true);
            _questionCounter = 0;
        }
        else
        {
            //go to next question and update field
            SetCurrentQuestion();
            AudioManager.Instance.StopAudio();
            _songsList.Add(_currentQuestion.song);
            _questionPanel.SetActive(false);
            _questionPanel.SetActive(true);
        }
    }
    
    public void CheckAnswer(int buttonIndex)
    {
        if (GameManager.IsInputEnabled)
        {
            if (buttonIndex != _currentQuestion.answerIndex)
            {
                //bad feedback
                //Debug.Log("wrong");
                _spriteButton[buttonIndex].sprite = _wrongSpriteButton;
                AudioManager.Instance.PlayAnswerSFX(false);
                GameManager.Instance.AddResult(_questionCounter, false);
            }
            else
            {
                //good feedback
                //Debug.Log("correct");
                _spriteButton[buttonIndex].sprite =_correctSpriteButton ;
                AudioManager.Instance.PlayAnswerSFX(true);
                GameManager.Instance.AddResult(_questionCounter, true);
            }
            GameManager.IsInputEnabled = false;
        }
    }

    public List<Song> GetSongListResult()
    {
        return _songsList;
    }

    private void SetBaseSpriteButton()
    {
        foreach (var n in _spriteButton)
        {
            n.sprite = _baseSpriteButton;
        }
    }
    
    public void RestartGame()
    {
        _songsList.Clear();
        GameManager.Instance.ResetGame();
        _resultPanel.SetActive(false);
        _welcomePanel.SetActive(true);
    }
    
}
