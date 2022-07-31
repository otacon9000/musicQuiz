using UnityEngine;
using UnityEngine.UI;

public class WelcomePanel : MonoBehaviour, IPanel
{
    [SerializeField] private Text[] _playlistName;

    private void Start()
    {
        ProcessInfo();
    }

    public void ProcessInfo()
    {
        for (int i = 0; i < JsonImporter.Instance.GetPlaylistNumber(); i++)
            _playlistName[i].text = JsonImporter.Instance.GetPlaylistName(i);
    }
}