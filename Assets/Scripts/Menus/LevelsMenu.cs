using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void PlayLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
