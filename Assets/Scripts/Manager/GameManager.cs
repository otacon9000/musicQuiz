
public class GameManager : MonoSingleton<GameManager>
{
    private bool[] _result = new bool[5];
    public static bool IsInputEnabled = true;

    public void ResetGame()
    {
        _result.Initialize();
    }

    public void AddResult(int questionIndex, bool result)
    {
        _result[questionIndex] = result;
    }
    
    public bool[] GetResult()
    {
        return _result;
    }
}
