using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioManager : MonoSingleton<AudioManager>
{
    public AudioClip correctButtonSFX;
    public AudioClip wrongButtonSFX;

    [SerializeField]
    private AudioClip _myClip;
    private AudioSource _audioSource;

    private void Awake()
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

    private IEnumerator GetAudioClipRoutine()
    {
        using (var www = UnityWebRequestMultimedia.GetAudioClip(UIManager.Instance.GetCurrentQuestion().song.sample, AudioType.WAV))
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

    private IEnumerator PlayAnswerSound(bool result)
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