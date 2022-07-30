using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
 
public class AudioManager : MonoSingleton<AudioManager>
{
     
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _myClip;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void DowloadAudioClip()
    {
        StartCoroutine(GetAudioClip());
        Debug.Log("Starting to download the audio...");
    }
    IEnumerator GetAudioClip()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(UIManager.Instance.GetCurrentQuestion().song.sample, AudioType.WAV))
        {
            yield return www.SendWebRequest();
            
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                _myClip = DownloadHandlerAudioClip.GetContent(www);
                _audioSource.clip = _myClip;
                // _audioSource.Play();
                // Debug.Log("Audio is playing.");
            }
        }
    }
     
    public void PlayAudio(){
        _audioSource.Play();
    }
    //  
    // public void pauseAudio(){
    //     audioSource.Pause();
    // }
    //  

    //  
    // public void stopAudio(){
    //     audioSource.Stop();
    //  
    // }
}