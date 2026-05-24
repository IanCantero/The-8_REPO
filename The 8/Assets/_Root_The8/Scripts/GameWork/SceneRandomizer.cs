using UnityEngine;
using System.Collections;

public class SceneRandomizer : MonoBehaviour
{
    [System.Serializable]
    public class SCNVersion
    {
        public string nombre;
        public GameObject[] objetosActivar;
        public GameObject[] objetosDesactivar;
    }

    public SCNVersion[] versions;

    private int lastVersion = -1;
    public bool justOneTime = false;
    private bool alreadyDone = false;
    public bool needsToRotate = false;
    Collider triggerCollider;
    [SerializeField] GameObject rotationMaster;

    void Awake()
    {
                triggerCollider = GetComponent<Collider>();
        if (triggerCollider != null)
        {
            StartCoroutine(ColliderWait());
        }
    }
  
    /*
    void OnDisable()
    {
        if (triggerCollider != null)
        {
            triggerCollider.enabled = false;
        }
    }
    */

    IEnumerator ColliderWait()
    {
        triggerCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        triggerCollider.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (justOneTime && alreadyDone) return;

        ActivarRandom();
        alreadyDone = true;
    }

    void ActivarRandom()
    {
        if (versions.Length == 0) return;

        int index;

        do
        {
            index = Random.Range(0, versions.Length);
        } while (index == lastVersion && versions.Length > 1);

        lastVersion = index;
        
        AplicarVariante(versions [index]);
    }

    void AplicarVariante( SCNVersion v)
    {
        foreach (var obj in v.objetosActivar)
        {
            if (obj != null)
            {
                if (needsToRotate == true)
                {
                    rotationMaster.transform.Rotate(0f, 180f, 0f);
                }
                obj.transform.position = gameObject.transform.position; // Mover el objeto a la posición del trigger
                obj.transform.rotation = rotationMaster.transform.rotation; // Mover el objeto a la posición del trigger
               
            }
                
            obj.SetActive(true);
        }

        foreach (var obj in v.objetosDesactivar)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        Debug.Log("Variante activada: " + v.nombre);
    }
}