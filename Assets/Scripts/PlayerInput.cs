using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private DamageDealler _damageDealler;
    
    private Vector2 _horizontalDirection;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _damageDealler = GetComponent<DamageDealler>();
    }

    private void Update()
    {
        _horizontalDirection.x = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        bool isAttack = Input.GetKeyDown(KeyCode.Z);
        
        _playerMovement.Move(_horizontalDirection.x, isJumpButtonPressed);
        _damageDealler.Attack(isAttack);
    }
    
}
