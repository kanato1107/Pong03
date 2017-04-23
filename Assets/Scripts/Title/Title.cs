using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	// シーンの名前保管
	public static string sc_name = "";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        // 各ボタンでゲームシーンへ移動
		if(Input.GetKeyDown(KeyCode.A))
        {
			sc_name = "Game";
			SceneManager.LoadScene (sc_name);
        }

		if(Input.GetKeyDown(KeyCode.S))
		{
			sc_name = "Game2";
			SceneManager.LoadScene (sc_name);
		}

	}
}
