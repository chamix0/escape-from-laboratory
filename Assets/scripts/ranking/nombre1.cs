using UnityEngine;
using UnityEngine.UI;

/*
 * para pintar los nombres del ranking
 */

public class nombre1 : MonoBehaviour
{
    public int indice;

    private ranking ran;
    protected Text texto;


    // Start is called before the first frame update
    void Start()
    {
        ran = GetComponent<ranking>();
        texto = GetComponent<Text>();

    }


    // Update is called once per frame
    void Update()
    {
       ponerTexto(); 
    }


    private void ponerTexto()
    {

        if (ran.getCount() >indice)
        {
            if (ran.get(indice).getName().Length >3)    texto.text = ran.get(indice).getName().Remove(3) + "     " + ran.get(indice).getPoints().ToString("f0");
            
            else      texto.text = ran.get(indice).getName() + "     " + ran.get(indice).getPoints().ToString("f0");

        }
    }
}