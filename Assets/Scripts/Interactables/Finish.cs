using UnityEngine;

public class Finish : MonoBehaviour, IInteractable
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
    }

    public void Interact()
    {
        gameManager.Win();
    }
}
