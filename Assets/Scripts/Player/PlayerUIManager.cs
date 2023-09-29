using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerUIManager : MonoBehaviour
{
    public Slider hpSlider;
    public Slider staminaSlider;

    public void Init(PlayerManager playerManager)
    {
        hpSlider.maxValue = playerManager.maxhp;
        hpSlider.value = playerManager.maxhp;
        staminaSlider.maxValue = playerManager.maxstamina;
        staminaSlider.value = playerManager.maxstamina;
    }

    public void UpdateHP(int hp)
    {
        //hpSlider.value = hp;
        hpSlider.DOValue(hp, 0.5f);//0.5秒かけてHPスライダーのHPを移動させる
    }

    public void UpdateStamina(int stamina)
    {
        //hpSlider.value = hp;
        staminaSlider.DOValue(stamina, 0.5f);//0.5秒かけてスタミナスライダーのゲージを移動させる
    }
}
