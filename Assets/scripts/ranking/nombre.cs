using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * para poder introducior el nombre, que se va a ver en el ranking cuando ganas, es decir terminas el ultimo nivel
 */

public class nombre : MonoBehaviour
{
    private float puntos;
    public bool ini=true;

    private InputField name;
    private stats _stats;
    private ranking Ranking;


    void Start()
    {
        ini = true;
        Ranking = GetComponent<ranking>();
        name = GameObject.FindGameObjectWithTag("boton").GetComponent<InputField>();
        _stats = GetComponent<stats>();
        puntos = _stats.getPoints();
    }



    public void gotoRanking() //cambio de escena
    {
        saveStats();
        SceneManager.LoadScene("Scenes/menu/Ranking");
    }

    private void saveStats()    //guarda los datos antes de resetar al jugador
    {
        if (ini)
        {

            statsInfo s = new statsInfo(name.text, puntos);
            Ranking.addStst(s);
            ini = false;
        }

        _stats.sethp(_stats.vidas);
        _stats.setPoints(0);
    }
}