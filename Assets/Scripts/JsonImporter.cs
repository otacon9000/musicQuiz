using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct PlayList
{
    public string id;
    public Question[] questions;
    public string playlist;
}

[System.Serializable]
public struct Question
{
    public string id;
    public int answerIndex;
    public Choice[] choices;
    public Song song;
}
[System.Serializable]
public struct Choice
{
    public string artist;
    public string title;
}

[System.Serializable]
public struct Song
{
    public string id;
    public string title;
    public string artist;
    public string picture;
    public string sample;
}

public class JsonImporter : MonoBehaviour
{
    /// <summary>
    /// Collection of vehicles.
    /// </summary>
    [SerializeField]
    private List<PlayList> _playList = default;

    /// <summary>
    /// Database file name.
    /// </summary>
    private const string DATABASE_NAME = "coding-test-frontend-unity";

    private void Awake()
    {
        _playList = ReturnDatabase<PlayList>(DATABASE_NAME);
    }

    /// <summary>
    /// Returns string result of a text file from Resources.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private string ReturnFileResource(string path)
    {
        //Try to load text from file path.
        TextAsset textAsset = Resources.Load(path) as TextAsset;

        if (textAsset != null)
            return textAsset.text;
        else
            return string.Empty;
    }

    /// <summary>
    /// Returns a database at the file path.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
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
}
