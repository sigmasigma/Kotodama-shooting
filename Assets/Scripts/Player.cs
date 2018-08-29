﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// 弾プレハブ
	public GameObject bullet;
  	// 移動スピード
  	public float speed = 5;
    public GameObject slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// 右・左
    	float x = Input.GetAxisRaw ("Horizontal");
    	// 移動する向きを求める
    	Vector2 direction = new Vector2 (x, 0).normalized;
    	// 移動する向きとスピードを代入する
    	GetComponent<Rigidbody2D>().velocity = direction * speed;

		if (Input.GetKeyDown(KeyCode.Space)){
            // スペースで射撃
            if (slider.GetComponent<BulletBar>().bulletNumber > 0) {
                Instantiate(bullet, transform.position, transform.rotation);
                slider.GetComponent<BulletBar>().UseBullet();
            }
        }
	}
	void OnTriggerEnter2D (Collider2D c){
		if(c.gameObject.CompareTag("Invader_bullet") || c.gameObject.CompareTag("Invader")){
			
			death();
		}
	}
	void death(){

		Destroy(gameObject);
	}
}
