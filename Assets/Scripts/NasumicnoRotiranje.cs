using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NasumicnoRotiranje : MonoBehaviour {

	public float rotiranje;

	private Rigidbody rb;

	void Start (){
	
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * rotiranje;
	}

}
