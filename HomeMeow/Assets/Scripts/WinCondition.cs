using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private int catsSaved = 0;
    
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("cat")) {
            catsSaved += 1;
            GameObject cat = other.gameObject;

            // stop cat from moving
            CatBehavior cb = cat.GetComponent<CatBehavior>();
            cb.movementSpeed = 0;

            if(catsSaved >= 3) {
                winGame();
            }
        }
    }

    void winGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
