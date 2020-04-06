using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour {

	private int SaveMeuBitcoin, SaveMeuDodgecoin, SaveMeuLitecoin, SaveQtdTrabalhadores, SaveValorTrabalhadores,SavePodeTrabalhar;
	private float saveMeuDinheiro;

	private GameManager gm;
	private Criptomoedas cm;
	private Trabalhadores tb;
	private Recompesas rc;

	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		cm = GameObject.Find ("GameManager").GetComponent<Criptomoedas> ();
		tb = GameObject.Find ("GameManager").GetComponent<Trabalhadores> ();
		rc = GameObject.Find ("GameManager").GetComponent<Recompesas> ();


		saveMeuDinheiro = PlayerPrefs.GetFloat ("SaveMeuDinheiro");
		gm.valorMeuDinheiro = saveMeuDinheiro;
		SaveMeuBitcoin = PlayerPrefs.GetInt ("SaveMeuBitcoin");
		gm.valorMeuBitcoin = SaveMeuBitcoin;
		SaveMeuDodgecoin = PlayerPrefs.GetInt ("SaveMeuDodgecoin");
		gm.valorMeuDodgecoin = SaveMeuDodgecoin;
		SaveMeuLitecoin = PlayerPrefs.GetInt ("SaveMeuLitecoin");
		gm.valorLitecoin = SaveMeuLitecoin;
		SaveQtdTrabalhadores = PlayerPrefs.GetInt ("SaveQtdTrabalhadores");
		tb.qtdTrabalhadores = SaveQtdTrabalhadores;
		SaveValorTrabalhadores = PlayerPrefs.GetInt ("SaveValorTrabalhadores");
		tb.valorTrabalhador = SaveValorTrabalhadores;
		SavePodeTrabalhar = PlayerPrefs.GetInt ("SaveBoolTrabalhar");
		tb.podeMinerar = SavePodeTrabalhar;

		PlayerPrefs.SetInt ("SaveBoolTrabalhar",  tb.valorTrabalhador);
		gm.AtualizaValores ();
		cm.AtualizarCotacaoCoins ();
		tb.txtQtdTrabalhadores.text = tb.qtdTrabalhadores.ToString ();

		if(tb.podeMinerar == 3){
			StartCoroutine(tb.QtdTrabalhadores());
		}
	}

}
