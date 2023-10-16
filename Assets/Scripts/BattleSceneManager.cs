using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSceneManager : MonoBehaviour
{
    /// <summary>
    /// 再スタートボタンクリック処理
    /// </summary>
    public void OnReStartButton()
    {
        SceneManager.LoadScene("BattleScenes");
    }

    /// <summary>
    /// 終了ボタンクリック処理
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
