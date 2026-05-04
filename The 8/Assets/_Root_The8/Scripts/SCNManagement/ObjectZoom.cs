using UnityEngine;

public class ObjectZoom : MonoBehaviour
{
void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerZoom playerZoom = other.GetComponent<PlayerZoom>();
            if (playerZoom != null)
            {
                playerZoom.canZoom = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerZoom playerZoom = other.GetComponent<PlayerZoom>();
            if (playerZoom != null)
            {
                playerZoom.canZoom = false;
            }
        }
    }
}
