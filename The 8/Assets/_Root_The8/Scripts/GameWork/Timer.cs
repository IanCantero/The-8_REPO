using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float tiempo = 0f;
    public TMPro.TextMeshProUGUI texto;

    void Update()
    {
        tiempo += Time.deltaTime;
    }

    public void MostrarTiempo()
    {
        int segundos = Mathf.FloorToInt(tiempo);
        texto.text = segundos.ToString();
    }
}