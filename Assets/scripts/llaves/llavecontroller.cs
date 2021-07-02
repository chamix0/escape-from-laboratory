using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * este script va dentro de una puerta y se encarga de administrar el sistema de llaves
 */

public class llavecontroller : MonoBehaviour
{
    static bool aux = true;
    public String nivel; //escena a la que accederemos, se accede desde el editor de niveles
    private GameObject player; //objeto para obtener la posicion del personaje
    private GameManager _gameManager; //ranking
    private stats _stats;
    private GameObject[] llaves;
    private dialogo _dialogo;

    private void Start()
    {
        _dialogo = GetComponent<dialogo>();
        llaves = GameObject.FindGameObjectsWithTag("key");
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        _stats = player.GetComponent<stats>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Collision();
        cogerLlave();
        print(_stats.getKey() + " llaves");
    }

    //recoger la llave y hacerla desaparecer
    private void cogerLlave()
    {
        foreach (var t in llaves)
        {
            var caja = t.GetComponent<BoxCollider2D>();
            if (caja.bounds.SqrDistance(player.transform.position) == 0)
            {
                if (aux)
                {
                    aux = false;
                    t.transform.position = new Vector3(-1000, -1000);    //se teletransporta devido a que otras formas como destruir el objeto, daba problemas en ejecucion
                    _stats.addKey();
                    t.GetComponentInChildren<Light>().enabled = false;
                }
                else    aux = true;
            }
        }
    }

    //si la posicion es igual a la del objeto que porte este script, se cambiara la escena
    //mostrar dialogo que te indica las llaves que te quedan
    private void Collision()
    {
        if (GetComponent<BoxCollider2D>().bounds.SqrDistance(player.transform.position) == 0)
            
        {
            if (_stats.getKey() == 3) SceneManager.LoadScene(nivel);
            
            else _dialogo.showText("te faltan " + (-_stats.getKey() + 3) + " llaves");
        }
        else _dialogo.cerrarTexto();
    }
}