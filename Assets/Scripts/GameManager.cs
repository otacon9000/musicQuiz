using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private int _playerScore = 0;
    public int questionCount = 0;
    public int playlistSelected;
    
    public void UpdateScore()
    {
        _playerScore++;
    }

    public void ResetScore()
    {
        _playerScore = 0;
    }
    
}
