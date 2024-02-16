using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private Transform _attackCollTr;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private float _damage = 20f;
    [SerializeField] private float _countRecharge = 2f;
    [SerializeField] private float _currentRecharge = 0;
    
    
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Attack(bool isAttack)
    {
        if (isAttack)
        {
            Debug.Log(isAttack);
            if (_currentRecharge >= _countRecharge)
            {
                _anim.SetTrigger("isAttack");
                Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(_attackCollTr.position, _attackRange, _enemyMask);
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.gameObject.GetComponent<Health>().TakeDamage(_damage);
                }
                _currentRecharge = 0;
            }else
            {
                _currentRecharge += Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(_attackCollTr == null)
            return;

        Gizmos.DrawWireSphere(_attackCollTr.position, _attackRange);
    }
}
