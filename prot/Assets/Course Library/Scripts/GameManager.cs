/*
* Sam Carpenter
* Prot / Chall 5
* clackerty
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public List<GameObject> orbules;
	public float spawnrate = 1f;
	public TextMeshProUGUI scoretext;
	public TextMeshProUGUI gameovertext;
	public Button r;
	private int score;
	private bool gameo = true;
    // Start is called before the first frame update
    public void StartGame()
    {
		gameo = true;
        StartCoroutine(spawnthingy());
		score = 0;
		updateScore(0);
		GameObject.Find("Menu").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	IEnumerator spawnthingy(){
		while(gameo){
			yield return new WaitForSeconds(spawnrate);
			Instantiate(orbules[Random.Range(0, orbules.Count)]);
			updateScore(0);
		}
	}
	
	public void updateScore(int s){
			if(gameo){
				score += s;
				scoretext.text = "Score: " + score;
			}
	}
	
	public void GameOver(){
		gameovertext.gameObject.SetActive(true);
		r.gameObject.SetActive(true);
		gameo = false;
	}
	
	public void Restart(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	}
}
