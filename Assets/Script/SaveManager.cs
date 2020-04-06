using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

	private GameManager gm;
	private Criptomoedas cm;
	private Trabalhadores tb;
	private Recompesas rc;

	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		cm = GameObject.Find ("GameManager").GetComponent<Criptomoedas> ();
		tb = GameObject.Find ("GameManager").GetComponent<Trabalhadores> ();
		rc = GameObject.Find ("GameManager").GetComponent<Recompesas> ();
		StartCoroutine (SalvarOJogo());

	}

	public IEnumerator SalvarOJogo(){

		yield return new WaitForSeconds (1);
		PlayerPrefs.SetFloat ("SaveMeuDinheiro", gm.valorMeuDinheiro);
		PlayerPrefs.SetInt ("SaveMeuBitcoin", gm.valorMeuBitcoin);
		PlayerPrefs.SetInt ("SaveMeuDodgecoin", gm.valorMeuDodgecoin);
		PlayerPrefs.SetInt ("SaveMeuLitecoin", gm.valorLitecoin);
		PlayerPrefs.SetInt ("SaveQtdTrabalhadores", tb.qtdTrabalhadores);
		PlayerPrefs.SetInt ("SaveValorTrabalhadores", tb.valorTrabalhador);
		PlayerPrefs.SetInt ("SaveBoolTrabalhar",  tb.podeMinerar);

		StartCoroutine (SalvarOJogo());

	}
}
