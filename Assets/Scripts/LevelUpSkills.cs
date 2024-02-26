using UnityEngine;
using UnityEngine.UI;

public class LevelUpState : MonoBehaviour
{
    [SerializeField] private Button _buttonDamage;
    [SerializeField] private Button _buttonHealth;
    [SerializeField] private Animator _anim;
    private PlayerDamageDealler _playerDamageDealler;
    private Health _health;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerDamageDealler = GetComponent<PlayerDamageDealler>();
        _health = GetComponent<Health>();
    }

    public void DamageUp()
    {
        _playerDamageDealler.Damage += 20f;
        _buttonDamage.interactable = false;
        _anim.SetBool("isOpen", false);
    }

    public void HealthUp()
    {
        _health.MaxHp += 50f;
        _buttonHealth.interactable = false;
        _anim.SetBool("isOpen", false);
    }
}
