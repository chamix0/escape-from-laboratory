
using UnityEngine;

/*
 * control de la mecanica de la luz, va ligado con la clase damage
 */
public class lightManager : MonoBehaviour
{
    private Light luz;
    public float timer;    //corresponde con el contador que hay en damage
    private damage _damage;

    private GameObject[] respiradores;
    public Transform target;

    //colores que controlan la luz
    private float red = 1;
    private float green = 1;
    private float blue = 1;

    // Start is called before the first frame update
    void Start()
    {
        target= GameObject.FindGameObjectWithTag("Player").transform;
        luz = GameObject.FindGameObjectWithTag("luz").GetComponent<Light>();
        _damage = GameObject.FindGameObjectWithTag("Player").GetComponent<damage>();
        timer = _damage.getTimer();
        respiradores = GameObject.FindGameObjectsWithTag("respiradores");
    }

    // Update is called once per frame
    void Update()
    {
        timer = _damage.getTimer();
        sumarLuz();
        daño();
        bajarLuz();
    }

    /*
     * cuando el contador vaya bajando ira tomando diferentes colores
     */
    void bajarLuz()
    {
        if (timer >= 0)

        {
            if (timer > 20)
            {
                red = 1;
                green = 1;
                blue = 1;
                luz.color = new Color(red, green, blue, 1);
            }

            if (timer < 20 && timer > 10)
            {
                green -= 0.002f;
                blue -= 0.002f;
                luz.color = new Color(red, green, blue, 1);
            }
            else if (timer < 10 && timer > 5)
            {
                red -= 0.002f;
                luz.color = new Color(red, green, blue, 1);
            }
            else if (timer < 5 && timer > 0)
            {
                red -= 0.001f;
                luz.color = new Color(red, green, blue, 1);
            }
            else if (timer <= 0)  luz.color = new Color(0, 0, 0, 1);
          
        }

        _damage.bajarTiempo();
    }

    //se termina el tiempo
    void daño()
    {
        if (timer <= 0)
        {
            _damage.dañoLuz();
            restablecerRespiradores();
        }
    }

    //recoger medicina
    void sumarLuz()
    {
        foreach (var t in respiradores)
        {
            var caja = t.GetComponent<BoxCollider2D>();
            if (caja.bounds.SqrDistance(target.position) == 0)
            {
                _damage.setTime(30);
                t.GetComponent<SpriteRenderer>().enabled = false;
                t.GetComponent<BoxCollider2D>().enabled = false;
                t.GetComponentInChildren<Light>().enabled = false;
            }
        }
    }

    //reponer las medicinas 
    void restablecerRespiradores()
    {
        foreach (var t in respiradores)
        {
            t.GetComponent<SpriteRenderer>().enabled = true;
            t.GetComponent<BoxCollider2D>().enabled = true;
            t.GetComponentInChildren<Light>().enabled = true;
        }
    }
}

