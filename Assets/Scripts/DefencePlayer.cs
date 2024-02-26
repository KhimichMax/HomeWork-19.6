using UnityEngine;

public class DefencePlayer : MonoBehaviour
{
    private bool cantHit;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void Defence(bool isDefence)
    {
        if (isDefence)
        {
            cantHit = true;
            _anim.SetBool("isDefence", true);
        }
        else
        {
            cantHit = false;
            _anim.SetBool("isDefence", false);
        }
    }

    public bool CantHit
    {
        get => cantHit;
    }
}
