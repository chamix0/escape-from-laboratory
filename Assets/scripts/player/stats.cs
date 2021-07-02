using System;
using UnityEngine;

/*
 *almacena los datos del jugador 
 */
public class stats : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidas = 5;
    private static int hp = 5;
    private static float points;
    private static String name;
    private int keys = 0;

    // Update is called once per frame


    //methods
    public int gethp()
    {
        return hp;
    }

    public int getKey()
    {
        return keys;
    }

    public void addKey()
    {
        keys++;
    }

    public void setName(String nombre)
    {
        name = nombre;
    }

    public String getName()
    {
        return name;
    }

    public void sethp(int vidas)
    {
        hp = vidas;
    }

    public float getPoints()
    {
        return points;
    }

    public void setPoints(int p)
    {
        points = p;
    }

    public void addPoints()
    {
        points++;
    }

    public void quitarvida()
    {
        hp--;
    }

    public void tiempo()
    {
        points += Time.deltaTime;
    }
}