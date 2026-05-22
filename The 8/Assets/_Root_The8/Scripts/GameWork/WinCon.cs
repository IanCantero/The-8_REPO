using UnityEngine;

public class WinCon : MonoBehaviour
{

    [SerializeField] int WinPoints;
    public int points;
    [SerializeField] GameObject winScreen;
    [SerializeField] Timer timer;
    [SerializeField] GameObject player;

    void Awake()
    {
        points = 0;
        winScreen.SetActive(false);
    }
    public void AddPoint()
    {
        points++;
        Debug.Log("Points: " + points);
        if (points >= WinPoints)
        {
            timer.isCounting = false;
           winScreen.SetActive(true);
           timer.MostrarTiempo();
            WinConfiguration();
        }
    }

    void WinConfiguration()
    {
        Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;  
    }

    public void RemovePoint()
    {
        points = 0;
                Debug.Log("Palmaste wey");
    }


}
