using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public string QuestName = string.Empty;
    private Renderer ThisRender = null;
    private CircleCollider2D ThisCollider = null;
    private AudioSource ThisAudio = null;

    private void Awake()
    {
        ThisRender = GetComponent<Renderer>();
        ThisCollider = GetComponent<CircleCollider2D>();
        ThisAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);

        if (QuestManager.GetQuestStatus(QuestName) == Quest.QUESTSTATUS.ASSIGNED)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        if (!gameObject.activeSelf)
            return;
        QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.COMPLETE);
        ThisRender.enabled = ThisCollider.enabled = false;
        if (ThisAudio != null)
            ThisAudio.Play();
    }
}
