using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private int pointsOnCollect;
    
    public delegate void OnPickupEventHandler(int points);
    public event OnPickupEventHandler OnPickupEvent;
    
    // Start is called before the first frame update
    private void Start()
    {
        if(ScoreKeep.Instance == null)
        {
            Debug.LogError($"Error: {nameof(ScoreKeep)} instance not found.");
            return;
        }

        OnPickupEvent += ScoreKeep.Instance.AddScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        // The codes from line 28 - 32 seems obselte since they been commented. Maybe consider removal of it ?
        // no need to check what other is because Coin can only collide with Player.
        /*if(other.GetComponent<Player>() == null)
        {
            return;
        }*/
        
        OnPickupEvent.Invoke(pointsOnCollect);
        Destroy(this.gameObject);
    }
}
