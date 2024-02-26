using UnityEngine;

public class TimeOut : MonoBehaviour
{
    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void Resume()
    {
        Time.timeScale = 1f;
    }
}
