﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOperation : MonoBehaviour {
	
	// プレイヤー移動速度
	public float speed = 0.7f;
	
	void Update () {
		// Wで前進
		if (Input.GetKey (KeyCode.W)) {
			this.transform.position -= transform.up * speed * Time.deltaTime;
		}
		// Spaceでジャンプ
		if (Input.GetKeyDown (KeyCode.Space)) {
			this.transform.position += new Vector3 (0, 1.0f, 0);
		}
		// Aで右 
		if (Input.GetKey (KeyCode.A)) {
			transform.position -= transform.right * speed * Time.deltaTime;
		}
		// Dで左 
		if (Input.GetKey (KeyCode.D)) {
			transform.position += transform.right * speed * Time.deltaTime;
		}
		// Sで後進
		if (Input.GetKey (KeyCode.S)) {
			transform.position += transform.up * speed * Time.deltaTime;
		}
		// 右矢印で右回り
		if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.Rotate(new Vector3(0, 0, 1));

		}
		// 左矢印で左回り
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.Rotate(new Vector3(0, 0, -1));
		}
			
//		X位置 15.0f以上 GameClear 移動
//		if (this.transform.position.x >= 15.0f) {
//			SceneManager.LoadScene ("GameClear");
//		}
	}

    // プレイヤーをステージ1スタート位置に動かす
    public void stage1Start () {
        this.transform.position = new Vector3(22.0f, 1.04f, 0);
	}

	void OnCollisionEnter(Collision col){
		
		// エネミーに当たると      
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.SendMessage("PlayerHpMinusE"); // HP1減らす
		}

		// コインに当たると
		if(col.gameObject.tag=="Coin"){
			GameObject.Find("MoneyObj").SendMessage("getCoin"); // 所持金1増やす
            GameObject.Find("MoneyObj").SendMessage("updateCoin"); // 所持金更新
			Destroy(gameObject); // コイン消滅
		}

        // ダウンロードに当たると      
        if (col.gameObject.tag == "Download")
        {
            GameObject.Find("PlayerManager").SendMessage("gameOver"); // ゲームオーバー
        }
        // ゴールしたら
        if (col.gameObject.tag == "Goal")
        {
            GameObject.Find("StageManager").SendMessage("stopTimer"); // タイマー停止
            GameObject.Find("PlayerManager").SendMessage("gameClear"); // ゲームクリア
        }
	}

}