using UnityEngine;

public class DataBase : MonoBehaviour
{
    public int iterations;
    public bool keepTimerOnScreen;

    public void setKeepTimerOnScreen(bool newState)
    {
        keepTimerOnScreen = newState;
    }
}
