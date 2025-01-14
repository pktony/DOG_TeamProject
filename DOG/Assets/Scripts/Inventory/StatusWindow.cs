using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatusWindow : MonoBehaviour
{

    TextMeshProUGUI AttackPoint;
    TextMeshProUGUI DefensePoint;

    void Start()
    {   
        AttackPoint = GameObject.Find("Attackpower").GetComponent<TextMeshProUGUI>();
        DefensePoint = GameObject.Find("Defensepower").GetComponent<TextMeshProUGUI>();
        this.gameObject.SetActive(false);
    }

    
    void Update()
    {
        AttackPoint.text = GameManager.Inst.MainPlayer.AttackPower.ToString();
        DefensePoint.text = GameManager.Inst.MainPlayer.defencePower.ToString();
    }
}
