using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTarget : MonoBehaviour
{
    public bool moveTo = false;
    public bool shoot = false;
    public GameObject indicator;

    // Start is called before the first frame update
    void Start()
    {
        indicator.SetActive(false);
    }


    public void test()
    {
        Debug.Log("Action target found");
    }

    public void EnableSelectionIndicator()
    {
        indicator.SetActive(true);
    }

    public void DisableSelectionIndicator()
    {
        indicator.SetActive(false);
    }
}
