using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoBala : MonoBehaviour {


	public Vector3 direccion = new Vector3(0f,0f,0f);
	Vector3 transportar= new Vector3(0f,0f,0f);
	float velocidad=30;
	float lifeTime=3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime += Time.deltaTime * -1;
		if (lifeTime < 0) {
			Destroy (this.gameObject);
		}
		transform.Translate(direccion * Time.deltaTime * velocidad);
		if (transform.position.x < -50) {
			transportar.x=50;
			transportar.y=transform.position.y;
			transform.position=transportar;
		} else if (transform.position.x > 50) {
			transportar.x=-50;
			transportar.y=transform.position.y;
			transform.position=transportar;
		}else if(transform.position.y<-50){
			transportar.y=50;
			transportar.x=transform.position.x;
			transform.position=transportar;
		}else if(transform.position.y>50){
			transportar.y=-50;
			transportar.x=transform.position.x;
			transform.position=transportar;
		}
	}
}
