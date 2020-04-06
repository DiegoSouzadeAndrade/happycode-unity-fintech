using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recompesas : MonoBehaviour {

	private Criptomoedas cm;
	private GameManager gm;
	private Trabalhadores tb;
	private Image linguote, picareta;

	private bool temRec1, temRec2, temRec3;
	// Use this for initialization
	void Start () {
		cm = GameObject.Find ("GameManager").GetComponent<Criptomoedas> ();
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		tb = GameObject.Find ("GameManager").GetComponent<Trabalhadores> ();

		linguote = GameObject.Find ("IMG linguote").GetComponent<Image> ();
		picareta = GameObject.Find ("IMG picareta").GetComponent<Image> ();
		temRec1 = false;
		temRec2 = false;
		temRec3 = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void RecompensaLinguote(){
		
		if (!temRec1) {
			if (gm.valorMeuBitcoin >= 2 && gm.valorMeuDodgecoin >= 2 && gm.valorLitecoin >= 2) {

				linguote.sprite = Resources.Load<Sprite> ("Iron_Ingot");
				temRec1 = true;
				cm.bonusDinheiro++;
				gm.valorMeuBitcoin -= 2;
				gm.valorMeuDodgecoin -= 2;
				gm.valorLitecoin -= 2;
				gm.AtualizaValores ();

			} else {
				gm.mensagem.text = "Você não possui Criptomoedas suficiente" ;
				gm.msgObject.GetComponent<Animation>().Play("Mensagem");
				cm.audioS.PlayOneShot (cm.sfxLever);
				gm.ultMensagem.text = gm.mensagem.text;
			}
		}
	}

	public void RecompensaPicareta(){

		if (!temRec3) {
			if (gm.valorMeuBitcoin >= 6 && gm.valorMeuDodgecoin >= 6 && gm.valorLitecoin >= 6) {

				picareta.sprite = Resources.Load<Sprite> ("Stone_Pickaxe");
				temRec3 = true;
				tb.tempoTrabalhador /= 2;
				gm.valorMeuBitcoin -= 6;
				gm.valorMeuDodgecoin -= 6;
				gm.valorLitecoin -= 6;
				gm.AtualizaValores ();

			} else {
				gm.mensagem.text = "Você não possui Criptomoedas suficiente" ;
				gm.msgObject.GetComponent<Animation>().Play("Mensagem");
				cm.audioS.PlayOneShot (cm.sfxLever);
				gm.ultMensagem.text = gm.mensagem.text;
			}
		}
	}
		
}
