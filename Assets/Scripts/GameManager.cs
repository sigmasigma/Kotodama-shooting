using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject invaders;

    GameObject playerInstance;
    GameObject invadersInstance;

    bool isRestart = false;

	// Use this for initialization
	void Start () {
        playerInstance = Instantiate(player, new Vector3(0,-4,0), transform.rotation);
        invadersInstance = Instantiate(invaders, transform.position, transform.rotation);
        playerInstance.transform.parent = transform;
        invadersInstance.transform.parent = transform;
        isRestart = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isRestart == true && Input.GetKeyDown(KeyCode.Return))
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
                Start();
        }
    }

    public void restart()
    {
        isRestart = true;
    }
}
