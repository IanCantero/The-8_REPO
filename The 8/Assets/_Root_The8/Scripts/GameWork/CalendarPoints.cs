using UnityEngine;
using TMPro;
using System.Collections;

public class CalendarPoints : MonoBehaviour
{
    [SerializeField] WinCon winCon;

    [SerializeField] TextMeshProUGUI pointsText;


    void OnEnable()
    {
       pointsText.text = winCon.points.ToString();
        StartCoroutine(PointsUpdate());
    }

    IEnumerator PointsUpdate()
    {
        while (true)
        {
            pointsText.text = winCon.points.ToString();
            yield return new WaitForSeconds(0.5f);
        }
    }
}