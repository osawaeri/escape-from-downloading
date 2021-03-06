﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpManager : SingletonMonoBehaviour<HpManager> {

    // プレイヤーHP
    private int playerHp;
    // プレイヤーHP表示テキスト
    private Text playerHpText;
    // HPバー
    private Slider slider;
    // HPバー背景画像
    private Image hpImage;

    public void setupHp ()
    {
        playerHpText = GameObject.Find("HP").GetComponent<Text>();
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        hpImage = GameObject.Find("Fill").GetComponent<Image>();
        playerHp = 100; // HPリセット
        slider.value = playerHp; // HP反映
        playerHpText.text = playerHp.ToString(); // HPテキスト表示
        playerHpColor();
    }

    // HP更新
    public void updatePlayerHp()
    {
        slider.value = playerHp; // HP値反映更新
        playerHpText.text = playerHp.ToString(); // HPテキスト表示更新
        playerHpColor();
    }

    public void playerHpEnemy()
    {
        playerHp--;
    }

    private void playerHpColor()
    {
        /// HPが10以下だったら
        /// HPバーの色を赤にする
        if (playerHp <= 10)
        {
            playerHpBarColorRed();
        }
        /// HPが30以下だったら
        /// HPバーの色を黄色にする
        else if (playerHp <= 30)
        {
            playerHpBarColorYellow();
        }
        /// HPが60以下だったら
        /// HPバーの色を緑にする
        else if (playerHp <= 60)
        {
            playerHpBarColorGreen();
        }
        /// HPが100以下だったら
        /// HPバーの色を青にする
        else if (playerHp <= 100)
        {
            playerHpBarColorBlue();
        }
    }

    // HPバーの色を青にする
    private void playerHpBarColorBlue()
    {
        hpImage.color = Color.blue;
    }

    // HPバーの色を緑にする
    private void playerHpBarColorGreen()
    {
        hpImage.color = Color.green;
    }

    // HPバーの色を黄色にする
    private void playerHpBarColorYellow()
    {
        hpImage.color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 0.0f / 255.0f, 255.0f / 255.0f); // 黄色
    }

    // HPバーの色を赤色にする
    private void playerHpBarColorRed()
    {
        hpImage.color = Color.red;
    }

}