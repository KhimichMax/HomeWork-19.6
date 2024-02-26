using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryNextScene : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private GameObject _player;
    [SerializeField] private int _numNextScene = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == _player.CompareTag("Player"))
        {
            _gameObject.SetActive(true);
            StartCoroutine("StartNextScene");
        }
    }
    
    private IEnumerator StartNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(_numNextScene);
    }
}
