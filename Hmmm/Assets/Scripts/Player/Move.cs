using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Move : PlayerAction
{
    private Vector3 moveTarget;

    public void Act()
    {
        Debug.Log("acting");
    }

    public bool IsCompleted()
    {
        return true;
    }
}
