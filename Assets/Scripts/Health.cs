using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHP;
    private float _currentHP;
    private bool _isAlive;
    private Animator _anim;
    
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _currentHP = _maxHP;
        _isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        _currentHP -= damage;
        CheckIsAlive();   
    }

    private void CheckIsAlive()
    {
        if (_currentHP > 0)
        {
            _isAlive = true;
            _anim.SetTrigger("Hurt");
        }
        else
        {
            _isAlive = false;
            _anim.SetBool("isDead", _isAlive);
        }
    }

    private void DestroyGameObj()
    {
        Destroy(gameObject);
    }

    public float MaxHp
    {
        get => _maxHP;
        set => _maxHP = value;
    }
}
    