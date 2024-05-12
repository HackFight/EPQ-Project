using UnityEngine;

public class Lamp : MonoBehaviour
{
    public bool on;
    public bool oneTimeUse;

    private Renderer lampRenderer;

    private void Awake()
    {
        lampRenderer = gameObject.GetComponent<Renderer>();

        if (on)
        {
            lampRenderer.material.color = Color.white;
        }
        else
        {
            lampRenderer.material.color = Color.black;
        }
    }

    public void ToggleLamp()
    {
        if (!on)
        {
            on = true;
            lampRenderer.material.color = Color.white;
        }
        else
        {
            if(!oneTimeUse)
            {
                on = false;
                lampRenderer.material.color = Color.black;
            }
        }
    }
}
