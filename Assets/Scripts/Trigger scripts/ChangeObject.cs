using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    private int gravityListIndex;
    private PlayerInteract playerInteract;
    public Color color;
    private bool dragToggle;
    public float insideDrag;

    private void Awake()
    {
        playerInteract = GameObject.FindWithTag("Player").GetComponent<PlayerInteract>();
    }

    public void SetGravityListIndex(int index)
    {
        gravityListIndex = index;
    }

    public void ChangeObjectGravityToList(Collider collider)
    {
        if (collider.GetComponent<CustomGravityRigidbody>() != null)
        {
            if (collider.tag == "Grabable")
            {
                if (collider.transform == playerInteract.grabable)
                {
                    playerInteract.Drop();
                }

                collider.GetComponent<CustomGravityRigidbody>().gravityListIndex = gravityListIndex;
            }
            else
            {
                collider.GetComponent<CustomGravityRigidbody>().gravityListIndex = gravityListIndex;
            }
        }
        else
        {
            Debug.LogError("This object doesn't have a CustomGravityRigidbody!");
        }
    }

    public void ChangeObjectGravityToListWhenNotGrabbed(Collider collider)
    {
        if (collider.GetComponent<CustomGravityRigidbody>() != null)
        {
            if (collider.tag == "Grabable")
            {
                if (collider.transform != playerInteract.grabable)
                {
                    collider.GetComponent<CustomGravityRigidbody>().gravityListIndex = gravityListIndex;
                }
            }
            else
            {
                collider.GetComponent<CustomGravityRigidbody>().gravityListIndex = gravityListIndex;
            }
        }
        else
        {
            Debug.LogError("This object doesn't have a CustomGravityRigidbody!");
        }
    }

    public void ChangeObjectColor(Collider collider)
    {
        collider.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
        collider.GetComponentInChildren<Light>().color = color;
    }

    public void ToggleDragModifier(Collider collider)
    {
        if(!dragToggle)
        {
            dragToggle = true;
            collider.GetComponent<Rigidbody>().drag = insideDrag;
        }
        else
        {
            dragToggle = false;
            collider.GetComponent<Rigidbody>().drag = 0;
        }
    }

    public void ChangePlayersTempGrabbableIndex(int index)
    {
        playerInteract.tempGrabbableGravityIndex1 = index;
    }
}
