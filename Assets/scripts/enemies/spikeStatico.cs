using UnityEngine;

/*
 * enemigo, que es un pincho, solo sube y baja
 */
public class spikeStatico : EnemyController
{
    // Start is called before the first frame update

    void Start()
    {
        activo = true;
        player = GameObject.FindGameObjectWithTag("Player");
        target =player .transform;
        _spriteRendererPlayer =player. GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteCorrection();
    }

    public override void Action(bool cosas)
    {
        if (cosas)
        {
            var tarMod = target.position.magnitude;
            var thisMod = transform.position.magnitude;
            var epsilon = Mathf.Abs(tarMod - thisMod);

            //si no esta activo, es decir que no hace daño, en el instante de tiempo marcado e el game Manager, se activa
            if (activo == false)
            {
                activo = true;
                _animator.SetBool("pinchoArriba", true);
            }

            //si el jugador esta fuera del rango de epsilon, se desactiva
            else if (epsilon < disActivation)
            {
                activo = false;
                _animator.SetBool("pinchoArriba", false);
            }

            //en cualquier otro caso, si esta activado, en el siguiente instante de tiempo, se desactiva 
            else
            {
                activo = false;
                _animator.SetBool("pinchoArriba", false);
            }
        }
    }
}