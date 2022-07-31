using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour, IPanel
{
    [SerializeField]
    private Text _score;
    [SerializeField] 
    private Text[] _songName;

    private string _url;
    [SerializeField]
    private Sprite _tmpAlbum;
    [SerializeField]
    private Image[] _songAlbum;
    

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
            //start coroutine and take img and modify 
            _url = _songListRes[i].picture;
            StartCoroutine(GetAlbumCoverRoutine());
            _songName[i].text = _songListRes[i].title;
            _songAlbum[i].sprite = _tmpAlbum;
        }
    }

    private void OnEnable()
    {
        ProcessInfo();
    }

    IEnumerator GetAlbumCoverRoutine()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(_url))
        {
            yield return www.SendWebRequest();
            
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Texture2D textureDowloaded = DownloadHandlerTexture.GetContent(www);
                _tmpAlbum = Sprite.Create(textureDowloaded, new Rect(0, 0, textureDowloaded.width, textureDowloaded.height), new Vector2(0, 0));
            }
        }

    }
}
