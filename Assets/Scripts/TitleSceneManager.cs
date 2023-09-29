using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// �{�^������������Battle�V�[���ɍs��
public class TitleSceneManager : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("BattleScenes");
    }

    public void OnEndButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
