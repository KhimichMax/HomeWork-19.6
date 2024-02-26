using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayableDirector _director;
    
    private RuntimeAnimatorController playerContr;
    private bool fix = false;

    private void OnEnable()
    {
        playerContr = _anim.runtimeAnimatorController;
        _anim.runtimeAnimatorController = null;
    }

    void Update()
    {
        if (_director.state != PlayState.Playing && !fix)
        {
            fix = true;
            _anim.runtimeAnimatorController = playerContr;
        }
    }
}
