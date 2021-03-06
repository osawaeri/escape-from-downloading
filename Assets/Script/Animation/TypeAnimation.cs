﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// 参照HP
// http://pafu-of-duck.hatenablog.com/entry/2017/06/14/101139

public class TypeAnimation : MonoBehaviour
{

  [Multiline] public string[] sentences;
  [SerializeField] Text uiText;   // uiTextへの参照

  [SerializeField, Range(0.001f, 0.3f)] float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間

  private int currentNumber = 0; //現在表示している文章番号
  private string currentSentence = string.Empty;  // 現在の文字列
  private float timeUntilDisplay = 0; // 表示にかかる時間
  private float timeBeganDisplay = 1; // 文字列の表示を開始した時間
  private int lastUpdateCharCount = -1; // 表示中の文字数

  private bool isSkip = false;

  void Start()
  {
    SetNextSentence();
  }

  void Update()
  {

    // if(EventSystem.current.IsPointerOverGameObject()){
    //     return;
    // }

    // 文章の表示完了 / 未完了
    if (IsDisplayComplete())
    {
      //最後の文章ではない & ボタンが押された
      if (currentNumber < sentences.Length && isSkip == true)
      {
        SetNextSentence();
      }
      else if (currentNumber == sentences.Length && isSkip == true)
      {
        SceneSkip.Instance.skipToStage1();
      }
    }
    else
    {
      //ボタンが押された
      if (isSkip == true)
      {
        timeUntilDisplay = 0; //※1
      }
    }
    isSkip = false;

    //表示される文字数を計算
    int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentSentence.Length);
    //表示される文字数が表示している文字数と違う
    if (displayCharCount != lastUpdateCharCount)
    {
      uiText.text = currentSentence.Substring(0, displayCharCount);
      //表示している文字数の更新
      lastUpdateCharCount = displayCharCount;
    }
  }

  // 次の文章をセットする
  void SetNextSentence()
  {
    currentSentence = sentences[currentNumber];
    timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
    timeBeganDisplay = Time.time;
    currentNumber++;
    lastUpdateCharCount = 0;
  }

  bool IsDisplayComplete()
  {
    return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
  }

  public void skipSerif()
  {
    isSkip = true;
  }
}