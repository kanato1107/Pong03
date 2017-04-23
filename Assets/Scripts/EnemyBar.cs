using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// DOTween
using DG.Tweening;

public class EnemyBar : MonoBehaviour {

    // ボール
    [SerializeField]
    GameObject ball;

    // ボールの座標
    private Vector3 ballPos;

    // 思考カウンター
    int think_cnt;

    // Use this for initialization
    void Start()
    {
        // 初期化
        think_cnt = 0;

        // ボールの座標を取得
        ballPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.stopGame && GameManager.moveBall)
        {
            // 思考カウンターを数える
            think_cnt++;

            if (think_cnt > 6)
            {
                // ボールの座標を取得
                ballPos = ball.transform.position;

                // 移動
                if(ballPos.y <= transform.position.y)
                {
                    // [範囲ランダム秒]かけてボールに近づくように振る舞う
                    transform.DOLocalMove(new Vector3(transform.position.x, transform.position.y - Random.Range(1.6f, 1.8f), 0), Random.Range(0.15f, 0.25f)).SetEase(Ease.InOutQuart);
                }
                else
                {
                    // [範囲ランダム秒]かけてボールに近づくように振る舞う
                    transform.DOLocalMove(new Vector3(transform.position.x, transform.position.y + Random.Range(1.6f, 1.8f), 0), Random.Range(0.15f, 0.25f)).SetEase(Ease.InOutQuart);
                }

                think_cnt = 0;
            }
        }
    }
}
