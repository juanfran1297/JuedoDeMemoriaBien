using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Reintentar()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }

    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
