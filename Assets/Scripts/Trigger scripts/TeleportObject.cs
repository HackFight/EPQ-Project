using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public Vector3 offset;

    public void RelativeTeleport(Collider collider)
    {
        collider.transform.position += offset;
    }
}
