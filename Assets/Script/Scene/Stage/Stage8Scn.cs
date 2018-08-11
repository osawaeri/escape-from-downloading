﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage8Scn : MonoBehaviour {

    private GameObject gamestartCanvas;

    // ステージ8クリア判定
    public static bool stage8Clear = false;

    private void Awake()
    {
        gamestartCanvas = GameObject.Find("GameStartCanvas");
    }

    private void Start()
    {
        gamestartCanvas.SetActive(true);
    }

}