using UnityEngine;
using UnityEngine.UI;

/*
 * pone el numero de vidas por pantalla
 */

public class PointsPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public float points;
    private stats player;
    private GameObject jugador;
    public Text puntosText;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        player = jugador.GetComponent<stats>();
        points = player.getPoints();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        points = player.getPoints();
        puntosText.text = "" + points.ToString("f0");
    }
}