
using UnityEngine;

/*
 *  script experimental que limita los fps ya que en diferentes ordenadores, la experiencia de juego podria ser distinta
 */
public class frameRate : MonoBehaviour
{
    // Start is called before the first frame update
    public int target = 60;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }
}
