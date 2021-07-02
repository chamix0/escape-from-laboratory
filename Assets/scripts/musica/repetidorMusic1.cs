
using UnityEngine;

/*
 * en el nivel de las luces, al ser las 3 funetes de sonido iguales, se necestian diferentes repetidores para controlar el mute
 * hay 2 clases iguales, ya que unity reconocia el script como una misma instancia y solo permitia controlar un numero limitado de suentes de sonido
 */

public class repetidorMusic1 : MonoBehaviour
{
    private controlMusica _controlMusica;
    private static AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        _controlMusica=new controlMusica();
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        print(_controlMusica.getMuted());
        audio.mute = _controlMusica.getMuted();
    }
}
