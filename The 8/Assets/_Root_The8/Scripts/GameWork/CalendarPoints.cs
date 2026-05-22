using UnityEngine;
using TMPro;

public class CalendarPoints : MonoBehaviour
{
    [SerializeField] WinCon winCon;

    [SerializeField] TextMeshProUGUI pointsText;


    void OnEnable()
    {
       pointsText.text = winCon.points.ToString();
    }
}
