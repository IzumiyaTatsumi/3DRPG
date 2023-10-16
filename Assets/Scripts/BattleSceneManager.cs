using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneManager : MonoBehaviour
{
    /// <summary>
    /// �ăX�^�[�g�{�^���N���b�N����
    /// </summary>
    public void OnReStartButton()
    {
        SceneManager.LoadScene("BattleScenes");
    }

    /// <summary>
    /// �I���{�^���N���b�N����
    /// </summary>
    public void OnEndButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
