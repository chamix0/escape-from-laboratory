using System;
using UnityEngine;

/*
 * se encarga de controlar el daño recivido por el jugador y se complementa con light manager 
 */
public class damage : MonoBehaviour
{
    private EnemyController[] enemy;
    private GameManager _gameManager;
    private BoxCollider2D boxCollider;
    public float time = 30;
    private float timer;    //variable que controla el tiempo de las luces
    private stats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        timer = time;
        enemy = FindObjectsOfType<EnemyController>();
        playerStats = GetComponent<stats>();
        _gameManager = FindObjectOfType<GameManager>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        takeDamage();
    }
    
    //methods
    bool takeDamage()
    {
        foreach (var t in enemy)
        {
            var caja = t.GetComponent<BoxCollider2D>();
            if (caja.bounds.SqrDistance(transform.position) == 0 && t.activo)
            {
                timer = 30;
                playerStats.quitarvida();
                _gameManager.Restart();
            }
        }

        return true;
    }

    public float getTimer()
    {
        return timer;
    }
    public void bajarTiempo()
    {
        timer-= Time.deltaTime;
    }
    public void setTime(float aux)
    {
        timer = aux;
    }
    public void dañoLuz()
    {
        if (timer<=0)
        {
            timer = time;
              playerStats.quitarvida();
              _gameManager.Restart();
        }
        
    }
}