using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour {

	int position_x = 0;
	public int vec_x = 1;
	public int xSpeed = 200;
	public float downSpeed = 100;
	public GameObject invaderBullet;
	// Use this for initialization
  IEnumerator Start ()
  {
    while (true) {
			if((vec_x > 0 && position_x >= 3) || (vec_x < 0 && position_x <= -3)){
				vec_x *= -1;
			}
      GetComponent<Rigidbody2D>().velocity = new Vector2(vec_x * xSpeed, -1 * downSpeed) ;
			position_x += vec_x;
      // 0.05秒動く
	  	yield return new WaitForSeconds (0.05f);
	 		//止まる
	  	GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	  	// 1秒待つ間に射撃する
      for (int i = 0; i<5; i++){
				yield return new WaitForSeconds (0.2f);
				if (Random.Range(0f,100f) > 92f){
					Instantiate(invaderBullet,transform.position,transform.rotation);
				}
			}
    }
  }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D c){
		if(c.gameObject.CompareTag("Player_bullet")){
				Destroy(c.gameObject);
				Destroy(gameObject);
		}
	}
}
