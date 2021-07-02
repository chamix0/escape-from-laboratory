using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * metodo para cambiara cualquier escena
 */
public class cambioDeNivel : MonoBehaviour
{
    public bool isLevel = false;
    public String nivel; //escena a la que accederemos, se accede desde el editor de niveles
    private GameObject player; //objeto para obtener la posicion del personaje
    private GameManager _gameManager; //ranking
    private stats _stats;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        _stats = player.GetComponent<stats>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Collision();
    }

    //si la posicion es igual a la del objeto que porte este script, se cambiara la escena
    private void Collision()
    {
        if (transform.position == player.transform.position)
        {
            SceneManager.LoadScene(nivel);
            //es para si estamos accediendo desde los niveles, se resetee cadavez que terminamos un nivel
            if (isLevel)
            {
                _stats.sethp(_stats.vidas);
                _stats.setPoints(0);
            }
        }
    }
}