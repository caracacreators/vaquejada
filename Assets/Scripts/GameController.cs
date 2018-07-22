using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public float velocidadeDoCenario;
	public GameObject coin;
	public GameObject[] cenarios, spawnMoedas;
	public int pontos;
	public float tempo;
	private float tempTemp, tempTempoMoedas;
	public bool trocarCena;
	private bool final = false;
	public float tempoSpawnMoedas;


	void Start () {
		tempTempoMoedas = tempoSpawnMoedas;
		Instantiate(cenarios[0], new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Cena>().velocidadeDeMovimento = velocidadeDoCenario * -1;
		Instantiate(cenarios[1], new Vector3(12.8f, 0, 0), Quaternion.identity).GetComponent<Cena>().velocidadeDeMovimento = velocidadeDoCenario * -1;

	}
	
	void Update () {
		ControlarACena();
		print(pontos);
		tempTempoMoedas -= 1 * Time.deltaTime;
		if (tempTempoMoedas <= 0){
			tempTempoMoedas = tempoSpawnMoedas;
			Instantiate(coin, spawnMoedas[Random.Range(0, 3)].transform.position, Quaternion.identity);
		}

	}

	public void ControlarACena(){
		if(!final){
			if (pontos < 40){
				if (trocarCena){
					MovimentarCenario();
					trocarCena = false;
				}
			}else{
				print("Finallll");
				CenarioFinal();
			}
		}
	}

	public void CenarioFinal(){
		final = true;
		GameObject cenario = Instantiate(cenarios[3], new Vector3(12.6f, 0, 0), Quaternion.identity);
		cenario.GetComponent<Cena>().velocidadeDeMovimento = velocidadeDoCenario * -1;
	}

	public void MovimentarCenario(){
		if(!final){
			GameObject cenario = Instantiate(cenarios[Random.Range(0, 2)], new Vector3(12.6f, 0, 0), Quaternion.identity);
			cenario.GetComponent<Cena>().velocidadeDeMovimento = velocidadeDoCenario * -1;
		}
		else{
			print("Aqui");
			CenarioFinal();
		}
		
	}
}
