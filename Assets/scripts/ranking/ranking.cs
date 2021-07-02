using System.Collections.Generic;
using UnityEngine;

/*
 * contiene una lista de statInfo que almacena todos los datos almacenados
 */
public class ranking : MonoBehaviour
{
    private static bool ini = true;
    
    public static List<statsInfo> estadisticas = new List<statsInfo>();    //lista donde se almacenan los datos


    private void Start()
    {
        if (ini)  ini = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        sortList();
    }

    public int getCount()
    {
        return estadisticas.Count;
    }

    public void addStst(statsInfo s)
    {
        estadisticas.Add(s);
    }

    public statsInfo get(int i)
    {
        return estadisticas[i];
    }

    void sortList()
    {
        estadisticas.Sort(SortByScore);
    }

    static int SortByScore(statsInfo p1, statsInfo p2)
    {
        return p1.getPoints().CompareTo(p2.getPoints());
    }
}