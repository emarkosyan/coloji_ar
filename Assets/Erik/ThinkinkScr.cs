using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkinkScr : MonoBehaviour {

	public GameObject[] arr = new GameObject[4];
	public float speed = 100;

	public GameObject main;

	void Start(){
		arr [0].SetActive (false);
		arr [1].SetActive (false);
		arr [2].SetActive (false);
		arr [3].SetActive (false);
	}

	void FixedUpdate(){
		main.transform.Rotate (Vector3.right * speed * Time.deltaTime, Space.World);

		if (main.transform.eulerAngles.z == 900) {
			arr [0].SetActive (true);
			arr [1].SetActive (true);
			arr [2].SetActive (true);
			arr [3].SetActive (true);
			arr [0].transform.Rotate (Vector3.forward * Time.deltaTime);
			arr [1].transform.Rotate (Vector3.forward * Time.deltaTime);
			arr [2].transform.Rotate (Vector3.forward * Time.deltaTime);
			arr [3].transform.Rotate (Vector3.forward * Time.deltaTime);
		}
		//if(main.transform.eulerAngles.z == )
	}
}
