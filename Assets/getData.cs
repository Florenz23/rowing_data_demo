using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getData : MonoBehaviour {

	// Use this for initialization
	public TextMesh txt;
	void Start () {
		txt = gameObject.GetComponent<TextMesh>();
		txt.text="Score : ";
	}

	// Update is called once per frame
	void Update () {

	}
}
