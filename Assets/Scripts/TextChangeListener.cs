using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextChangeListener : MonoBehaviour {
    string previousText;
    string currentText;

    public GameObject kotodamaBar;
	// Use this for initialization
	void Start () {
        previousText = gameObject.GetComponent<UnityEngine.UI.Text>().text;
    }

    // Update is called once per frame
    void Update() {
        currentText = gameObject.GetComponent<UnityEngine.UI.Text>().text;
        if (!previousText.Equals(currentText))
        {
            previousText = currentText;
            kotodamaBar.GetComponent<BulletBar>().kotodamaSize += currentText.Length;
        }
    }
}
