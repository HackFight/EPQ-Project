using UnityEngine;
using UnityEngine.Playables;

public class SetTimelineTime : MonoBehaviour
{
    public void setTime(float seconds)
    {

        PlayableDirector playableDirector = GetComponent<PlayableDirector>();


        playableDirector.time = seconds;

    }
}
