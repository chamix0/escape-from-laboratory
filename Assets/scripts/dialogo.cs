using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * mostrar cuadro de dialogo
 */
public class dialogo : MonoBehaviour
{
    // Start is called before the first frame update
    public String texto = "skereeeeee";
    private Text TextDialogo;
    private GameObject cuadro;

    
    void Start()
    {
        TextDialogo = GetComponentInChildren<Text>();
        cuadro = GameObject.FindGameObjectWithTag("dialog");
        cuadro.SetActive(false);
    }

    public void showText(String aux)
    {
        TextDialogo.text = aux;
        cuadro.SetActive(true);
    }
    
    public void showText()
    {
        TextDialogo.text = texto;
        cuadro.SetActive(true);
    }
    
    public void cerrarTexto()
    {
        cuadro.SetActive(false);
    }
}
