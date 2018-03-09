using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KretanjeNeprijatelja : MonoBehaviour {

	public Vector2 pauzaZaIzbegavanje;
	public float izbegavanje;
	public Vector2 vremeZaManevrisanje;
	public Vector2 pauzaZaManevrisanje;
	public float ubrzanje;
	public GranicaIgranja granicaIgranja;
	public float tilt;

	private float manevrisanje;
	private Rigidbody rb;
	private float trenutnaBrzina;

	void Start () {

		rb = GetComponent <Rigidbody> ();
		trenutnaBrzina = rb.velocity.z;
		StartCoroutine (Izbegavanje ());
	}

	IEnumerator Izbegavanje () {
	
		yield return new WaitForSeconds (Random.Range (pauzaZaIzbegavanje.x, pauzaZaIzbegavanje.y));
	
		while (true) {
			manevrisanje = Random.Range (1, izbegavanje) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (vremeZaManevrisanje.x, vremeZaManevrisanje.y));
			manevrisanje = 0;
			yield return new WaitForSeconds (Random.Range (pauzaZaManevrisanje.x, pauzaZaManevrisanje.y));
		}
	}

	void FixedUpdate () {

		float noviManevar = Mathf.MoveTowards (rb.velocity.x, manevrisanje, Time.deltaTime * ubrzanje);
		rb.velocity = new Vector3 (noviManevar, 0.0f, trenutnaBrzina);
		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, granicaIgranja.xMin, granicaIgranja.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, granicaIgranja.zMin, granicaIgranja.zMax)
		);
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
