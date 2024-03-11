using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelth : MonoBehaviour
{
    public float value = 100;
    public RectTransform valueReactTransform;  

    public GameObject GameplayUI;
    public GameObject GameOverUI;   
   
   private float _maxValue;

   private void Start()
    {
       _maxValue = value;
       DrawHealthBar();
    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            PlayerIsDead();
        }
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        valueReactTransform.anchorMax = new Vector2(value / _maxValue, 1);
    }

    private void PlayerIsDead()
    {
       GameplayUI.SetActive(false);
       GameOverUI.SetActive(true);
       GetComponent<PlayerController>().enabled = false;
       GetComponent<FairbollController>().enabled = false;
       GetComponent<CameraController>().enabled = false;    

    }

    public void AddHealth(float amount)
    {
        value += amount;
        value = Mathf.Clamp(value, 0, _maxValue);
        DrawHealthBar();
    }

}
