using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class chanceSceneOnPlay : MonoBehaviour {


	public void ChangeScene (string PlanoDeBatalla) {
         SceneManager.LoadScene("GameScene");
    }
	

}

