
using UnityEngine;

/*
 * la luz en la mecanica de luces que esta encima del personaje
 */
public class luz : MonoBehaviour
{
    public Transform target;
    

    private void Start()
    {
        target= GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 0, -3));
        transform.position = targetPosition;
    }
}
