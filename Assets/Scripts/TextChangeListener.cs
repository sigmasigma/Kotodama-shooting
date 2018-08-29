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
            int kotodamaNumber = 0;
            for (int i = 0; i < currentText.Length; i++)
            {
                if (IsKanji(currentText[i]))
                {
                    kotodamaNumber++;
                }
            }
            kotodamaBar.GetComponent<BulletBar>().kotodamaSize += kotodamaNumber;
        }
    }

    public static bool IsKanji(char c)
    {
        //CJK統合漢字、CJK互換漢字、CJK統合漢字拡張Aの範囲にあるか調べる
        return ('\u4E00' <= c && c <= '\u9FCF')
            || ('\uF900' <= c && c <= '\uFAFF')
            || ('\u3400' <= c && c <= '\u4DBF');
    }
}
