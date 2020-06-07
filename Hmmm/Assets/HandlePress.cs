using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePress : MonoBehaviour
{
    public Button button;
    public string identifier;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(HandleClick);
    }

    public void HandleClick() {
        Debug.Log("Click: " + identifier);
    }
}
