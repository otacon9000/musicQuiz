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


