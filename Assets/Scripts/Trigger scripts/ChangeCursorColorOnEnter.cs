using UnityEngine;
using UnityEngine.UI;

public class ChangeCursorColorOnEnter : MonoBehaviour
{
    [SerializeField] private Image cursorImage;
    [SerializeField] private Color cursorColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cursorImage.color = cursorColor;
        }
    }
}
