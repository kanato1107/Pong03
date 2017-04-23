using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    // コンポーネント格納
    private Rigidbody rigidbody;

    // 速度の一時保存
    private Vector3 vel;

	// Use this for initialization
	void Start () {

        // コンポーネント取得
        rigidbody = GetComponent<Rigidbody>();

        // 初期化
        rigidbody.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Z軸がずれないように補正し続ける
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        // 角度固定
        transform.eulerAngles = new Vector3(90, 0, 0);

        if (GameManager.stopGame)
        {
            // ボールの一時停止
            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            if (rigidbody.velocity != Vector3.zero)
            {
                // ボールの速度を保存
                vel = rigidbody.velocity;
            }

            if (GameManager.moveBall)
            {
                // ボールに速度を与える
                rigidbody.velocity = vel;
            }
        }
    }

    // ボールの初期化
    public void Init()
    {
        // ボールは動いてない状態にする
        GameManager.moveBall = false;

        // ポーズと同時にゴールした場合の回避内容
        GameManager.stopGame = false;

        // 中央にボールを戻す
        transform.position = new Vector3(0, 0, 0);

        // ボールの速度を0にする
        rigidbody.velocity = Vector3.zero;
        vel = Vector3.zero;
    }

    // -1か1を返す関数
    private int Get2Option()
    {
        int n = Random.Range(1, 3);

        switch(n)
        {
            case 1:
                n = -1;
                break;

            case 2:
                n = 1;
                break;

            default:
                n = 1;
                break;
        }

        return n;
    }

    // ボールを発射する関数
    public void ShotBall()
    {
        // ボールに初速を与える(範囲ランダム)
        float x = Random.Range(6.0f, 9.0f) * Get2Option();
        float y = Random.Range(6.0f, 9.0f) * Get2Option();     
        
        // 発射
        rigidbody.AddForce(x, y, 0, ForceMode.VelocityChange);        
    }
}
