using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class JsonImporter : MonoSingleton<JsonImporter>
{
    private const string DATABASE_NAME = "coding-test-frontend-unity";

    [SerializeField] 
    private List<PlayList> _playList;

    private void Awake()
    {
        _playList = ReturnDatabase<PlayList>(DATABASE_NAME);
    }

    private string ReturnFileResource(string path)
    {
        var textAsset = Resources.Load(path) as TextAsset;

        if (textAsset != null)
            return textAsset.text;
        return string.Empty;
    }

    private List<T> ReturnDatabase<T>(string path)
    {
        var result = ReturnFileResource(path);

        if (result.Length != 0)
        {
            return JsonConvert.DeserializeObject<List<T>>(result).ToList();
        }

        Debug.LogWarning("ReturnDatabase -> result text is empty.");
        return new List<T>();
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