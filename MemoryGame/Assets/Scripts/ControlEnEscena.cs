using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlEnEscena : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject contadorClics;
    public bool pause;
    //public bool musicaOn;
    //public bool fxOn;

    //public Button botonFx;
    //public Button botonMusica;

    private void Start()
    {
        //musicaOn = true;
        //fxOn = true;

        panelPausa = GameObject.Find("PanelPausa");
        if(panelPausa != null)
        {
            panelPausa.SetActive(false);
        }
        else
        {
            Debug.LogError("No se encuentra 'PanelPausa' en la escena");
        }

        contadorClics = GameObject.Find("ContadorClics");
        if(contadorClics != null)
        {
            contadorClics.SetActive(true);
        }
        else
        {
            Debug.LogError("No se encuentra 'ContadorClics' en la escena");
        }
        pause = false;
    }

    public void Pausa()
    {
        pause = !pause;
    }

    private void Update()
    {
        if(pause)
        {
            panelPausa.SetActive(true);
            contadorClics.SetActive(false);
            FindObjectOfType<Timer>().enabled = false;
        }
        else
        {
            panelPausa.SetActive(false);
            contadorClics.SetActive(true);
            FindObjectOfType<Timer>().enabled = true;
        }

        //if(musicaOn)
        //{
        //    botonMusica.GetComponentInChildren<Text>().text = "Musica ON";
        //    FindObjectOfType<AudioManager>().SubirVolumen("Fondo");
        //}
        //else
        //{
        //    botonMusica.GetComponentInChildren<Text>().text = "Musica OFF";
        //    FindObjectOfType<AudioManager>().BajarVolumen("Fondo");
        //}

        //if(fxOn)
        //{
        //    botonFx.GetComponentInChildren<Text>().text = "Fx ON";
        //    FindObjectOfType<AudioManager>().SubirVolumen("Acierto");
        //    FindObjectOfType<AudioManager>().SubirVolumen("Fallo");
        //}
        //else
        //{
        //    botonFx.GetComponentInChildren<Text>().text = "Fx OFF";
        //    FindObjectOfType<AudioManager>().BajarVolumen("Acierto");
        //    FindObjectOfType<AudioManager>().BajarVolumen("Fallo");
        //}
    }

    //public void MusicaOnOff()
    //{
    //    musicaOn = !musicaOn;
    //}

    //public void FxOnOff()
    //{
    //    fxOn = !fxOn;
    //}
}
