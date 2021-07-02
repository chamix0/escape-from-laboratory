using System;
using UnityEngine;

/*
 * se encarga del movimiento del jugador
 */
public class movement : MonoBehaviour
{
    public float moveSpeed = 5;
    private bool moveToPoint = false;
    public float distanceToMove = 1;
    private stats _stats; //ranking
    private bool col;
    private int tec;

    private Animator _animator;
    private Vector3 endPosition;
    private GameObject[] walls;
    private BoxCollider2D boxCollider;
    RaycastHit2D hit;
    public LayerMask blockingLayer;

  

    void Start()
    {
        tec = 0;
        _animator = GetComponentInChildren<Animator>();
        endPosition = transform.position;
        walls = GameObject.FindGameObjectsWithTag("wall");
        _stats = GetComponent<stats>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (moveToPoint)  transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
    }

    void Update()
    {

        Movement();
        _animator.SetInteger("move", tec);
        _stats.tiempo();
    }

    void Movement() //metodo encargado del movimiento del personaje 
    {
        //para no hacer mas de un movimiento de forma simultanea, mientras se este ejecutando el movimiento no se permitiran mas moviminetos
        if (puedeMover())
        {
            Vector2 start = transform.position; //la posicion desde la que queremos movernos
            Vector2 aux = transform.position;
            if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow)) //Left
            {

                boxCollider.enabled = false;
                endPosition = new Vector3(endPosition.x - distanceToMove, endPosition.y, endPosition.z);
                hit = Physics2D.Linecast(start, endPosition,
                    blockingLayer);
                if (hit.transform == null)
                {
                    tec = -1;
                    moveToPoint = true;
                }
                else
                {
                    moveToPoint = false;
                    endPosition = aux;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow)) //Right
            {
                boxCollider.enabled = false;
                endPosition = new Vector3(endPosition.x + distanceToMove, endPosition.y, endPosition.z);
                hit = Physics2D.Linecast(start, endPosition,
                    blockingLayer);
                if (hit.transform == null)
                {
                    tec = 1;
                    moveToPoint = true;
                }
                else
                {
                    moveToPoint = false;
                    endPosition = aux;
                }
            }
            else if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow)) //Up
            {
                boxCollider.enabled = false;
                endPosition = new Vector3(endPosition.x, endPosition.y + distanceToMove, endPosition.z);

                hit = Physics2D.Linecast(start, endPosition,
                    blockingLayer);
                if (hit.transform == null)
                {
                    tec = 2;
                    moveToPoint = true;
                }
                else
                {
                    moveToPoint = false;
                    endPosition = aux;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow)) //Down
            {
                boxCollider.enabled = false;
                endPosition = new Vector3(endPosition.x, endPosition.y - distanceToMove, endPosition.z);
                hit = Physics2D.Linecast(start, endPosition,
                    blockingLayer);
                if (hit.transform == null)
                {
                    tec = -2;
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


    bool puedeMover() //indica si el jugador se puede mover o no
    {
        if (transform.position != endPosition) return false;
       
        else
        {
            tec = 0;
            return true;
        }
    }

    



    public void SetPositionEnd(Vector3 position)
    {
        endPosition = position;
    }
}