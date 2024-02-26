using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyDamageDealler _enemyDamageDealler;
    
    [SerializeField] private float _speed, _timeToRevert;
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _attackColl, _detectColl;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private float _detectRange = 0.5f;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _pointToBack;
    [SerializeField] private float stoppingDistance;
    
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private Vector2 currentPosition;
    private bool _canHit;
    private bool isRight = true;
    private bool _isDetectAttack;
    private bool _isDetectChase;
    private Rigidbody2D rb;
    private float currentState, currentTimeToRevert;
    private bool currnetStateEnemy = true;

    private void Start()
    {
        _enemyDamageDealler = GetComponent<EnemyDamageDealler>();
        rb = GetComponent<Rigidbody2D>();
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
    }

    private void Update()
    {
        _isDetectChase = Physics2D.OverlapCircle(_detectColl.position, _detectRange, _playerMask);
        if (currnetStateEnemy)
        {
            Patrol();    
        }

        if (!currnetStateEnemy)
        {
            Angry();
        }
    }

    private void Patrol()
    {
        if (currentTimeToRevert >= _timeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }
        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                rb.velocity = Vector2.right * _speed;
                break;
            case REVERT_STATE:
                if ((transform.localScale.x < 0 && isRight) || (transform.localScale.x > 0 && !isRight))
                {
                    transform.localScale *= new Vector2(-1, 1);
                }
                _speed *= -1;
                currentState = WALK_STATE;
                break;
        }
        _anim.SetFloat("Velocity", rb.velocity.magnitude);
        
        if (_isDetectChase)
        {
            currnetStateEnemy = false;
        }
    }

    private void Angry()
    {
        _isDetectAttack = Physics2D.OverlapCircle(_attackColl.position, _attackRange, _playerMask);
        if (_isDetectChase)
        {
            if ((transform.position.x > _player.position.x && transform.localScale.x > 0) || 
                (transform.position.x < _player.position.x && transform.localScale.x < 0))
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            
            if (Vector2.Distance(transform.position, _player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.position, 0.5f * Time.deltaTime);
            }else if (Vector2.Distance(transform.position, _player.position) <= stoppingDistance)
            {
                if (_isDetectAttack)
                {
                    _canHit = true;
                    _enemyDamageDealler.Attack(_canHit);
                    
                }else if (!_isDetectAttack)
                {
                    _canHit = false;
                }
            }
            currentPosition = transform.position;
        }else if (!_isDetectChase)
        {
            transform.position =
                Vector2.MoveTowards(transform.position, _pointToBack.position, 0.3f * Time.deltaTime);
            if ((currentPosition.x > _pointToBack.position.x && transform.localScale.x > 0) || 
                (currentPosition.x < _pointToBack.position.x && transform.localScale.x < 0))
            {
                transform.localScale *= new Vector2(-1, 1);
            }
        }
    }

    
    
    private void OnDrawGizmosSelected()
    {
        if (_detectColl == null)
            return;
        if (_attackColl == null)
            return;
        
        Gizmos.DrawWireSphere(_detectColl.position, _detectRange);
        Gizmos.DrawWireSphere(_attackColl.position, _attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currnetStateEnemy)
        {
            if (collision.CompareTag("EnemyStopper"))
            {
                isRight = !isRight;
                currentState = IDLE_STATE;
            }
        }

        if (!_isDetectChase)
        {
            if (collision.CompareTag("PointReturn"))
            {
                currnetStateEnemy = true; 
            }
        }
    }
}
