using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal01 : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // あたり判定
    private void OnTriggerEnter(Collider other)
    {
        // タグでボールを確認
        if(other.tag == "Ball")
        {

            // プレイヤー2に1点プラス
            GameObject.FindGameObjectWithTag("Score2").GetComponent<Score2>().score += 1;

            // ボールを初期化する
            other.gameObject.GetComponent<Ball>().Init();

            // 説明入れ替え
            GameObject.FindGameObjectWithTag("wait").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("move").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("stop").GetComponent<MeshRenderer>().enabled = false;

            
        }
    }
}
