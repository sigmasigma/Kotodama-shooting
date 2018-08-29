using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvadersMove : MonoBehaviour {


	public float downSpeed = 1;
	// Use this for initialization
	IEnumerator Start ()
	{
    while (true) {
      GetComponent<Rigidbody2D>().velocity = new Vector2(0,-1) * downSpeed;
      // 0.05秒動く
	  	yield return new WaitForSeconds (0.05f);
	 		//止まる
	  	GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	  	// 1秒待つ
      yield return new WaitForSeconds (0.7f);
	
    }
  }
	
	// Update is called once per frame
	void Update () {
		
	}
}
