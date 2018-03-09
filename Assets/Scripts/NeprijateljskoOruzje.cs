using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeprijateljskoOruzje : MonoBehaviour {

	public GameObject pucanj;
	public Transform kreiranjeMetka;
	public float brzinaPucanja;
	public float pauza;

	private AudioSource zvuk;

	void Start () {

		zvuk = GetComponent <AudioSource> ();
		InvokeRepeating ("NeprijateljskaVatra", pauza, brzinaPucanja);
	}
	

	void NeprijateljskaVatra () {
	
		Instantiate (pucanj, kreiranjeMetka.position, kreiranjeMetka.rotation); 
		zvuk.Play ();
	}
}
