using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private GameObject[] _backgrounds;
    [SerializeField] private Transform _hero;
    [SerializeField] private Transform _startPositionHero;
    [SerializeField] private float _movingSpeed;

    private void Update()
    {
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            _backgrounds[i].transform.position =
                new Vector3((_hero.position.x - _startPositionHero.position.x) * _movingSpeed * i,
                    _backgrounds[i].transform.position.y, _backgrounds[i].transform.position.z);
        }
    }
}
