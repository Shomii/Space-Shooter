using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GranicaIgranja {

	public float xMin, xMax, zMin, zMax;
}

public class KontrolerIgraca : MonoBehaviour {

	public float speed;
	public float tilt;
	public GranicaIgranja granicaIgranja;

	public GameObject pucanj;
	//public Transform kreiranjeMetka;
	public Transform[] kreiranjeMetaka;
	public float brzinaPucanja;

	private Rigidbody rb;
	private AudioSource zvuk;
	private float sledeciPucanj;

	void Start () {

		rb = GetComponent<Rigidbody>();
		zvuk = GetComponent<AudioSource> ();
	}

	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > sledeciPucanj) {
			sledeciPucanj = Time.time + brzinaPucanja;
			foreach (var kreiranjeMetka in kreiranjeMetaka){
			Instantiate (pucanj, kreiranjeMetka.position, kreiranjeMetka.rotation); 
			}
				zvuk.Play ();

		}
	}


	void FixedUpdate (){
	
		float pomerajSeHorizontalno = Input.GetAxis ("Horizontal");
		float pomerajSeVertikalno = Input.GetAxis ("Vertical");

		Vector3 kretanjeBroda = new Vector3 (pomerajSeHorizontalno,0.0f,pomerajSeVertikalno);
		rb.velocity = kretanjeBroda * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, granicaIgranja.xMin, granicaIgranja.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, granicaIgranja.zMin, granicaIgranja.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

}

