using System;

/*
 * clase de la que esta compuesta la lista de ranking
 */
public class statsInfo
{
//atributos
    private float points;
    private String name;

//constructor
    public statsInfo(string nombre, float p)
    {
        points = p;
        name = nombre;
    }

//metodos
    public void setName(String nombre)
    {
        name = nombre;
    }

    public String getName()
    {
        return name;
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
}