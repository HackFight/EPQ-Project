using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravityRigidbody : MonoBehaviour
{

    Rigidbody body;

    public float floatDelay;
    public bool useGravity = true;
    public int gravityListIndex;
    public bool grabbed;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    void FixedUpdate()
    {
        if (!grabbed)
        {
            if (body.IsSleeping())
            {
                floatDelay = 0f;
                return;
            }

            if (body.velocity.sqrMagnitude < 0.0001f)
            {
                floatDelay += Time.deltaTime;

                if (floatDelay >= 1f)
                {
                    return;
                }
            }
            else
            {
                floatDelay = 0f;
            }
        }
        
        if (useGravity)
        {
            body.AddForce(CustomGravity.GetGravity(body.position, gravityListIndex), ForceMode.Acceleration);
        }
        
    }

    public Rigidbody GetRigidbody()
    {
        return body;
    }
}