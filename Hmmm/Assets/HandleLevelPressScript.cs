using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleLevelPressScript : MonoBehaviour
{
    public string identifier;

    public void OnPress() {
        SceneManager.LoadScene(identifier, LoadSceneMode.Single);
    }
}
