using UnityEngine;
using UnityEngine.Tilemaps;

/*
 *la funcion de esta clase es que sirva como clase padre de todos los enemigos
 * 
 */
public abstract class EnemyController : MonoBehaviour
{
    public int disActivation = 2; //distancia de activacion de los enemigos
    public int tiempoActivacion = 2; //tiempo de activacion de los enemigos
    public float distanceToMove = 1; //numero de casillas en las que un enemigo se desplaza
    public float moveSpeed = 5; //velocidad de movimiento
    protected bool moveToPoint = false; //indica si puede moverse el enemigo o no
    public bool activo; //indica si el enemigo esta activo, es decir hace daño o no
    protected Vector3 pos;

    protected RaycastHit2D hit;
    public LayerMask blockingLayer;
    protected Vector3 endPosition; //posicion de destino
    protected Transform target; //objeto transform del jugador, que sirve parqa obtener su posicin
    protected GameObject player;
    protected SpriteRenderer _spriteRenderer; //objeto para controlar el sprite del enemigo
    protected SpriteRenderer _spriteRendererPlayer; //objeto para conocer el sprite del personaje

    protected Animator _animator; //objeto para controlar la animacion
    protected GameObject[] walls; //arary de paredes para controlar las colisiones
    protected BoxCollider2D _boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        activo = true;
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        _spriteRendererPlayer = player.GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        walls = GameObject.FindGameObjectsWithTag("walls");
    }

//movimiento a la posicion indicada por endPosition si el booleano se lo permite, depende de la clase heredada
    void FixedUpdate()

    {
        if (moveToPoint)
            transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
    }


    
    //metodo virtual que es la base que ejecuta el Game Manager por cada unidad de tiempo(segundos)
    public virtual void
        Action(bool cosas)
    {
        //rellenar en la clase heredada
    }

    /*
     con este metodo corrige la posicion del sprite, es decir, para que cuando el jugador este detras del enemigo,
     el enemigo estee por delante y cuando el personaje este por delante, el enemigo este por detras.
    */
    protected void spriteCorrection()
    {
        if (target.position.y > _spriteRenderer.transform.position.y)
            _spriteRenderer.sortingOrder = _spriteRendererPlayer.sortingOrder + 1;

        else _spriteRenderer.sortingOrder = _spriteRendererPlayer.sortingOrder - 1;
    }
}