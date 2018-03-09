using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(GUIText))]
public class KontrolerIgre : MonoBehaviour {

	public GameObject[] opasnostiZaIgraca;
	public Vector3 parametriAsteroida;
	public int brojNaleta;
	public float pauzaUKreiranjuNaleta;
	public float pocetakPauze;
	public float pauzaUNaletima;
//	public GUIText rezultatTekst;
	public Text rezultatTekst;
	public Text restartTekst;
	public Text krajIgreTekst;

	private int rezultat;
	private bool krajIgre;
	private bool restartujIgru;
//	private new GUIText guiTekst;	


	void Start () {
		krajIgre = false;
		restartujIgru = false;
		restartTekst.text = "";
		krajIgreTekst.text = "";
//		guiTekst = GetComponent<GUIText> ();
		rezultat = 0;
		AzuriranjeRezultata ();
		StartCoroutine (NaletiOpasnosti ());
	}

	void Update () {
	
		if (restartujIgru){
			if (Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator NaletiOpasnosti () {
		yield return new WaitForSeconds (pocetakPauze);
		while (true) {
			for (int i = 0; i < brojNaleta; i++) {
				GameObject opanostZaIgraca = opasnostiZaIgraca[Random.Range(0,opasnostiZaIgraca.Length)];
				Vector3 pozicijaStvaranja = new Vector3 (Random.Range (-parametriAsteroida.x, parametriAsteroida.x), parametriAsteroida.y, parametriAsteroida.z);
				Quaternion pozicijaRotiranja = Quaternion.identity;
				Instantiate (opanostZaIgraca, pozicijaStvaranja, pozicijaRotiranja);
				yield return new WaitForSeconds (pauzaUKreiranjuNaleta);
			}
			yield return new WaitForSeconds (pauzaUNaletima);

			if (krajIgre){

				restartTekst.text = "Pritisni 'R' da počneš ponovo";
				restartujIgru = true;
				break;
			}
		} 
	}

	public void DodavanjeRezultata (int noviRezultat){
	
		rezultat += noviRezultat;
		AzuriranjeRezultata ();
	}

	void AzuriranjeRezultata (){
	
		rezultatTekst.text = "Rezultat: " + rezultat;
	}

	public void KrajIgre () {
	
		krajIgreTekst.text = "Kraj igre !";
		krajIgre = true;
	}
}
