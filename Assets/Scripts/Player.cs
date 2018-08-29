using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  	// 移動スピード
  	public float speed = 5;
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

		if (Input.GetKey(KeyCode.Space)){
			// スペースで射撃
			
		}
	}
}
