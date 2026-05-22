using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;


public class NavMeshAutoBake : MonoBehaviour
{
    private NavMeshSurface surface;
    void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
    }

    void OnEnable()
    {
        BakeNavMesh();
    }
    void OnDisable()
    {
       
        surface.navMeshData = null;
    }

    void BakeNavMesh()
    {
        if (surface != null)
        {
            surface.layerMask = LayerMask.GetMask("Nothing");
            surface.layerMask = LayerMask.GetMask("Ground");
            surface.BuildNavMesh();
            Debug.Log("NavMesh bakeado automáticamente al activar el objeto.");
        }
    }
}
