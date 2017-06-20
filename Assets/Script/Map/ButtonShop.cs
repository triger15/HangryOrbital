﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShop : TouchManager {

    public enum type {SettingToggleButton, ShopToggleButton, Candy1 , Candy2, Candy3, Candy4 };
    public type buttonType;

    public GameObject settingMenu = null;
    Animator settingAnim;
    static bool paused = false;
    static float originalTimeScale;
    static bool settingOn = false;

    public GameObject shopMenu = null;

    // Animator shopAnim;
    static bool shopOn = false;

        
    SaveManager save;


    public GUITexture buttonTexture = null;
    // Use this for initialization
    void Start () {
        settingAnim = settingMenu.GetComponent<Animator>();
        // shopAnim = shopMenu.GetComponent<Animator>();
        save = SaveManager.Instance;

        if (paused)
        {
            togglePause();
        }
    }

    // Update is called once per frame
    void Update () {
        touchInput(buttonTexture);
    }

    void OnFirstTouchBegan()
    {
        switch (buttonType)
        {
            case type.SettingToggleButton:
                toggleSetting();
                break;

            case type.ShopToggleButton:
                toggleShop();
                break;

            case type.Candy1:
                if (save.buyUpgrade(1))
                {
                    //Success Text
                }
                else
                {
                    //No money
                }   
                break;

            case type.Candy2:
                if (save.buyUpgrade(2))
                {
                    //Success Text
                }
                else
                {
                    //No money
                }
                break;

            case type.Candy3:
                if (save.buyUpgrade(3))
                {
                    //Success Text
                }
                else
                {
                    //No money
                }
                break;

            case type.Candy4:
                if (save.buyUpgrade(4))
                {
                    //Success Text
                }
                else
                {
                    //No money
                }
                break;
        } 
    }

    void OnFirstTouch()
    {

    }


    void OnFirstTouchEnded()
    {

    }


    void toggleSetting()
    {
        if (!shopOn&&!settingOn&&!paused)
        {
            settingOn = true;
            settingAnim.SetBool("Pause", true);
            togglePause();

        }
        else if (shopOn)
        {
            shopOn = false;
            settingOn = true;

            settingAnim.SetBool("Pause", true);
            // shopAnim.gameObject.SetActive(false);
            shopMenu.GetComponent<Canvas>().enabled = false;
            
        }
        else if(settingOn&&paused)
        {
            settingOn = false ;
            settingAnim.SetBool("Pause", false);
            togglePause();

        }
    }

    
    void toggleShop()
    {
        if (!settingOn)
        {
            if (!shopOn)
            {
                shopOn = true;
                // shopAnim.gameObject.SetActive(true);
                shopMenu.GetComponent<Canvas>().enabled = true;

                paused = false;
                togglePause();
                //shopAnim.SetBool("Pause", true);
            }
            else if (shopOn)
            {
                shopOn = false;
                // shopAnim.gameObject.SetActive(false);
                shopMenu.GetComponent<Canvas>().enabled = false;

                paused = true;
                togglePause();
                //shopAnim.SetBool("Pause", false);
            }
        }
        else if (settingOn)
        {

            shopOn = true;
            settingOn = false;

            settingAnim.SetBool("Pause", false);
            //  shopAnim.gameObject.SetActive(true);
            shopMenu.GetComponent<Canvas>().enabled = true;
        }
    }

    public static void togglePause()
    {
        if (!paused)
        {
            paused = !paused;
            originalTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }
        else if(paused)
        {
            paused = !paused;
            Time.timeScale = originalTimeScale;
        }
    }

}
