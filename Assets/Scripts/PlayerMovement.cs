using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float _jumpForce = 600f;
    [SerializeField] private bool _isGrounded;
    [SerializeField] private Transform _groundCollTr;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _rangeGround = 0.07f;

    private float currentHorizontalMovement;
    private Animator _anim;
    private Rigidbody2D rb;
    private bool faceRigth = true;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Walk(float move)
    {
        rb.velocity = new Vector2(move * _speed, rb.velocity.y);
        _anim.SetFloat("Velocity", Mathf.Abs(move));
        currentHorizontalMovement = move;
    }

    private void Jump(bool isJump)
    {
        if (isJump && _isGrounded)
        {
            rb.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void Flip()
    {
        if ((currentHorizontalMovement > 0 && !faceRigth) || (currentHorizontalMovement < 0 && faceRigth))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRigth = !faceRigth;
        }
    }

    private void CheckingGround()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCollTr.position, _rangeGround, _groundMask);
        _anim.SetBool("isJump", _isGrounded);
    }

    public void Move(float moveHor, bool jump)
    {
        CheckingGround();
        Walk(moveHor);
        Flip();
        Jump(jump);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (_groundCollTr == null)
            return;
        
        Gizmos.DrawWireSphere(_groundCollTr.position, _rangeGround);
    }
}
