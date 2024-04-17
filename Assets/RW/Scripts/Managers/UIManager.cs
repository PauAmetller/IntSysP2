using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // 1

    public Text sheepSavedText; // 2
    public Text sheepDroppedText; // 3
    public Text timerText;
    public Text timerText_gameOver;
    public GameObject gameOverWindow; // 4
    private float Timer = 0;
    public bool timerStop = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!timerStop)
        {
            Timer += Time.deltaTime;
            timerText.text = Timer.ToString("F1");
        } else
        {
            timerText_gameOver.text = timerText.text + " seconds";
        }
    }

    public void UpdateSheepSaved() // 1
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() // 2
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
