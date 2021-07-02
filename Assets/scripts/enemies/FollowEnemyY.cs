using UnityEngine;

/*
 * el enemigo persigue al jugador en el eje Y
 */
public class FollowEnemyY : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        endPosition = transform.position;
        activo = true;
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
        if (cosas)
        {
            Vector2 aux = transform.position;

            {
                //mover al enemigo hacia arriba 
                if (target.position.y > transform.position.y)
                {
                    _animator.SetBool("up", true);
                    Vector3 start = transform.position;
                    _boxCollider2D.enabled = false;
                    endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);
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
                //mover al enemigo hacia abajo 
                else if (target.position.y < transform.position.y)
                {
                    _animator.SetBool("up", false);
                    Vector3 start = transform.position;
                    _boxCollider2D.enabled = false;
                    endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
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
}