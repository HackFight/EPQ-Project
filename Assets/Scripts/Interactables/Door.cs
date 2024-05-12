using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnimator;

    public void OpenDoor()
    {
        doorAnimator.SetBool("DoorOpened", true);
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("DoorOpened", false);
    }
}
