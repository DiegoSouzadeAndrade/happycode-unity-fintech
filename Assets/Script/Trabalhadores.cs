using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trabalhadores : MonoBehaviour {

	[HideInInspector]
	public int qtdTrabalhadores, valorTrabalhador, podeMinerar, tempoTrabalhador;
	private GameManager gm;
	private Criptomoedas cm;
	public Text txtQtdTrabalhadores;
	public Button bttnMineracao;
	public AudioClip latido;

	// Use this for initialization
	void Start () {
		txtQtdTrabalhadores.text = qtdTrabalhadores.ToString ();

		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		cm = GameObject.Find ("GameManager").GetComponent<Criptomoedas> ();
		tempoTrabalhador = 5;

	}
	
	// Update is called once per frame
	void Update () {
		if( podeMinerar == 1){
			podeMinerar = 3;
			StartCoroutine (QtdTrabalhadores());

		}
	}

	public IEnumerator QtdTrabalhadores (){
		yield return new WaitForSeconds(tempoTrabalhador);
		gm.valorMeuDinheiro += qtdTrabalhadores;
		gm.AtualizaValores();
		StartCoroutine (QtdTrabalhadores());
	}

	public void CompraTrabalhadores(){
		
		if(qtdTrabalhadores == 0){
			valorTrabalhador = 500;
		}
		if (gm.valorMeuDinheiro >= valorTrabalhador) {
			
			if(qtdTrabalhadores == 0){
				podeMinerar = 1;
			}
			cm.audioS.PlayOneShot (latido);
			qtdTrabalhadores += 1;
			txtQtdTrabalhadores.text = qtdTrabalhadores.ToString ();
			gm.valorMeuDinheiro -= valorTrabalhador;
			valorTrabalhador *= 3;
			gm.AtualizaValores ();

		} 
		else {
			gm.mensagem.text = "Você não possui dinheiro suficiente, o Minerador custa: " + valorTrabalhador ;
			gm.msgObject.GetComponent<Animation>().Play("Mensagem");
			cm.audioS.PlayOneShot (cm.sfxLever);
			gm.ultMensagem.text = gm.mensagem.text;
		}

	}
}
