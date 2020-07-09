using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerAction
{
    void Act(float fixedDeltaTime);
    bool IsCompleted();
}
