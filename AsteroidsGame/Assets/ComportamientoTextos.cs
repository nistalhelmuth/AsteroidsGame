using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComportamientoTextos : MonoBehaviour {

	public Text vidas;
	public Text puntos;
	public Text nivel;
	public int v = 3;
	public int p = 0;
	public int n = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		///aklsjdfklajsdflk
		if (v < 1) {
			vidas.text = "GAME OVER:";
		} else {
			vidas.text="lives:"+v;
			puntos.text="score:"+p;
			nivel.text="level:"+n;
		}

	}
}
