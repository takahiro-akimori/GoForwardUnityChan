using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;

	//キューブ自体
	private GameObject cube;

	//unitychan
	private GameObject unitychan;

	//AudioSource
	AudioSource audiosource;

	// Use this for initialization
	void Start(){
		
		//キューブとunitychanの情報を取得
		//this.cube = GameObject.Find("CubePrefab");
		//this.unitychan = GameObject.Find ("unitychan");
		audiosource = this.GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
			
	}

	//課題効果音
	void OnCollisionEnter2D(Collision2D col){

		//相手のobjectを取得
		string obname = col.gameObject.name;

		//状況分け
		//UnityChan
		if (obname == "UnityChan2D") {
			audiosource.Stop();
		}else{					//それ以外（cube同士とground）
			audiosource.Play();
		}

		Debug.Log (obname);
	}

}