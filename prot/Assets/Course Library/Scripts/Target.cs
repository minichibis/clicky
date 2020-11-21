/*
* Sam Carpenter
* Prot / Chall 5
* clickety
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	private Rigidbody rb;
	private GameManager gm;
	public float minspeed = 17f;
	public float maxspeed = 24f;
	public float maxtorque = 10f;
	public float xpos = 4f;
	public float ypos = 8f;
	public int points = 5;
	public ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		RandomForce(rb);
		RandomTorque(rb);
		transform.position = RandomPos();
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnMouseDown(){
		gm.updateScore(points);
		Instantiate(p, transform.position, p.transform.rotation);
		Destroy(gameObject);
	}
	
	private void OnTriggerEnter(){
		if(!gameObject.CompareTag("Evil")){
			gm.GameOver();
		}
		Destroy(gameObject);
	}
	
	void RandomForce(Rigidbody r){
		r.AddForce(Vector3.up * Random.Range(minspeed, maxspeed), ForceMode.Impulse);
	}
	
	void RandomTorque(Rigidbody r){
		r.AddTorque(Random.Range(-1 * maxtorque, maxtorque), Random.Range(-1 * maxtorque, maxtorque), Random.Range(-1 * maxtorque, maxtorque), ForceMode.Impulse);
	}
	
	Vector3 RandomPos(){
		return new Vector3(Random.Range(-1 * xpos, xpos), ypos, 0);
	}
}
