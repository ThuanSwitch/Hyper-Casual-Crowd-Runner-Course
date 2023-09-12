using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
// using UnityEngine.UI;
using Image = UnityEngine.UI.Image;


public class SettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header(" Elements ")]
    [SerializeField] private SoundsManeger soundsManeger;
    [SerializeField] private Sprite optionOnSprite;
    [SerializeField] private Sprite optionOffSprite;    
    [SerializeField] private Image soundButtonImage;

    [Header("Setting")] 
    private bool soundState = true;
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Setup()
    {
        if (soundState)
        {
            DisableSounds();
        }
        else
        {
            EnableSounds();
        }
    }
    public void ChangeSoundState ()
    {
        if (soundState)
        {
            DisableSounds();
        }
        else
        {
            EnableSounds();
        }
        soundState = !soundState;
    }
    void DisableSounds ()
    {
        soundsManeger.DisableSounds();
        soundButtonImage.sprite = optionOffSprite;
    }
    void EnableSounds ()
    {
        soundsManeger.EnableSounds();
        soundButtonImage.sprite = optionOnSprite;
    }

}
