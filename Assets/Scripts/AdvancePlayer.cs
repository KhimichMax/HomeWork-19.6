using System;
using UnityEngine;

public class AdvancePlayer : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    
    private InteractionWithObject _interactionWithObject;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _interactionWithObject = GetComponent<InteractionWithObject>();
    }
    
    public void OpenLevelUpWindow(bool isOpen)
    {
        if (isOpen)
        {
            if (_interactionWithObject.IsInRadius)
            {
                _anim.SetBool("isOpen", true);
            }
            
        }
    }
}
