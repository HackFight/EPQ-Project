using UnityEngine;
using UnityEngine.Events;

public class GameButton : MonoBehaviour, IInteractable
{
    public UnityEvent pressButtonEvent;

    public void Interact()
    {
        Press();
    }

    public void Press()
    {
        pressButtonEvent?.Invoke();
    }
}