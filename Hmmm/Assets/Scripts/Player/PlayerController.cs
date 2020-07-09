using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Queue<PlayerAction> actionQueue;
    
    // Start is called before the first frame update
    void Start()
    {
        actionQueue = new Queue<PlayerAction>();
        QueueAction(new Move(new Vector3(0, 0, 0), gameObject));
    }

    void FixedUpdate()
    {
        if (actionQueue.Count == 0) return;

        PlayerAction activeAction = actionQueue.Peek();
        activeAction.Act(Time.fixedDeltaTime);

        if (activeAction.IsCompleted())
        {
            activeAction = actionQueue.Dequeue();
        }
    }

    public void QueueAction(PlayerAction pa)
    {
        actionQueue.Enqueue(pa);
    }

}
