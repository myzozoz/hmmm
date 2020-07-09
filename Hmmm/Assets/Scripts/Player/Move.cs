using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Move : PlayerAction
{
    private bool completed = false;
    private Vector3 moveTarget;
    private GameObject targetObject;

    public Move(Vector3 moveTarget, GameObject targetObject) {
        this.moveTarget = moveTarget;
        this.targetObject = targetObject;
    }

    public void Act(float fixedDeltaTime)
    {
        if (!this.completed) {
            Debug.Log("acting: " + fixedDeltaTime);
            if (this.moveTarget == targetObject.transform.position) {
                this.completed = true;
            }
        }
    }

    public bool IsCompleted()
    {
        return this.completed;
    }
}
