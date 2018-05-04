using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public GameObject resetBtn;
	private int score= 0;
	public Text scoreText;
	private Rigidbody rb;
	private bool ismovingright = false;
	[HideInInspector]
	public bool canmove = true;

	[SerializeField]
	float speed = 4f;
	[SerializeField]
	GameObject particle;
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && canmove) 
		{
			
			ChangeBoolean ();
			ChangeDirection ();
			score++;
			scoreText.text = score.ToString();

		}
		if (Physics.Raycast (this.transform.position, Vector3.down * 2) == false) 
		{
			FallDown ();
		}
	}
	private void FallDown()
		{
			canmove = false;
			rb.velocity = new Vector3 (0f, -4f, 0f);
		resetBtn.SetActive (true);
		}
	private void ChangeBoolean()
	{
		ismovingright = !ismovingright;
}
	private void ChangeDirection()
	{
		if (ismovingright) {
			rb.velocity = new Vector3 (speed, 0f, 0f);
		} 
		else 
		{
			rb.velocity = new Vector3 (0f, 0f, speed);
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Gem") {
			
			 
			Destroy (col.gameObject);
			GameObject _particle = Instantiate(particle) as GameObject;
			_particle.transform.position = this.transform.position;
			Destroy (_particle, 1f);
			score+=3;
			scoreText.text = score.ToString ();
		}
	}
}