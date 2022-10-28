using System;
using UnityEngine;

public class LevelManagerLocal : MonoBehaviour
{
    private GroundPrefab[] allGroundPieces;

    private void Start()
    {
        allGroundPieces = FindObjectsOfType<GroundPrefab>();
    }

    public void CheckComplete()
    {
        bool isFinished = true;

        for (int i = 0; i < allGroundPieces.Length; i++)
        {
            if (allGroundPieces[i].isColored == false)
            {
                isFinished = false;
                break;
            }
        }

        if (isFinished == true)
        {
            int currentSiblingIndex = GameManager.instance.currentlyActiveLevel.transform.GetSiblingIndex();

            if (currentSiblingIndex + 1 == GameManager.instance.levelsParent.childCount)
            {
                Debug.Log("Oyun Bitti");
                return;
            }

            GameManager.instance.currentlyActiveLevel.SetActive(false);
            GameManager.instance.currentlyActiveLevel =
                GameManager.instance.levelsParent.GetChild(currentSiblingIndex + 1).gameObject;
            GameManager.instance.currentlyActiveLevel.SetActive(true);
            GameManager.instance.ScoreIncrement();
        }
    }
}