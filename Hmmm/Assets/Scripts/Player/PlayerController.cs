using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Queue<PlayerAction> actionQueue;
    private PlayerAction activeAction;
    
    // Start is called before the first frame update
    void Start()
    {
        actionQueue = new Queue<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeAction != null)
        {
            activeAction.Act();
            if (activeAction.IsCompleted() && actionQueue.Count != 0)
            {
                activeAction = actionQueue.Dequeue();
            }
        }
    }

    public void QueueAction(PlayerAction pa)
    {
        actionQueue.Enqueue(pa);
    }

}
