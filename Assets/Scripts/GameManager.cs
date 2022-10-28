using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform levelsParent;
    public static GameManager instance;
    public GameObject currentlyActiveLevel;
    public Text scoreText;
    public int score = 1;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentlyActiveLevel = GameObject.Find("Levels").transform.GetChild(0).gameObject;
        currentlyActiveLevel.SetActive(true);
    }
    
    public void ScoreIncrement()
    {
        score++;
        scoreText.text = score.ToString();
    }
}