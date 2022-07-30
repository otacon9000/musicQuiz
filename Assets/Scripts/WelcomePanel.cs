using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WelcomePanel : MonoBehaviour, IPanel
{
    [SerializeField]
    private Text[] _playlistName;
    
    public void ProcessInfo()
    {
        for (int i = 0; i < JsonImporter.Instance.GetPlaylistNumber(); i++)
        {
            _playlistName[i].text = JsonImporter.Instance.GetPlaylistName(i);
        }
    }
    
    private void Start()
    {
        ProcessInfo();
    }
}
