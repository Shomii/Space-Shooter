using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranicaIgreScript : MonoBehaviour {

	void OnTriggerExit(Collider nesto)
	{
		Destroy(nesto.gameObject);
	}
}
