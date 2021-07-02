
using UnityEngine;
//esta clase simplemente es para que una posicion este marcada como enemigo
public class EnemyStop : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        activo = true;
        
        player = GameObject.FindGameObjectWithTag("Player");
        target =player .transform;
        _spriteRendererPlayer =player. GetComponentInChildren<SpriteRenderer>();

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteCorrection();
    }
}
