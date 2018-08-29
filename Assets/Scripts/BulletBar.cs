using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBar : MonoBehaviour {

    public int kotodamaSize = 0;
    public int bulletNumber = 0;
    public GameObject bulletNumberText;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (kotodamaSize > 30)
        {
            while (kotodamaSize > 30)
            {
                bulletNumber++;
                kotodamaSize -= 30;
            }
        }

        gameObject.GetComponent<UnityEngine.UI.Slider>().value = kotodamaSize;
        bulletNumberText.GetComponent<UnityEngine.UI.Text>().text = bulletNumber.ToString();
    }

    public void UseBullet()
    {
        if(bulletNumber > 0) {
            bulletNumber--;
        }
    }
}
