using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReturn : MonoBehaviour {

    private float timer;
    public float gazeTimer = 2f;
    private bool gazedAt;

    // Update is called once per frame
    void Update() {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if(timer >= gazeTimer)
            {
                SceneManager.LoadScene("hiddenfigures");
            }
        }
    }

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
    }
}
