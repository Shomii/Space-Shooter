using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkrolovanjePozadine : MonoBehaviour {

	public float brzinaSkrolovanja;
	public float velicinaPoZ;

	private Vector3 startnaPozicija;

	void Start () {
		startnaPozicija = transform.position;
	}

	void Update () {
		float novaPozicija = Mathf.Repeat (Time.time * brzinaSkrolovanja, velicinaPoZ);
		transform.position = startnaPozicija + Vector3.forward * novaPozicija;
	}
}
