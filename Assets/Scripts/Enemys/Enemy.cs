using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    public EnemyBaseState currentState;
    
    public PatrolState patrolState;
    public ChaseState chaseState;
    public AttackState attackState;
    
    [Header("Movement Data")]
    public float moveSpeed = 2f;
    public float chaseSpeed = 4f;
    public float stopingDistance;
    public float raioDePatrulha = 5f;
    public float tempoDePatrulha = 3f;
    
    [FormerlySerializedAs("detectionRadius")] [Header("Detetction Data")]
    public float detectionRange = 8f;
    public LayerMask obstacleLayers;
    
    //Referencias
    private Rigidbody2D _rb;
    public Transform player;
    public SpriteRenderer spriteRenderer;
    
    public bool isChasing;
    
    private Vector2 _randomDirection;
    private float _timer;
    private Vector2 originalPosition;
    private int _facingDirection = 1;

    private void Awake()
    {
        patrolState = new PatrolState(this, "patrol");
        chaseState = new ChaseState(this, "chase");
        attackState = new AttackState(this, "attacl");

        currentState = patrolState;
        currentState.Enter();

    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _timer = tempoDePatrulha;
        originalPosition = transform.position;
    }

    void Update()
    {
        currentState.LogicUpdate();
    }
    void FixedUpdate()
    {
        currentState.PhysicsUpdate();
        CanSeePlayer();
    }

    void CanSeePlayer()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.position - transform.position);
        if (ray.collider != null)
        {
            isChasing = ray.collider.transform == player;
        }
    }

    public void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        if (Vector2.Distance(player.position, transform.position) > stopingDistance)
        {
            if ((direction.x < 0 && transform.localScale.x > 0) ||
                (direction.x > 0 && transform.localScale.x < 0)) Flip();
            
            _rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            _rb.linearVelocity = Vector2.zero;
        }
        
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _rb.linearVelocity.y);
        //Colocar ataque mais pra frente
        
    }

    public void Patrulha()
    {
        if (_timer >= tempoDePatrulha)
        {
            if ((_randomDirection.x < 0 && transform.localScale.x > 0) ||
                (_randomDirection.x > 0 && transform.localScale.x < 0)) Flip();
            _randomDirection = Random.insideUnitCircle.normalized;
            _timer = 0;
        }
        
        _rb.linearVelocity = _randomDirection * (moveSpeed * 0.5f);
        
        if (Vector2.Distance(transform.position, originalPosition) > raioDePatrulha)
        {
            _randomDirection = (originalPosition - (Vector2)transform.position).normalized;
        }
        
    }

    public void SwitchState(EnemyBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
    private void Flip()
    {
        _facingDirection *= -1;
        transform.localScale = new Vector3(_facingDirection, 1, 1);
    }

    public bool CanAttack()
    {
        if (Vector2.Distance(player.position, transform.position) < stopingDistance) return true;
        else return false;

    }
    
    
}
