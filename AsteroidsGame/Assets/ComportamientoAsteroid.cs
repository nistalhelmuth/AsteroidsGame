using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAsteroid : MonoBehaviour {

	public GameObject nextAsteroid;
	public float velocidad = 1f;
	private Rigidbody rigid;
	Vector3 transportar= new Vector3(0f,0f,0f);
	Vector3 vector= new Vector3(0f,0f,0f);
	public GameObject camara;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody> ();
		rigid.velocity = transform.right * velocidad;
		///aklsjdfklajsdflk
		camara=GameObject.Find ("Main Camera");
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.CompareTag ("Bullet")) {
			if (nextAsteroid) {
				float angle = Mathf.Atan2 (rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
				Instantiate (nextAsteroid, transform.position, Quaternion.Euler (0, 0, angle - 60));
				Instantiate (nextAsteroid, transform.position, Quaternion.Euler (0, 0, angle + 60));
			}
			camara.GetComponent<ComportamientoTextos> ().p += 20;	
			Destroy (gameObject);
			Destroy (other.gameObject);
		} else if (other.gameObject.CompareTag ("Ship")) {
			Destroy (gameObject);
			Destroy(other.gameObject);
		}
	}

	void Update () {
		
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