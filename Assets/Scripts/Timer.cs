using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerUIText;
    [SerializeField] private TextMeshProUGUI timerWinUIText;
    [SerializeField] private TextMeshPro timerClockText;

    public bool speedrunning;
    private float speedrunTime;

    private void Update()
    {
        if(speedrunning)
        {
            speedrunTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(speedrunTime / 60);
            int seconds = Mathf.FloorToInt(speedrunTime % 60);

            string time = string.Format("{0:00}:{1:00}", minutes, seconds);

            timerWinUIText.text = time;
            timerUIText.text = time;
            timerClockText.text = time;
        }
    }
}
