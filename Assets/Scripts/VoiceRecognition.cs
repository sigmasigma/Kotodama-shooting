using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour
{

    private DictationRecognizer dicRecognizer;

    void Start()
    {
        dicRecognizer = new DictationRecognizer();
        dicRecognizer.InitialSilenceTimeoutSeconds = 1000f;
        // 確定
        dicRecognizer.DictationResult += (text, confidence) =>
        {
            
            //			System.Diagnostics.Process.Start(path);
        };
        // 推測
        dicRecognizer.DictationHypothesis += (text) => {
            // 推測時にする処理
            gameObject.GetComponent<UnityEngine.UI.Text>().text = text;
            GUIUtility.systemCopyBuffer = text;
        };
        // 停止時
        dicRecognizer.DictationComplete += (completeCause) =>
        {
            // 要因がタイムアウトなら再び起動
            if (completeCause == DictationCompletionCause.TimeoutExceeded)
                dicRecognizer.Start();
        };
        dicRecognizer.Start();
    }

    void update()
    {
    }
}
