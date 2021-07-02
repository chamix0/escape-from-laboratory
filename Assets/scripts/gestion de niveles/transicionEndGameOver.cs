using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//transicion de perder o ganar hasta el menu
public class transicionEndGameOver : MonoBehaviour
{
    public String nivel;
    private Button jugar;
    
    private void Start()
    {
        jugar = GameObject.FindGameObjectWithTag("play").GetComponent<Button>();    //boton para que se pueda volver al menu inicial
    }

    // Update is called once per frame
    void Update()
    {
        SetupButton();
    }

    public void SetupButton()    //metodo para configurar el click
    {
        jugar.onClick.AddListener(delegate() { this.ButtonClicked(); });
    }

    public void ButtonClicked()    //cambio de escena
    {
        SceneManager.LoadScene(nivel);
    }

  
}