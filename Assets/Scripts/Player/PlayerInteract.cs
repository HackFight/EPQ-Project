using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform playerGrabPoint;
    [SerializeField] float interactDistance = 2f;
    [SerializeField] LayerMask interactLayer;

    private CustomGravityRigidbody grabablecrb;
    private Rigidbody grabablerb;

    public int grabbableGravityIndex1;

    public int tempGrabbableGravityIndex1;

    public Transform grabable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (grabable == null)
            {
                Ray r = new Ray(playerCamera.position, playerCamera.forward);

                if (Physics.Raycast(r, out RaycastHit hitInfo, interactDistance))
                {
                    if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactable))
                    {
                        interactable.Interact();
                    }
                    else if (hitInfo.collider.tag == "Grabable")
                    {
                        grabable = hitInfo.transform;
                        Grab();
                    }
                }
            }
            else
            {
                Drop();
            }
        }
    }

    public void Grab()
    {
        grabablecrb = grabable.GetComponent<CustomGravityRigidbody>();
        grabablerb = grabable.GetComponent<Rigidbody>();

        grabablecrb.grabbed = true;
        grabablerb.drag = 5f;

        tempGrabbableGravityIndex1 = grabbableGravityIndex1;
        grabablecrb.gravityListIndex = 0;
    }

    public void Drop()
    {
        grabablecrb.grabbed = false;
        grabablerb.drag = 0f;

        grabablecrb.gravityListIndex = tempGrabbableGravityIndex1;
        grabable = null;
    }

    public void ChangePlayergrabbableGravityIndex1(int index1)
    {
        grabbableGravityIndex1 = index1;

        if (grabable != null)
        {
            Grab();
        }
    }
}
