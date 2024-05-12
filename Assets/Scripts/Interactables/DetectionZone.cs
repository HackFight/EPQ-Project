using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ColliderEvent : UnityEvent<Collider>
{
}

public class DetectionZone : MonoBehaviour
{

    [SerializeField] private UnityEvent onEnter = default, onExit = default;
    [SerializeField] private UnityEvent onPlayerEnter, onPlayerExit;
    [SerializeField] private ColliderEvent onObjectEnter, onObjectExit;

    void OnTriggerEnter(Collider other)
    {
        onEnter.Invoke();

        if (other.tag == "Player")
        {
            onPlayerEnter.Invoke();
        }
        else
        {
            onObjectEnter.Invoke(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        onExit.Invoke();

        if (other.tag == "Player")
        {
            onPlayerExit.Invoke();
        }
        else
        {
            onObjectExit.Invoke(other);
        }
    }
}