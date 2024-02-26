using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class InteractionWithObject : MonoBehaviour
{
    [SerializeField] private Transform _transformGameObj;
    [SerializeField] private float _range;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private Image _img;
    [SerializeField] private Text _text;

    private Color _colorImg;
    private Color _colorText;
    private bool isInRadius;
    
    

    private void Update()
    {
        isInRadius = Physics2D.OverlapCircle(_transformGameObj.position, _range, _playerMask);

        if (isInRadius)
        {
            _colorImg = _img.color;
            _colorText = _text.color;
            if (_colorImg.a != 1f)
            {
                _colorImg.a += _speed * Time.deltaTime;
                _colorImg.a = Mathf.Clamp(_colorImg.a, 0, 1);
                _img.color = _colorImg;
                _colorText.a += _speed * Time.deltaTime;
                _colorText.a = Mathf.Clamp(_colorText.a, 0, 1);
                _text.color = _colorText;
            }
        }
        else
        {
            _colorImg = _img.color;
            _colorText = _text.color;
            if (_colorImg.a >= 0f)
            {
                _colorImg.a -= _speed * Time.deltaTime;
                _img.color = _colorImg;
                _colorText.a -= _speed * Time.deltaTime;
                _text.color = _colorText;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(_transformGameObj == null)
            return;
        
        Gizmos.DrawWireSphere(_transformGameObj.position, _range);
    }

    public bool IsInRadius
    {
        get => isInRadius;
    }
}
