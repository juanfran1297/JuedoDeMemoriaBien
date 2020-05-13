using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorClics : MonoBehaviour
{
    public int contador;
    public Text textContador;
    private void Start()
    {
        contador = 0;
        textContador.text = contador.ToString();
    }
    private void OnMouseUpAsButton()
    {
        contador++;
        textContador.text = contador.ToString();
    }
}
