using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text scoreText, panelText;
    private int score;
    [SerializeField]
    private GameObject pausePanel;
    private GameObject player;

    public Button pause;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.activeInHierarchy)
        {
            WaitTilRespawn();
            // Respawn
        }
    }

    public void AddScore(int add)
    {
        score += add;
        scoreText.text = "Score: " + score;
    }

    public void Pause()
    {
        panelText.text = "Pause";
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        if (panelText.text == "Pause")
            pausePanel.gameObject.SetActive(false);
        else
            SceneManager.LoadScene("GamePlay");

    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        //Go to mainmenu scene
    }

    void WaitTilRespawn()
    {
        pausePanel.gameObject.SetActive(true);
        panelText.text = "Game Over";
    }
}
