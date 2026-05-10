using UnityEngine;
using Unity.Cinemachine;

public class DoorOpenRaycast : MonoBehaviour
{
    [SerializeField] CinemachineCamera fpsCam;
    [SerializeField] float range = 100f;
    [SerializeField] LayerMask impactLayer;

    Door currentDoor;

    void Update()
    {
        RaycastInteraction();
    }

    void RaycastInteraction()
    {
        Vector3 direction = fpsCam.transform.forward;

        Debug.DrawRay(fpsCam.transform.position, direction * range, Color.red);

        if (Physics.Raycast(fpsCam.transform.position, direction, out RaycastHit hit, range, impactLayer))
        {
            Door door = hit.collider.GetComponentInParent<Door>();

            if (door != null)
            {
                // Si es una puerta nueva
                if (door != currentDoor)
                {
                    // Avisar a la anterior
                    if (currentDoor != null)
                    {
                        currentDoor.OnLookAway();
                    }

                    currentDoor = door;
                    currentDoor.OnLookAt();
                }

                return;
            }
        }

        // Si no estamos mirando ninguna puerta
        if (currentDoor != null)
        {
            currentDoor.OnLookAway();
            currentDoor = null;
        }
    }
}