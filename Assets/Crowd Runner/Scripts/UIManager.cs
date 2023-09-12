using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Element")]
    [SerializeField] private GameObject menePanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Slider progressBar;
    [SerializeField] private Text levelText;

    void Start()
    {
        progressBar.value = 0;  
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(false); 
        settingPanel.SetActive(false);
        levelText.text = "Level " + (ChunkManager.instance.GetLevel()+1);
        GameManager.onGameStateChanged +=GameStateChangedCallBack ;
    }
    private void OnDestroy() {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;    
    }
    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.GameOver)
        {
            ShowGameOver();
        }
        else if (gameState == GameManager.GameState.LevelComplete)
        {
            ShowLevelComplete();
        }
    }
    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }
    public void PlayeButonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        menePanel.SetActive(false);
        gamePanel.SetActive(true); 


    }
    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowLevelComplete ()
    {
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }
    public void ShowGameOver()
    {
        gamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState())
        {
            return;
        }
        float progress =PlayerController.instance.transform.position.z/ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;   
    }
    public void ShowSettingPanel()
    {
        settingPanel.SetActive(true);
    }
    public void HideSettingPanel()
    {
        settingPanel.SetActive(false);
    }
    
}
