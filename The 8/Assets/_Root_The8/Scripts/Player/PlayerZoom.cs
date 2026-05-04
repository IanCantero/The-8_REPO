using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerZoom : MonoBehaviour
{
    [Header("Zoom Settings")]
    [SerializeField] Transform zoomPoint;
    Vector3 originalPosition;
    Quaternion originalRotation;
    [SerializeField] Camera cam;
    [SerializeField] float zoomSpeed = 5f;


    [Header("State Checkers")]
    [SerializeField] bool isZooming;
    public bool canZoom;
    bool hasSavedOrigin;


    void Awake()
    {
        isZooming = false;
        canZoom = false;
    }

    void Update()
    {
        if (isZooming && !canZoom)
        {
            UnZoom();
        }
    }

    void Zoom()
    {
        if (!canZoom || zoomPoint == null) return;
        if (!hasSavedOrigin)
        {
            originalPosition = cam.transform.position;
            originalRotation = cam.transform.rotation;
            hasSavedOrigin = true;
        }
        else return;

        cam.transform.position = Vector3.Lerp(cam.transform.position, zoomPoint.position, zoomSpeed * Time.deltaTime);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, zoomPoint.rotation, zoomSpeed * Time.deltaTime);
        isZooming = true;


    }

    void UnZoom()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, originalPosition, zoomSpeed * Time.deltaTime);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, originalRotation, zoomSpeed * Time.deltaTime);
        isZooming = false;

        hasSavedOrigin = false;
    }



    public void OnZoom(InputAction.CallbackContext context)
    {
     if (context.performed)
        {
            if (isZooming)
            {
                UnZoom();
            }
            else
            {
                Zoom();
            }
        }
    }

}