using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Bar : MonoBehaviour {

    // バーの移動速度
    public float move_value = 0.07f;
    // バーの移動制限
    public float restriction_value = 3.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // ゲーム中かつポーズしていない場合
        if (!GameManager.stopGame && GameManager.moveGame)
        {
            // バーを動かす
            if (Input.GetKey(KeyCode.W))
            {
                if (transform.position.y < restriction_value)
                {
                    // ↑
                    transform.position += Vector3.up * move_value;
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (transform.position.y > restriction_value * -1)
                {
                    // ↓
                    transform.position += Vector3.down * move_value;
                }
            }

        }
	}
}
