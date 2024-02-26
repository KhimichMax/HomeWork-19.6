using DefaultNamespace;
using UnityEngine;

public class PlayerDamageDealler : MonoBehaviour, IDamageDealler
{
    [SerializeField] private Transform _attackCollTr;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private float _damage = 20f;
    
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    
    public void Attack(bool isAttack)
    {
        if (isAttack)
        {
            _anim.SetTrigger("isAttack");
        }
    }

    private void GetDamageEnemy()
    {
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(_attackCollTr.position, _attackRange, _enemyMask);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Health>().TakeDamage(_damage);
        }
    }

    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }
}
