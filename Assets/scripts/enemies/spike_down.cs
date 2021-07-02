using UnityEngine;

/*
 * enemigo que se desplaza un determinado numero de casillas y vuelve a su posicion original
 */
public class spike_down : EnemyController
{
    // Start is called before the first frame update
    private Vector3 FixedPosition;


    void Start()
    {
        activo = true;
        endPosition = transform.position;
        FixedPosition = transform.position; //posicion original

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        walls = GameObject.FindGameObjectsWithTag("wall");
        player = GameObject.FindGameObjectWithTag("Player");
        target =player .transform;
        _spriteRendererPlayer =player. GetComponentInChildren<SpriteRenderer>();
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
            Vector2 aux = transform.position;
            var tarMod = target.position.magnitude;
            var thisMod = transform.position.magnitude;
            var epsilon = Mathf.Abs(tarMod - thisMod); //calcula la distancia entre el enemigo y el jugador

            //si no esta en su posicion original vuelve
            if (transform.position != FixedPosition)
            {
                Vector3 start = transform.position;
                _boxCollider2D.enabled = false;
                endPosition = FixedPosition;
                hit = Physics2D.Linecast(start, endPosition,
                    blockingLayer);
                _boxCollider2D.enabled = true;

                if (hit.transform == null)
                {
                    moveToPoint = true;
                }
                
                else
                {
                    moveToPoint = false;
                    endPosition = aux;
                }
            }

            //si la distancia es menor al epsilon, comienza a moverse
            else if (epsilon < disActivation)
            {
                //asi se controla el tiempo que tarda en moverse, siempre en unidades de segundos
                if ((int) (Time.time) % tiempoActivacion == 0)
                {

                    Vector3 start = transform.position;
                    _boxCollider2D.enabled = false;
                    endPosition = new Vector3(endPosition.x , endPosition.y - distanceToMove, endPosition.z);
                    hit = Physics2D.Linecast(start, endPosition,
                        blockingLayer);
                    _boxCollider2D.enabled = true;

                    if (hit.transform == null)
                    {
                        moveToPoint = true;
                    }
                
                    else
                    {
                        moveToPoint = false;
                        endPosition = aux;
                    }
                }
            }
        }
    }
}