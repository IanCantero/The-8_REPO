using UnityEngine;

public class PointManagement : MonoBehaviour
{
    [SerializeField] bool Correct;
    [SerializeField] WinCon winCon;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Correct)
            {
                winCon.AddPoint();
            }
            else
            {
                winCon.RemovePoint();
            }
        }
    }
}
