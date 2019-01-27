using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private int catsSaved = 0;
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("cat")) {
            GameObject cat = other.gameObject;
            CatBehavior cb = cat.GetComponent<CatBehavior>();

            if(cb.saved == true) {
                // do nothing; the cat is already saved!
            } else {
                catsSaved += 1;

                // stop cat from moving
                cb.saved = true;
                cb.movementSpeed = 0;

                if(catsSaved >= 3) {
                    winGame();
                }
            }
        }
    }

    void winGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
