using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; // 1

    [HideInInspector]
    public int sheepSaved; // 2

    [HideInInspector]
    public int sheepDropped; // 3

    public int sheepDroppedBeforeGameOver; // 4
    public SheepSpawner sheepSpawner; // 5
    public UIManager timer;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved();
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false; 
        sheepSpawner.DestroyAllSheep();
        timer.timerStop = true;
        UIManager.Instance.ShowGameOverWindow();
    }

    public void DroppedSheep()
    {
        sheepDropped++; 
        UIManager.Instance.UpdateSheepDropped();


        if (sheepDropped == sheepDroppedBeforeGameOver) 
        {
            GameOver();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }

}
