using UnityEngine;

public class ObjectZoom : MonoBehaviour
{
    public Transform zoomPoint; // donde se coloca la cámara al hacer zoom
    public float zoomSpeed = 5f;

    private bool playerClose = false;
    private bool inZoom = false;

    private Transform camera;
    private Vector3 posicionOriginal;
    private Quaternion rotacionOriginal;
    private float fovOriginal;

    public float fovZoom = 30f;

    void Start()
    {
        camera = Camera.main.transform;
    }

    void Update()
    {
        if (playerClose && Input.GetKeyDown(KeyCode.E))
       

        if (inZoom)
        {
            camera.position = Vector3.Lerp(camera.position, zoomPoint.position, Time.deltaTime * zoomSpeed);
            camera.rotation = Quaternion.Lerp(camera.rotation, zoomPoint.rotation, Time.deltaTime * zoomSpeed);
        }
    }

    void EntrarZoom()
    {
        inZoom = true;

        posicionOriginal = camera.position;
        rotacionOriginal = camera.rotation;
        fovOriginal = Camera.main.fieldOfView;

        Camera.main.fieldOfView = fovZoom;
    }

    void SalirZoom()
    {
        inZoom = false;

        camera.position = posicionOriginal;
        camera.rotation = rotacionOriginal;
        Camera.main.fieldOfView = fovOriginal;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerClose = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerClose = false;
    }


    public void ToggleZoom()
    {
        if (inZoom)
            SalirZoom();
        else
            EntrarZoom();
    }
     
    /*
    {
            if (!inZoom)
                EntrarZoom();
            else
                SalirZoom();
    }
    */
}