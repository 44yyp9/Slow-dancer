using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.SceneManagement;

public class ChangeResultSceneButtonModel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
