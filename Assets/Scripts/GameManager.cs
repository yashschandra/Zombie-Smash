using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] zombies;
    public int riseSpeed = 1;
    public Image life01;
    public Image life02;
    public Image life03;
    public TMP_Text scoreText;
    public Button replayButton;

    private bool isRising;
    private bool isFalling;
    private int activeZombieIndex = 0;
    private Vector2 startPosition;
    private int kills;
    private int livesRemaning;
    private int difficulty;
    private int difficultyThreshold;

    // Start is called before the first frame update
    void Start()
    {
        isRising = false;
        isFalling = false;
        activeZombieIndex = 0;
        kills = 0;
        livesRemaning = 3;
        difficulty = 1;
        difficultyThreshold = 5;
        pickNewZombie();
    }

    // Update is called once per frame
    void Update()
    {
        if (livesRemaning == 0)
        {
            return;
        }
        if (isRising)
        {
            if (zombies[activeZombieIndex].transform.position.y - startPosition.y >= 3f)
            {
                isRising = false;
                isFalling = true;
                return;
            }
            zombies[activeZombieIndex].transform.Translate(Vector2.up * Time.deltaTime * riseSpeed * difficulty);
        } else if (isFalling)
        {
            if (zombies[activeZombieIndex].transform.position.y - startPosition.y <= 0)
            {
                isFalling = false;
                return;
            }
            zombies[activeZombieIndex].transform.Translate(Vector2.down * Time.deltaTime * riseSpeed * difficulty);
        } else
        {
            livesRemaning--;
            if (livesRemaning == 2)
            {
                life03.gameObject.SetActive(false);
            } else if (livesRemaning == 1)
            {
                life02.gameObject.SetActive(false);
            } else if (livesRemaning == 0)
            {
                life01.gameObject.SetActive(false);
                replayButton.gameObject.SetActive(true);
            }
            zombies[activeZombieIndex].transform.position = startPosition;
            pickNewZombie();
        }
    }

    private void pickNewZombie()
    {
        isRising = true;
        isFalling = false;
        activeZombieIndex = UnityEngine.Random.Range(0, zombies.Length);
        startPosition = zombies[activeZombieIndex].transform.position;
    }

    public void killEnemy()
    {
        kills++;
        if (kills >= difficultyThreshold)
        {
            difficulty++;
            difficultyThreshold *= 2;
        }
        scoreText.text = kills.ToString();
        zombies[activeZombieIndex].transform.position = startPosition;
        pickNewZombie();
    }

    public void onReplayButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void onMainMenuButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
}
