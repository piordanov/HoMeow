using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    void Start() {
        this.updateCatCounterUI();
    }

    private int catsSaved = 0;
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("cat")) {
            GameObject cat = other.gameObject;
            CatBehavior cb = cat.GetComponent<CatBehavior>();

            if(cb.saved == true) {
                // do nothing; the cat is already saved!
            } else {
                catsSaved += 1;
                updateCatCounterUI();
                // stop cat from moving
                cb.saved = true;
                cb.movementSpeed = 0;
                cb.source.PlayOneShot(cb.CatFoundSound);

                if(catsSaved >= 3) {
                    winGame();
                }
            }
        }
    }

    void updateCatCounterUI() {
        GameObject[] catCounter = GameObject.FindGameObjectsWithTag("CatCounter");
        for(int i = 0; i < catCounter.Length; i++) {
            Image cc =catCounter[i].GetComponent<Image>();
            var tempColor = cc.color;
            tempColor.a = catsSaved <= i ? 0.3f : 1f;
            cc.color = tempColor;
        }
    }

    void winGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
