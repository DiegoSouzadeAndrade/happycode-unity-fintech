using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public Text mensagem, ultMensagem, meuDinheiro, meuBitcoin, meuDodgecoin, meuLitecoin, horas;
	public int valorMeuBitcoin, valorMeuDodgecoin, valorLitecoin;
	public float valorMeuDinheiro;
	public GameObject msgObject;
	private GameObject janelaLoja;


	// Use this for initialization
	void Start () {
		AtualizaValores ();
		mensagem.text = "Comece a minerar Clicando no botão";
		msgObject.GetComponent<Animation>().Play("Mensagem");
		ultMensagem.text = mensagem.text;
		janelaLoja = GameObject.Find ("Loja");
		janelaLoja.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		horas.text = DateTime.Now.ToString ("hh:mm:ss tt");
	}

	public void AtualizaValores(){
		

		meuDinheiro.text = valorMeuDinheiro.ToString("####");
		if(valorMeuDinheiro >= 1000){
			meuDinheiro.text = (valorMeuDinheiro/1000).ToString("#####") + "K";

			if(valorMeuDinheiro >= 1000000){
				meuDinheiro.text = (valorMeuDinheiro/1000000).ToString("######") + "M";

				if(valorMeuDinheiro >= 1000000000){
					meuDinheiro.text = (valorMeuDinheiro/1000000000).ToString("######") + "B";
				}
			}
				
		}

		meuBitcoin.text = valorMeuBitcoin.ToString ();
		meuDodgecoin.text = valorMeuDodgecoin.ToString ();
		meuLitecoin.text = valorLitecoin.ToString ();

	}

	public void Loja(){		
		janelaLoja.SetActive (true);
	}

	public void SairLoja(){		
		janelaLoja.SetActive (false);
	}
}
