using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

/*
 * transicion entre niveles, este depende de un contador
 */
public class trnsicionEntreNiveles : MonoBehaviour
{
    float timeLeft = 5.0f;
    public String nivel;
    private Button jugar;

    // Update is called once per frame
    void FixedUpdate()
    {
        Temporizador();
    }

    void Temporizador()
    {
        timeLeft -= Time.deltaTime;

        //cuando termina el tiempo se cambia la escena
        if (timeLeft < 0)  SceneManager.LoadScene(nivel);
    }
}