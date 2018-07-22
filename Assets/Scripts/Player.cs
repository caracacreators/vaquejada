using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform[] playerPositions;
	public float velocidadeMovimentoPlayer;
	private string direcao;
	private int qualSlot;
	
	void Start () {
		qualSlot = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			direcao = "Cima";
		}
		else if(Input.GetKeyDown(KeyCode.DownArrow)){
			direcao = "Baixo";
		}

		QualDirecao();
		Movimentar();
		print(qualSlot);
	}

	void QualDirecao(){
		if (direcao == "Cima"){
			if (qualSlot == 0){
				qualSlot = 1;
				direcao = "";
			}
			else if (qualSlot == 1){
				qualSlot = 2;
				direcao = "";
			}

		}
		else if(direcao == "Baixo"){
			if(qualSlot == 2){
				qualSlot = 1;
				direcao = "";
			}
			else if(qualSlot == 1){
				qualSlot = 0;
				direcao = "";
			}
		}
	}

	void Movimentar(){
		if(qualSlot == 0){
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerPositions[0].position, velocidadeMovimentoPlayer * Time.deltaTime);
		}
		else if(qualSlot == 1){
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerPositions[1].position, velocidadeMovimentoPlayer * Time.deltaTime);
		}
		else{
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, playerPositions[2].position, velocidadeMovimentoPlayer * Time.deltaTime);
		}
	}
		
}


