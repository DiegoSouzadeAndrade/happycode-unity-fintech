using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Criptomoedas : MonoBehaviour {

	//Recebe o valor da criptomoeda, foi escolhido o tipo int para simplificar
	private int compraBitcoin, compraDodgecoin, compraLitecoin;

	// Armazena os valores de bonus
	[HideInInspector]
	public int bonusDinheiro, bonusBitcoin, bonusDodgecoin, bonusLitecoin;

	//Variavel que conta o tempo de cotacao
	public float tempoCotacao;

	//Cria uma instancia do Game Manager
	private GameManager gm;

	[HideInInspector]
	public AudioSource audioS;
	public AudioClip sfxLever, sfxCambio, sfxCoin;

	//Textos com os valores das coins
	public Text bitcoinCotacao, dodgecoinCotacao, litecoinCotacao;

	void Start(){
		// Encontrar o objeto GAME MANAGER
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		audioS = GameObject.Find ("GameManager").GetComponent<AudioSource> ();

		// Iniciando os valores dos textos e variaveis
		bitcoinCotacao.text = "1000";
		dodgecoinCotacao.text = "700";
		litecoinCotacao.text = "400";
		compraBitcoin = 1000;
		compraDodgecoin = 700;
		compraLitecoin = 400;
		bonusBitcoin = 1;
		bonusDinheiro = 1;
		bonusDodgecoin = 1;
		bonusLitecoin = 1;

		// Chamando o metodo de corotina que atualiza os valores das criptomoedas
		StartCoroutine(AtualizarCotacaoCoins ());
	}

	// Metodo publico que atribui o nome e o valor da criptomoeda
	public void Bitcoin (string nome, int valor){

		compraBitcoin = valor;
		bitcoinCotacao.text = valor.ToString();

	}

	// Metodo publico que atribui o nome e o valor da criptomoeda
	public void Dodgecoin (string nome, int valor){
		
		compraDodgecoin = valor;
		dodgecoinCotacao.text = valor.ToString();
	}

	// Metodo publico que atribui o nome e o valor da criptomoeda
	public void Litecoin (string nome, int valor){
		
		compraLitecoin = valor;
		litecoinCotacao.text = valor.ToString();
	}

	//Metodo que define se temos ou não temos dinheiro pra comprar a criptocoin
	public void ComprarBitcoin(){
		
		if(gm.valorMeuDinheiro < compraBitcoin ){
			gm.mensagem.text = "Você não possui dinheiro suficiente, o Bitcoin vale: " + compraBitcoin ;
			gm.msgObject.GetComponent<Animation>().Play("Mensagem");
			audioS.PlayOneShot (sfxLever);
			gm.ultMensagem.text = gm.mensagem.text;
		}
		else {
			gm.valorMeuDinheiro -= compraBitcoin;
			gm.valorMeuBitcoin += bonusBitcoin;
			gm.AtualizaValores ();
		}
	}

	//Metodo que define se temos ou não temos dinheiro pra comprar a criptocoin
	public void ComprarDodgecoin(){

		if (gm.valorMeuDinheiro < compraDodgecoin) {
			gm.mensagem.text = "Você não possui dinheiro suficiente, o Dodgecoin vale: " + compraDodgecoin;
			gm.msgObject.GetComponent<Animation> ().Play ("Mensagem");
			audioS.PlayOneShot (sfxLever);
			gm.ultMensagem.text = gm.mensagem.text;
		} else {
			gm.valorMeuDinheiro -= compraDodgecoin;
			gm.valorMeuDodgecoin += bonusDodgecoin;
			gm.AtualizaValores ();
		}
	}

	//Metodo que define se temos ou não temos dinheiro pra comprar a criptocoin
	public void ComprarLitecoin(){

		if(gm.valorMeuDinheiro < compraLitecoin ){
			gm.mensagem.text = "Você não possui dinheiro suficiente, o Litecoin vale: " + compraLitecoin ;
			gm.msgObject.GetComponent<Animation>().Play("Mensagem");
			audioS.PlayOneShot (sfxLever);
			gm.ultMensagem.text = gm.mensagem.text;
		} else {
			gm.valorMeuDinheiro -= compraLitecoin;
			gm.valorLitecoin += bonusLitecoin;
			gm.AtualizaValores ();
		}
	}

	//Metodo que minera as criptocoins
	public void MinerarDinheiro(){
		gm.valorMeuDinheiro += bonusDinheiro;
		gm.AtualizaValores ();
		audioS.PlayOneShot (sfxCoin);
	}
		
	public IEnumerator AtualizarCotacaoCoins(){
		
		yield return new WaitForSeconds (tempoCotacao);
		Bitcoin ("Bitcoin", Random.Range(700,1000));

		yield return new WaitForSeconds (0.01f);
		Dodgecoin ("Dodgecoin", Random.Range(400,700));

		yield return new WaitForSeconds (0.02f);
		Litecoin ("Litecoin", Random.Range(100,400));

		gm.mensagem.text = "Valores das CRIPTOMOEDAS atualizados!" ;
		gm.msgObject.GetComponent<Animation>().Play("Mensagem");
		audioS.PlayOneShot (sfxCambio);
		gm.ultMensagem.text = gm.mensagem.text;

		StartCoroutine(AtualizarCotacaoCoins ());
	}
}
