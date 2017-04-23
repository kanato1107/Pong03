using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    // ポーズの状態確認
    public static bool stopGame = false;
    // ボールの状態確認
    public static bool moveBall = false;
    // ゲーム継続状態確認
    public static bool moveGame = true;

    // 勝利判定用にスコアを取得
    private Score1 score1;
    private Score2 score2;

    public int maxPoint = 11;


	// Use this for initialization
	void Start () {

        // static変数の初期化(ゲーム開始時)
        stopGame = false;
        moveBall = false;
        moveGame = true;

        // スコアの取得
        score1 = GameObject.FindGameObjectWithTag("Score1").GetComponent<Score1>();
        score2 = GameObject.FindGameObjectWithTag("Score2").GetComponent<Score2>();
    }
	
	// Update is called once per frame
	void Update () {
		

        // ボールが発射できる状態の場合、スペースキーで発射
        if(Input.GetKeyDown(KeyCode.Space) && !moveBall && moveGame)
        {
            GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>().ShotBall();
            moveBall = true;

            GameObject.FindGameObjectWithTag("stop").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("move").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("wait").GetComponent<MeshRenderer>().enabled = false;
        }


        // ゲームプレイ中
        if (Input.GetKeyDown(KeyCode.A) && moveBall)
        {
            if (!stopGame)
            {
                // 一時停止
                stopGame = true;
                GameObject.FindGameObjectWithTag("stop").GetComponent<MeshRenderer>().enabled = true;
                GameObject.FindGameObjectWithTag("move").GetComponent<MeshRenderer>().enabled = false;

                // ポーズ背景を出す
                GameObject.FindGameObjectWithTag("BackColor").GetComponent<Image>().enabled = true;
                GameObject.FindGameObjectWithTag("Status").GetComponent<Text>().enabled = true;
            }
            else
            {
                // 再開
                stopGame = false;
                //GameObject.FindGameObjectWithTag("move").SetActive(true);
                GameObject.FindGameObjectWithTag("stop").GetComponent<MeshRenderer>().enabled = false;
                GameObject.FindGameObjectWithTag("move").GetComponent<MeshRenderer>().enabled = true;

                //　ポーズ背景解除
                GameObject.FindGameObjectWithTag("BackColor").GetComponent<Image>().enabled = false;
                GameObject.FindGameObjectWithTag("Status").GetComponent<Text>().enabled = false;
            }
        }

        // 一時停止中
        if(stopGame)
        {
            // タイトルへ戻る
            if(Input.GetKeyDown(KeyCode.S))
            {
                SceneManager.LoadScene("Title");
            }

            // ゲームリセット(Gameシーンをもう一度読み込む)
            if(Input.GetKeyDown(KeyCode.D))
            {
				SceneManager.LoadScene(Title.sc_name);
            }
        }


        // ゲームの勝利判定(11点先取)
        if(score1.score >= maxPoint)
        {
            // プレイヤー1の勝利
            moveGame = false;
            stopGame = true;

			// バグ回避
            GameObject.FindGameObjectWithTag("BackColor").GetComponent<Image>().enabled = true;
            GameObject.FindGameObjectWithTag("Status").GetComponent<Text>().enabled = true;
            GameObject.FindGameObjectWithTag("wait").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("result").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Status").GetComponent<Text>().text = "PLAYER1\nWINNER";
        }

        if(score2.score >= maxPoint)
        {
            // プレイヤー2の勝利
            moveGame = false;
            stopGame = true;

			// バグ回避
            GameObject.FindGameObjectWithTag("BackColor").GetComponent<Image>().enabled = true;
            GameObject.FindGameObjectWithTag("Status").GetComponent<Text>().enabled = true;
            GameObject.FindGameObjectWithTag("wait").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("result").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("Status").GetComponent<Text>().text = "PLAYER2\nWINNER";
        }

    }



   
}
