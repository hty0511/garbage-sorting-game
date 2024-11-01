using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Button
using UnityEngine.SceneManagement; //SceneManager

public class GoToSceneOnClick : MonoBehaviour
{
    public int sceneIndex; //�n���J��Scene

    void Start()
    {
        //�����s�[�JOn Click�ƥ�
        GetComponent<Button>().onClick.AddListener(() => {
            ClickEvent();
        });
    }

    void ClickEvent()
    {
        //����Scene
        SceneManager.LoadScene(sceneIndex);
    }
}