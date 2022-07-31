using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
 
public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioClip correctButtonSFX;
    public AudioClip wrongButtonSFX;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _myClip;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void DowloadAudioClip()
    {
        StartCoroutine(GetAudioClipRoutine());
    }
    
    public void StopAudio()
    {
        _audioSource.Stop();
    }
    
    public void PlayAnswerSFX(bool result)
    {
        StartCoroutine(PlayAnswerSound(result));
    }
    
    IEnumerator GetAudioClipRoutine()
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
                _audioSource.Play();
            }
        }
    }

    IEnumerator PlayAnswerSound(bool result)
     {
         if (result)
         {
             _audioSource.clip = correctButtonSFX;
             _audioSource.Play();
             yield return new WaitForSeconds(correctButtonSFX.length);
             UIManager.Instance.UpdateQuestionCounter();
         }
         else
         {
             _audioSource.clip = wrongButtonSFX;
             _audioSource.Play();
             yield return new WaitForSeconds(wrongButtonSFX.length);
             UIManager.Instance.UpdateQuestionCounter();
         }
     }
}