using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// 弾プレハブ
	public GameObject bullet;
  	// 移動スピード
  	public float speed = 5;
    public GameObject canvas;
    public GameObject initGame;
    GameObject slider;
    GameObject gameOverText;

    // public GameObject slider;
    // public GameObject gameOverText;

    // Use this for initialization
    void Start () {
        GameObject canvasInstance = Instantiate(canvas, new Vector3(0,0,0), transform.rotation);
        canvasInstance.transform.parent = transform.root;
        slider = canvasInstance.GetComponentInChildren<UnityEngine.UI.Slider>().gameObject;
        gameOverText = canvasInstance.transform.Find("GameOver").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		// 右・左
    	float x = Input.GetAxisRaw ("Horizontal");
    	// 移動する向きを求める
    	Vector2 direction = new Vector2 (x, 0).normalized;

        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // 移動量を加える
        pos += direction * speed * Time.deltaTime;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;

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
    
    public void death(){
        gameOverText.GetComponent<UnityEngine.UI.Text>().text = "GameOver\nPress Enter";
        transform.root.gameObject.GetComponent<GameManager>().restart();
		Destroy(gameObject);
	}
}
