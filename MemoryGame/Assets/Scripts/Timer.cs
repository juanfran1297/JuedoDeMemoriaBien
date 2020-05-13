using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    //public Canvas canvasVictoria;
    public Text tiempoSegundosText;
    public Text tiempoMinutosText;
    public float tiempoSegundos;
    public float tiempoMinutos;

    //public Canvas canvasDiferencias;

    private void Start()
    {
        tiempoSegundosText = GameObject.Find("TXT_Segundos").GetComponent<Text>();
        tiempoMinutosText = GameObject.Find("TXT_Minutos").GetComponent<Text>();
        //canvasVictoria = GameObject.Find("Canvas Victoria").GetComponent<Canvas>();
        //canvasDiferencias = GameObject.Find("Canvas Diferencias").GetComponent<Canvas>();

        //canvasDerrota.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(canvasVictoria.enabled == true)
        //{
        //    return;
        //}

        tiempoSegundos += Time.deltaTime;
        tiempoSegundosText.text = "" + tiempoSegundos.ToString("00");

        tiempoMinutosText.text = "" + tiempoMinutos.ToString("00");

        if(tiempoSegundos >= 60)
        {
            tiempoSegundos = 0;
            tiempoMinutos++;
        }
    }
}
