using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JsonImporter : MonoSingleton<JsonImporter>
{
    [SerializeField]
    private List<PlayList> _playList = default;

    private const string DATABASE_NAME = "coding-test-frontend-unity";

    private void Awake()
    {
        _playList = ReturnDatabase<PlayList>(DATABASE_NAME);
    }
    
    private string ReturnFileResource(string path)
    {
        TextAsset textAsset = Resources.Load(path) as TextAsset;

        if (textAsset != null)
            return textAsset.text;
        else
            return string.Empty;
    }

    private List<T> ReturnDatabase<T>(string path)
    {
        string result = ReturnFileResource(path);

        if (result.Length != 0)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(result).ToList();
        }
        else
        {
            Debug.LogWarning("ReturnDatabase -> result text is empty.");
            return new List<T>();
        }
    }

    public int GetPlaylistNumber()
    {
        return _playList.Count;
    }
    public string GetPlaylistName(int value)
    {
        return _playList[value].playlist;
    }

    public Question GetQuestion(int playlisteSelected, int questionNumber)
    {
        return _playList[playlisteSelected].questions[questionNumber];
    }
}
