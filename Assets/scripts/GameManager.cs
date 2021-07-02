using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

/*
 * esta clase controla los eventos del juego, en especifico el ritmo de los enemigos y la muerte del jugador
 */
public class GameManager : MonoBehaviour
{
    public int targetTime = 0;
    static bool Ritmo;
    private static bool pass = true;
    public bool levels = false;

    private AudioSource dead;
    private EnemyController[] enemy;
    private Vector2 bornPos;
    private GameObject player;
    private stats playerStats;
    private movement _movement;
    private ranking Ranking;
    private GameObject[] checkpoint;

    // Start is called before the first frame update

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        checkpoint = GameObject.FindGameObjectsWithTag("checkpoint");
        Ranking = player.GetComponent<ranking>();
        _movement = player.GetComponent<movement>();
        enemy = FindObjectsOfType<EnemyController>();
        dead = GetComponent<AudioSource>();
        playerStats = player.GetComponent<stats>();
        bornPos = player.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Tiempo();
        Enemigos();
        GameOver();
        checkPoint();
    }
//funcion encargada de los check points
    void checkPoint()
    {
        foreach (var t in checkpoint)
        {
            var caja = t.GetComponent<BoxCollider2D>();
            if (caja.bounds.SqrDistance(player.transform.position) == 0)
            {
                print("checkpoint");
                print(caja.bounds);
                setBornPos(caja.transform.position);
            }
        }
    }

    //podria usarse esta clase en un futuro, esta indica la posicion donde spawneas
    public void setBornPos(Vector2 pos)
    {
        bornPos = pos;
    }

    public void Restart() //metodo para reaparecer
    {
        player.transform.position = bornPos;
        _movement.SetPositionEnd(bornPos);
    }

    void
        Tiempo() //es un contador que cuando sea true se moveran los enmeigos y false no haran nada, solo sera true una vez por segundo y el resto de tiempo false

    {
        targetTime = (int) Time.time;
        if (targetTime % 2 == 0)
        {
            Ritmo = false;
            pass = true;
        }
        else
        {
            if (pass) Ritmo = true;

            pass = false;
        }
    }

    void Enemigos() //llama a los enemigos para que ejecuten su accion
    {
        foreach (var t in enemy) t.Action(Ritmo);

        Ritmo = false;
    }

    public void GameOver()
    {
        if (playerStats.gethp() == 0)
        {
            
            String gameover = levels ? "Scenes/GameOver/GameOverLevels":"Scenes/GameOver/GameOver";
            
            String retry = levels ? "Scenes/GameOver/restart 1Levels":"Scenes/GameOver/restart";
            //cuando mueres te permite elegir si jugar otra vez o no
            if (playerStats.getPoints() < 300)
                {
                    playerStats.sethp(playerStats.vidas);
                    playerStats.setPoints(0);
                    Destroy(player);
                    SceneManager.LoadScene(retry);
                }
                else
                {
                    playerStats.sethp(playerStats.vidas);
                    playerStats.setPoints(0);
                    Destroy(player);
                    SceneManager.LoadScene(gameover); // poner que lleve a pantalla de jugar otra vez
                }
            }
        
    }
}