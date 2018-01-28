using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class CMenusWin : MonoBehaviour {

    bool _ready;

    public void OnEnable()
    {
        StartCoroutine(GetReady());
    }
     
    private void Update()
    {
        if (!_ready)
            return;

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        else if (Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire4"))
        {
            SceneManager.LoadScene("Lobby");
        }
    }

    public IEnumerator GetReady()
    {
        yield return new WaitForSeconds(1);
        _ready = true;
    }
}
