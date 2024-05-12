using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject tabMenu;
    [SerializeField] private GameObject GUI;
    [SerializeField] private GameObject winMenu;
    [SerializeField] private TextMeshProUGUI iterationsText;

    private bool gamePaused;
    private bool gameWon;
    private bool keepTimer;

    private FirstPersonCameraRotation cameraScript;
    private Timer timer;
    private DataBase dataBase;

    private void Awake()
    {
        cameraScript = GameObject.FindWithTag("MainCamera").GetComponent<FirstPersonCameraRotation>();
        dataBase = GameObject.FindWithTag("DataBase").GetComponent<DataBase>();
        timer = GetComponent<Timer>();

        pauseMenu.SetActive(false);
        tabMenu.SetActive(false);
        GUI.SetActive(true);
        winMenu.SetActive(false);

        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        keepTimer = dataBase.keepTimerOnScreen;

        StartTimer();
        dataBase.iterations++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameWon)
            {
                if (!gamePaused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }
        
        tabMenu.SetActive((Input.GetKey(KeyCode.Tab) && !gamePaused && !gameWon) || (keepTimer && !gamePaused && !gameWon));

        iterationsText.text = dataBase.iterations.ToString();
    }

    public void PauseGame()
    {
        gamePaused = true;

        pauseMenu.SetActive(true);
        GUI.SetActive(false);

        cameraScript.freezeInputs = true;

        Time.timeScale = 0.0f;

        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        gamePaused = false;

        pauseMenu.SetActive(false);
        GUI.SetActive(true);

        cameraScript.freezeInputs = false;

        Time.timeScale = 1.0f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reloadevel()
    {
        dataBase.iterations += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartTimer()
    {
        timer.speedrunning = true;
    }

    public void StopTimer()
    {
        timer.speedrunning = false;
    }

    public void Win()
    {
        gameWon = true;
        StopTimer();

        winMenu.SetActive(true);
        GUI.SetActive(false);

        cameraScript.freezeInputs = true;

        Time.timeScale = 0.0f;

        Cursor.lockState = CursorLockMode.None;
    }
}