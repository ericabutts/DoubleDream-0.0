using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public void startGame() {
        Debug.Log("Start game.");
        SceneManager.LoadScene("Level1");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager != null) {
            Destroy(gameObject);
        } else {
            gameManager = this;
        }
        DontDestroyOnLoad(gameManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
