using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeep : MonoBehaviour
{
    // Singleton
    static private ScoreKeep instance;
    static public ScoreKeep Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError($"There is no {nameof(ScoreKeep)} in the scene.");
            }
            return instance;
        }
        private set
        {
            if (instance == null)
            {
                instance = value;
            }
            else
            {
                Debug.LogWarning(
                    $"There is already a {nameof(ScoreKeep)} in the scene, destroying new.");
                Destroy(value);
            }
        }
    }

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
    }

    public void AddScore(int point)
    {
        score += point;
    }

    // Awake is called once the instance is created
    private void Awake()
    {
        Instance = this;
    }
}
