using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerInteract playerInteract;

    public void ChangePlayerGravityIndex(int gravityListIndex)
    {
        playerController.gravityListIndex = gravityListIndex;
    }

    public void ChangePlayergrabbableGravityIndex1To(int gravityListIndex)
    {
        playerInteract.ChangePlayergrabbableGravityIndex1(gravityListIndex);
    }
}
