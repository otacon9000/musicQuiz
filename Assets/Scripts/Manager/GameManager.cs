using System.Collections.Generic;

public class GameManager : MonoSingleton<GameManager>
{
    public static bool IsInputEnabled = true;
    private List<bool> _result = new List<bool>();

    public void ResetGame()
    {
        _result.Clear();
    }

    public void AddResult(int questionIndex, bool result)
    {
        _result.Add(result);
    }

    public List<bool> GetResult()
    {
        return _result;
    }
}