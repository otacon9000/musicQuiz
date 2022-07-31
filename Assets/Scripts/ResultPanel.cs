using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour, IPanel
{
    [SerializeField]
    private Text _score;
    [SerializeField] 
    private Text[] _songName;

    [SerializeField] 
    private Image[] finalResultSprite;
    private List<Song> _songListRes = new List<Song>();

    public void ProcessInfo()
    {
        int resultValue = 0;
        bool[] result = GameManager.Instance.GetResult();
        for (int i = 0; i < result.Length; i++)
        {
            if ( result[i]== true)
            {
                resultValue++;
                finalResultSprite[i].sprite = UIManager.Instance.correctAnswerCheckmark;
            }
            else
            {
                finalResultSprite[i].sprite = UIManager.Instance.wrongAnswerCheckmark;
            }
        }
        _score.text = resultValue.ToString() + "/5";
        _songListRes = UIManager.Instance.GetSongListResult();
        for (int i = 0; i < _songListRes.Count; i++)
        {
            _songName[i].text = _songListRes[i].title;
        }
    }

    private void OnEnable()
    {
        ProcessInfo();
    }
}
