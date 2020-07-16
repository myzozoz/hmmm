using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuController : MonoBehaviour
{
    public Button moveButton;
    public Button shootButton;
    public Button closeMenuButton;
    private Canvas canvas;

    private Dictionary<string, Button> enabledButtons;

    void Start()
    {
        enabledButtons = new Dictionary<string, Button>();
        enabledButtons.Add("moveTo", moveButton);
        enabledButtons.Add("shoot", shootButton);
        enabledButtons.Add("close", closeMenuButton);
        closeMenuButton.onClick.AddListener(CloseMenuClickHandler);
        canvas = gameObject.GetComponent<Canvas>();
    }

    public void MoveClickHandler()
    {

    }

    public void ShootClickHandler()
    {

    }

    public void CloseMenuClickHandler()
    {
        Debug.Log("Please close this :(");
        canvas.enabled = false;
    }

    public void SetEnabledButtons(HashSet<string> actions)
    {
        foreach (string key in enabledButtons.Keys)
        {
            if (actions.Contains(key) || key == "close")
            {
                enabledButtons[key].enabled = true;
            }
            else
            {
                enabledButtons[key].enabled = false;
            }
        }
    }
}
