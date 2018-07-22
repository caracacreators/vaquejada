using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public float velocidadeMoeda;
	void Start () {

	}
	
	
	void Update () {
		transform.localPosition = new Vector3(transform.localPosition.x - velocidadeMoeda * Time.deltaTime, transform.localPosition.y, 0);
	}

	private void OnBecameInvisible() {
		Destroy(this.gameObject);
	}


	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player"){
			GameObject temp = GameObject.Find("GameController");
			temp.GetComponent<GameController>().pontos += 1;
			print(temp.GetComponent<GameController>().pontos);
			Destroy(this.gameObject);
		}
	}

}
