/*
* Sam Carpenter
* Prot / Chall 5
* juicy red button
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigButton : MonoBehaviour
{
	private Button b;
	private GameManager gm;
	public float h = 1f;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<Button>();
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();
		b.onClick.AddListener(sethard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void sethard(){
		gm.spawnrate = h;
		gm.StartGame();
	}
}
