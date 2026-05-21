using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float tiempo = 0f;
    public TMPro.TextMeshProUGUI texto;
    public bool isCounting;


    void Start()
    {
        isCounting = true;
    }

    void Update()
    {
        if (isCounting)
        {
            tiempo += Time.deltaTime;
        }
    }

    public void MostrarTiempo()
    {
        int segundos = Mathf.FloorToInt(tiempo);
        texto.text = segundos.ToString();
    }
}