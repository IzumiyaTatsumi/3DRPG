using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyUIManager : MonoBehaviour
{
    public Slider hpSlider;

    public void Init(EnemyManager enemyManager)
    {
        hpSlider.maxValue = enemyManager.maxhp;
        hpSlider.value = enemyManager.maxhp;
    }

    public void UpdateHP(int hp)
    {
        //hpSlider.value = hp;
        hpSlider.DOValue(hp, 0.5f);//0.5秒かけてHPスライダーのHPを移動させる
    }
}
