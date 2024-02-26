using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerDamageDealler _playerDamageDealler;
    private DefencePlayer _defencePlayer;
    private AdvancePlayer _advancePlayer;
    
    private Vector2 _horizontalDirection;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerDamageDealler = GetComponent<PlayerDamageDealler>();
        _defencePlayer = GetComponent<DefencePlayer>();
        _advancePlayer = GetComponent<AdvancePlayer>();
    }

    private void Update()
    {
        _horizontalDirection.x = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
        bool isAttack = Input.GetKeyDown(KeyCode.Z);
        bool isAdvance = Input.GetKeyDown(KeyCode.E);
        bool isDefence = Input.GetKey(KeyCode.X);
        
        _playerMovement.Move(_horizontalDirection.x, isJumpButtonPressed);
        _playerDamageDealler.Attack(isAttack);
        _defencePlayer.Defence(isDefence);
        _advancePlayer.OpenLevelUpWindow(isAdvance);
    }
}
