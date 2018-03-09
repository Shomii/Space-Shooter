using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnistavanjeObjektaPosleOdredjenogVremena : MonoBehaviour {

	public float vreme;

	void Start () {
	
		Destroy (gameObject, vreme);
	}


}
