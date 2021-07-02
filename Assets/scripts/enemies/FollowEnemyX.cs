using UnityEngine;

/*
 * el enemigo, te sigue en el eje x si te encuentras a cierta distancia de el
 */

public class FollowEnemyX : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        activo = true;
        endPosition = transform.position;

        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        walls = GameObject.FindGameObjectsWithTag("wall");
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        _spriteRendererPlayer = player.GetComponentInChildren<SpriteRenderer>();

        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteCorrection();
    }

    public override void Action(bool cosas)
    {
        if (cosas) //si el booleano es true permitira que se ejecute la accion
        {
            Vector2 aux = transform.position;

            if (target.position.x > transform.position.x) //si el personaje esta a la derecha del enemigo
            {
                _animator.SetBool("iz", false);
                Vector3 start = transform.position;
                _boxCollider2D.enabled = false;
                endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
                hit = Physics2D.Linecast(start, endPosition,
                    blockingLayer);
                _boxCollider2D.enabled = true;

                if (hit.transform == null) moveToPoint = true;

                else
                {
                    moveToPoint = false;
                    endPosition = aux;
                }
            }

            //si el personaje esta a la izquierda del enemigo
            else if (target.position.x < transform.position.x)
            {
                _animator.SetBool("iz", true);
                Vector3 start = transform.position;
                _boxCollider2D.enabled = false;

                endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
                hit = Physics2D.Linecast(start, endPosition,
                    blockingLayer);
                _boxCollider2D.enabled = true;

                if (hit.transform == null) moveToPoint = true;

                else
                {
                    moveToPoint = false;
                    endPosition = aux;
                }
            }
        }
    }
}