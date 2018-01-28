using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public Transform prefabSubjects;
	public GameObject[] humans ;
	public GameObject[] spawners;

	// Use this for initialization
	void Start () {
        /*
		for (int i = 0;i<20;i++){
			Vector3 randomSpawn = new Vector3 (Random.Range (-0.52f, 0.56f), Random.Range (-0.41f, 0.32f), 0);
			Instantiate (prefabSubjects, randomSpawn, Quaternion.identity);
		}
		*/
        ResetSpawns();
        SpawnHumans();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetSpawns() {
        int tUnavailableSpawnPoint = 0;
       tUnavailableSpawnPoint = Random.Range(0, spawners.Length);
       spawners[tUnavailableSpawnPoint].GetComponent<SpawnPoint>().used = false;
    }

	public void SpawnHumans(){
		int tAvailableSpawnPoint = 0;
		for (int i = 0; i < humans.Length; i++) {
			bool tReady = false;

			while (!tReady) 
			{
				tAvailableSpawnPoint = Random.Range (0, spawners.Length);
				if(!spawners[tAvailableSpawnPoint].GetComponent<SpawnPoint>().used){
					tReady = true;
                    spawners[tAvailableSpawnPoint].GetComponent<SpawnPoint>().used = true;

                }	
			}
            Debug.Log("spawning");
			humans [i].transform.position = spawners[tAvailableSpawnPoint].transform.position;
		}
	}
}
