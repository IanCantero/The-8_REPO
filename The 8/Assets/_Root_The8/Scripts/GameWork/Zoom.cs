using UnityEngine;
using Unity.Cinemachine;

public class Zoom : MonoBehaviour
{
    [SerializeField] CinemachineCamera zoomCam;

    private void Awake()
    {
        zoomCam.Priority = -2;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zoomCam.Priority = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zoomCam.Priority = -2;
        }
    }


}
