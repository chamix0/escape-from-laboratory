using UnityEngine;
using UnityEngine.UI;

/*
 * pone el numero de vidas por pantalla
 */
public class healthPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public int Health;
    private stats player;
    private GameObject jugador;
    public Text HealthText;
    
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        player = jugador.GetComponent<stats>();
        Health = player.gethp();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Health = player.gethp();
        HealthText.text = "" + Health;

    }
}
