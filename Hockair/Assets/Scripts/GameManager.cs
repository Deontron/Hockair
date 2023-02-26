using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public TMP_Text counterText1;
    public TMP_Text counterText2;
    public TMP_Text minutesText;
    public TMP_Text secondsText;
    public TMP_Text winnerText;
    public TMP_Text loserText;

    public AudioSource success;

    public GameObject gameOverMenu;

    private float counter1;
    private float counter2;
    private float time;
    private float minutes;
    private float seconds;
    private bool isTimerActive;

    private int targetTime;
    private int targetScore;

    void Start()
    {
        StartCoroutine(StartTheGame(3));

        targetTime = PlayerPrefs.GetInt("TargetTime", 1);
        targetScore = PlayerPrefs.GetInt("TargetScore", 1);
    }

    void Update()
    {
        if (isTimerActive)
        {
            Timer();
        }

        if (minutes == targetTime || counter1 == targetScore || counter2 == targetScore)
        {
            GameOver();
        }
    }
    private void Timer()
    {
        time += Time.deltaTime;

        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        minutesText.text = minutes.ToString();
        secondsText.text = seconds.ToString();
    }

    private void UpdateTexts()
    {
        counterText1.text = counter1.ToString();
        counterText2.text = counter2.ToString();
    }

    private void GameOver()
    {
        player1.GetComponent<PlayerScript>().enabled = false;
        player2.GetComponent<PlayerScript>().enabled = false;

        isTimerActive = false;

        gameOverMenu.SetActive(true);

        if (counter1 > counter2)
        {
            winnerText.text = "Player1 won!";
            loserText.text = "You can cry Player2";
        }
        else if (counter1 < counter2)
        {
            winnerText.text = "Player2 won!";
            loserText.text = "You can cry Player1";
        }
        else
        {
            winnerText.text = "losers :/";
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Goal(string goal)
    {
        success.Play();

        player1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        player1.transform.rotation = Quaternion.identity;
        player2.transform.rotation = Quaternion.identity;

        player1.transform.position = new Vector2(0, -4);
        player2.transform.position = new Vector2(0, 4);

        switch (goal)
        {
            case "Goal1":
                counter1++;
                break;

            case "Goal2":
                counter2++;
                break;
        }

        UpdateTexts();

        StartCoroutine(StartTheGame(3));
    }

    IEnumerator StartTheGame(float counter)
    {
        player1.GetComponent<PlayerScript>().enabled = false;
        player2.GetComponent<PlayerScript>().enabled = false;

        while (counter > 0)
        {
            counterText1.text = counter.ToString();
            counterText2.text = counter.ToString();

            yield return new WaitForSeconds(1);
            counter--;
        }

        if (counter == 0)
        {
            UpdateTexts();

            player1.GetComponent<PlayerScript>().enabled = true;
            player2.GetComponent<PlayerScript>().enabled = true;

            isTimerActive = true;
        }
    }
}
