using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoNave : MonoBehaviour {

	int amount=8;
	Vector3 transportar= new Vector3(0f,0f,0f);
	Vector3 vector= new Vector3(0f,0f,0f);
	public GameObject bala;
	public GameObject camara;
	float tiempo;
	float tiempobalas;
	public int numbalas=0;
	float m_MovementInputValue;         // The current value of the movement input.
	float m_MovementInputValue2;         // The current value of the movement input.
	float m_Speed = 10f;                 // How fast the tank moves forward and back.
	float m_TurnSpeed = 180f;            // How fast the tank turns in degrees per second.
	private Rigidbody m_Rigidbody;


	// Use this for initialization
	void Start () {
		tiempo = 0;
		tiempobalas = 0;
		m_Rigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		m_MovementInputValue = Input.GetAxis ("Horizontal");
		m_MovementInputValue2 = Input.GetAxis ("Vertical");
		if (Input.GetKey (KeyCode.D)) {//derecha
			transform.RotateAround(transform.position, Vector3.back, 150 * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.A)) {//arriba
			transform.RotateAround(transform.position, Vector3.forward, 150 * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.W)) {
			Vector3 movement = transform.forward * m_MovementInputValue2 * amount;
			GetComponent<Rigidbody>().AddForce(movement);
		}
		if (Input.GetKeyUp (KeyCode.C)) {
			vector.x=0;
			vector.y=0;
			GetComponent<Rigidbody> ().velocity = vector;
			vector.x=Random.Range (-20f, 20f);
			vector.y=Random.Range (-20f, 20f);
			transform.position = vector;

		}


		tiempo +=Time.deltaTime;
		//Debug.Log (Time.deltaTime);
		//Debug.Log (tiempo);

		if (numbalas>0) {
			tiempobalas += Time.deltaTime;
			if (tiempobalas > 1) {
				numbalas += -1;;
				tiempobalas = 0;
			}
		}

		if ((Input.GetKeyUp (KeyCode.Space)) & (tiempo>.2)& (numbalas<5)){
			Debug.Log("Bang");
			Vector3 posIni = new Vector3 (transform.position.x+transform.forward.x*4,transform.position.y+transform.forward.y*4, 0.0f);
			GameObject instancia=Instantiate (bala, posIni, Quaternion.identity);
			instancia.GetComponent<ComportamientoBala> ().direccion = transform.forward;
			numbalas++;
			tiempo=0;
		}

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

	void OnCollisionEnter (Collision choque) {///aklsjdfklajsdflk
		if (choque.gameObject.CompareTag ("Asteroid")) {
			vector.x = 0;
			vector.y = 0;
			camara.GetComponent<ComportamientoTextos> ().v += -1;
			if (camara.GetComponent<ComportamientoTextos> ().v>0){
				transform.position = vector;
				GetComponent<Rigidbody> ().velocity = vector;
			}else{
				Destroy (gameObject);
				//SceneManager.LoadScene ("Menu1");
			}

		}
		
	}
}