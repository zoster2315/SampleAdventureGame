using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTimer : MonoBehaviour
{
    public int SceneID = 0;
    public float TimeDelay = 5f;

    private void Start()
    {
        Invoke("LoadScene", TimeDelay);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneID);
    }
}
