using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cena : MonoBehaviour {

	public float velocidadeDeMovimento;
	GameObject gameController;
	private Transform cenarioTransform;
	public string cenarioID;
	private bool movimentar = true;
	void Start () {
		cenarioTransform = GetComponent<Transform>();
		gameController = GameObject.Find("GameController");
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (movimentar){
			MovimentarCena();
		}
		if (cenarioTransform.position.x < -12.87f && cenarioID != "Final"){
			Destruir();
		}
		else if(cenarioTransform.position.x < 0 && cenarioID == "Final"){
			
			FinalDaFase();
			movimentar = false;
		}
	}

	private void MovimentarCena(){
		cenarioTransform.position = new Vector3(cenarioTransform.position.x + (velocidadeDeMovimento * Time.deltaTime), 0, 0);
	}

	private void FinalDaFase(){
		cenarioTransform.position = new Vector3(0, 0, 0);
	}

	private void Destruir() {
		gameController.GetComponent<GameController>().trocarCena = true;
		Destroy(this.gameObject);
	}

}
