using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnistavanjeKontaktom : MonoBehaviour {

	public GameObject eksplozija;
	public GameObject eksplozijaIgraca;
	public int brojnaVrednost;

	private KontrolerIgre kontrolerIgre;

	void Start (){
	
		GameObject referencaNaKotrolerIgraca = GameObject.FindWithTag ("KontrolerIgre");
		if (referencaNaKotrolerIgraca != null) {
		
			kontrolerIgre = referencaNaKotrolerIgraca.GetComponent <KontrolerIgre> ();
		}
		if (kontrolerIgre == null) {
		
			Debug.Log ("Ne postoji 'KomtrolerIgraca' !");
		}
	}

	void OnTriggerEnter(Collider nesto) {
	
		//if (nesto.tag == "Granica") {
		if (nesto.CompareTag ("Granica") || nesto.CompareTag("Neprijatelj")){ // || nesto.CompareTag("Igrac")){ 	
			return;
		}
		if (eksplozija != null){
		Instantiate (eksplozija, transform.position, transform.rotation);
		}
		if (nesto.tag == "Igrac"){
		Instantiate (eksplozijaIgraca, nesto.transform.position, nesto.transform.rotation);
			kontrolerIgre.KrajIgre ();
		}
		kontrolerIgre.DodavanjeRezultata (brojnaVrednost);
		Destroy (nesto.gameObject);
		Destroy (gameObject);
	}
}
