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
                Debug.LogError("There is not scoreKeeper in the scene.");
            }            
            return instance;
        }
        set
        {
            if (instance == null) 
            {
                instance = value;
            }
            else
            {
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
  

    public delegate void OnPickup(int point);
    public OnPickup OnPickupEvent;



    
    void AddScore(int point)
    {
        score+=point;
    }

    void Awake()
    {
        Instance = this; 
        OnPickupEvent = AddScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
