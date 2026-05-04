using UnityEngine;

public class ObjectZoom : MonoBehaviour
{
    public Transform zoomPointObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerZoom playerZoom = other.GetComponent<PlayerZoom>();
            if (playerZoom != null)
            {
                playerZoom.zoomPoint = zoomPointObject;
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
                playerZoom.zoomPoint = null;
            }
        }
    }
}
