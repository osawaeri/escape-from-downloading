﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    // ゲームスタート Canvas
    private Animator gameStartAnimator;

    private void Awake()
    {
        gameStartAnimator = GameObject.Find("CanvasObj").GetComponent<Animator>();
    }

    public void StartGameMethod()
    {
        GameObject.Find("StageManager").SendMessage("startTimer"); // タイマー開始
        GameObject.Find("Player").SendMessage("goRunning"); 
        GameObject.Find("Player").SendMessage("canInput"); // 入力可能にする
    }

    public void readyToOnemoreGame()
    {
        
        gameStartAnimator.enabled = false;
    }

}