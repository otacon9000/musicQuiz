using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour, IPanel
{
    public Text[] answerText;
    private Question _question;

    private void OnEnable()
    {
        ProcessInfo();
    }

    public void ProcessInfo()
    {
        _question = UIManager.Instance.GetCurrentQuestion();
        AudioManager.Instance.DowloadAudioClip();
        for (int i = 0; i < _question.choices.Length; i++)
            answerText[i].text = _question.choices[i].artist + "\n" + _question.choices[i].title;
    }
}