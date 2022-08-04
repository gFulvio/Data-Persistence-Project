using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
	private void Start()
	{
        MainDataManager.Instance.bestScoreText.text = $"Best Score : {MainDataManager.Instance.name} : {MainDataManager.Instance.bestScore}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void ReadStringInput(string s)
    {
        MainDataManager.Instance.input = s;
    }
}
