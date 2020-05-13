using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSonidos : MonoBehaviour
{
    public bool musicaOn;
    public bool fxOn;

    [Header("Musica Sprites")]
    public Sprite spriteMusicaOn;
    public Sprite spriteMusicaOff;
    [Header("FX Sprites")]
    public Sprite spriteFxOn;
    public Sprite spriteFxOff;
    [Header("Botones")]
    public Button botonFx;
    public Button botonMusica;
    [Header("DiferentesCanciones")]
    public AudioClip tema1;
    public AudioClip tema2;

    // Start is called before the first frame update
    void Start()
    {
        musicaOn = true;
        fxOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (musicaOn)
        {
            botonMusica.GetComponent<Image>().sprite = spriteMusicaOn;
            FindObjectOfType<AudioManager>().SubirVolumen("Fondo");
        }
        else
        {
            botonMusica.GetComponent<Image>().sprite = spriteMusicaOff;
            FindObjectOfType<AudioManager>().BajarVolumen("Fondo");
        }

        if (fxOn)
        {
            botonFx.GetComponent<Image>().sprite = spriteFxOn;
            FindObjectOfType<AudioManager>().SubirVolumen("Acierto");
            FindObjectOfType<AudioManager>().SubirVolumen("Fallo");
        }
        else
        {
            botonFx.GetComponent<Image>().sprite = spriteFxOff;
            FindObjectOfType<AudioManager>().BajarVolumen("Acierto");
            FindObjectOfType<AudioManager>().BajarVolumen("Fallo");
        }
    }

    //public void Escena12Cartas()
    //{
    //    FindObjectOfType<AudioManager>().CambiarClip("Fondo", tema2);
    //    FindObjectOfType<AudioManager>().Play("Fondo");
    //}

    public void MusicaOnOff()
    {
        musicaOn = !musicaOn;
    }

    public void FxOnOff()
    {
        fxOn = !fxOn;
    }
}
