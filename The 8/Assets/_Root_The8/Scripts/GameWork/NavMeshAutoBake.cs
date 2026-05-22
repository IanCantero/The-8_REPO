using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class NavMeshAutoBake : MonoBehaviour
{
    public LayerMask layerMask;

    void OnEnable()
    {
        BakeNavMesh();
    }

    void BakeNavMesh()
    {
        var sources = new List<NavMeshBuildSource>();

        // Bounds grandes o ajustados a tu nivel
        Bounds bounds = new Bounds(Vector3.zero, new Vector3(500, 500, 500));

        NavMeshBuilder.CollectSources(
            bounds,
            layerMask,
            NavMeshCollectGeometry.RenderMeshes,
            0,
            new List<NavMeshBuildMarkup>(),
            sources
        );

        var navMeshData = new NavMeshData();
        NavMeshBuilder.BuildNavMeshData(
            NavMesh.GetSettingsByID(0),
            sources,
            bounds,
            Vector3.zero,
            Quaternion.identity
        );

        NavMesh.AddNavMeshData(navMeshData);

        Debug.Log("NavMesh bakeado SOLO con layers correctas");
    }
}