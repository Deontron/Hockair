using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneScript : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject secondPanel;
    public int sceneId;

    public TMP_Dropdown timeDropdown;
    public TMP_Dropdown scoreDropdown;
    public void Play()
    {
        mainPanel.SetActive(false);
        secondPanel.SetActive(true);


        PlayerPrefs.SetInt("TargetTime", 1);
        PlayerPrefs.SetInt("TargetScore", 1);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(sceneId);
    }

    public void SetTime()
    {
        PlayerPrefs.SetInt("TargetTime", timeDropdown.value + 1);
    }

    public void SetScore()
    {
        PlayerPrefs.SetInt("TargetScore", scoreDropdown.value + 1);
        print(scoreDropdown.value);
    }
}
