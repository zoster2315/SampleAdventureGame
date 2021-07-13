using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public float MaxSpeed = 10f;
    private RectTransform ThisTransform = null;

    private void Awake()
    {
        ThisTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        if (PlayerControl.PlayerInstance != null)
        {
            ThisTransform.sizeDelta = new Vector2(Mathf.Clamp(PlayerControl.Health, 0, 100), ThisTransform.sizeDelta.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float HealthUpdate = 0f;
        if (PlayerControl.PlayerInstance != null)
        {
            HealthUpdate = Mathf.MoveTowards(ThisTransform.rect.width, PlayerControl.Health, MaxSpeed);
        }
        ThisTransform.sizeDelta = new Vector2(Mathf.Clamp(HealthUpdate, 0, 100), ThisTransform.sizeDelta.y);
    }
}
