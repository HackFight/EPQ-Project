using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public Toggle toggle;

    private DataBase dataBase;

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }

    private void Awake()
    {
        dataBase = GameObject.FindWithTag("DataBase").GetComponent<DataBase>();
    }

    private void Start()
    {
        toggle.isOn = dataBase.keepTimerOnScreen;
    }
}
