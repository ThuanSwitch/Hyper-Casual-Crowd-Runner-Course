using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataManager instance;
    [Header("Coins Text")]
    [SerializeField] private Text[] coinsText;
    private int coins;
    private void Awake()
    {
        if(instance != null)    
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
        coins = PlayerPrefs.GetInt("coins", 0);
    }
    void Start()
    {
         UpdateCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void UpdateCoinsText()
    {
        foreach (Text coinsText in coinsText)
        {
            coinsText.text = coins.ToString();
        }
    }
    public void AddCoins(int amout)
    {
        
        coins += amout; 
        Debug.Log(coins);
        UpdateCoinsText();
        PlayerPrefs.GetInt("coins", coins);
    }
}
