using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject tutorial1;
    public GameObject t1b;
    public GameObject t2b;
    public GameObject tutorial2;

    private void Awake() {
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        t1b.SetActive(false);
        t2b.SetActive(false);
    }

    public void StartGame() {
        StartCoroutine(tutorial1I());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator tutorial1I() {
        tutorial1.SetActive(true);
        t1b.SetActive(true);
        yield return new WaitForSeconds(5f);
        StartCoroutine(tutorial2I());
    }
    
    public IEnumerator tutorial2I() {
        t2b.SetActive(true);
        tutorial2.SetActive(true);
        yield return new WaitForSeconds(5f);
        LoadScene();
    }
    

    public void LoadScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }
}
