using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    private TMP_Text livesText;

    private void Awake()
    {
        livesText = GetComponent<TMP_Text>();
    }

    public void UpdateLives(LivesController livesController)
    {
        livesText.text = "Lives: " + livesController.Lives.ToString();
    }
}
