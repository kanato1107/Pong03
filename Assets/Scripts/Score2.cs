using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score2 : MonoBehaviour {

    // スコア
    public int score;
    TextMesh score_text;

	// Use this for initialization
	void Start () {

        // スコアの文字列取得
        score_text = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

        // 数値を文字列に変換
        score_text.text = score.ToString();
	}
}
