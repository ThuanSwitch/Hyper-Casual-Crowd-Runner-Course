using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManeger : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Sounds")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource doorHitSound;
    [SerializeField] private AudioSource ruunersDieSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;
    void Start()
    {
        PlayerDetection.onDoorsHit += PlayDoorHitSound;
        GameManager.onGameStateChanged += GameStateChangedCallback;
        Enemy.onRunnersDie += GameOverDieSound;
    }
    private void OnDestroy() {
        PlayerDetection.onDoorsHit -= PlayDoorHitSound; 
        GameManager.onGameStateChanged -= GameStateChangedCallback;
        Enemy.onRunnersDie -= GameOverDieSound;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void PlayDoorHitSound()
    {
        doorHitSound.Play();    
    }
    private void GameOverDieSound() 
    {
        ruunersDieSound.Play(); 
    }
    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
        {
            levelCompleteSound.Play();
        } 
        else if (gameState == GameManager.GameState.GameOver)
        {
            gameOverSound.Play();   
        }
    }
    public void DisableSounds()
    {
        doorHitSound.volume = 0;    
        ruunersDieSound.volume = 0; 
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
        buttonSound.volume = 0; 
    }
    public void EnableSounds()
    {
        doorHitSound.volume = 1;    
        ruunersDieSound.volume = 1; 
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1; 
        buttonSound.volume = 1; 
    }

}
