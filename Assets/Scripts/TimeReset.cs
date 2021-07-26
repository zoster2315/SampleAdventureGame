using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeReset : MonoBehaviour
{
    public float ResetTime = 5f;

    void Start()
    {
        Invoke("Reset", ResetTime);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl.Reset();
        QuestManager.Reset();
        //SceneManager.LoadScene(1);
    }
}
