using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private int _playerScore = 0;
    private bool[] _result = new bool[5];
    
    public void UpdateScore()
    {
        _playerScore++;
    }

    public void ResetGame()
    {
        _playerScore = 0;
        _result.Initialize();
    }

    public void AddResult(int questionIndex, bool result)
    {
        _result[questionIndex] = result;
    }
    
    public bool[] GetResult()
    {
        return _result;
    }
}
