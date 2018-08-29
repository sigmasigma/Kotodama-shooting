using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBar : MonoBehaviour {

    public int kotodamaSize = 0;
    public int bulletNumber = 0;
    public int stringSizeForBullet = 15;
    public GameObject bulletNumberText;
    public GameObject valueText;
    // Use this for initialization
    void Start() {
        gameObject.GetComponent<UnityEngine.UI.Slider>().maxValue = stringSizeForBullet;
    }

    // Update is called once per frame
    void Update() {
        if (kotodamaSize > stringSizeForBullet)
        {
            while (kotodamaSize > stringSizeForBullet)
            {
                bulletNumber++;
                kotodamaSize -= stringSizeForBullet;
            }
        }

        gameObject.GetComponent<UnityEngine.UI.Slider>().value = kotodamaSize;
        valueText.GetComponent<UnityEngine.UI.Text>().text = kotodamaSize.ToString() + "/" + stringSizeForBullet.ToString();

        bulletNumberText.GetComponent<UnityEngine.UI.Text>().text = bulletNumber.ToString();

    }

    public void UseBullet()
    {
        if(bulletNumber > 0) {
            bulletNumber--;
        }
    }
}
