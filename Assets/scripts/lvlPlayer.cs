using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lvlPlayer : MonoBehaviour
{ 
    public List<PlayerProgressLevel> levels;
    
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;

    private int _levelValue = 1;
    private float  _experienceCurrentValue  = 0;
    private float  _experienceTargetValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        SetLevel(_levelValue);
        DrawUI();
    }

    // Update is called once per frame
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;        
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }

    private void DrawUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel = levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.expirinceForNextLevel;
        GetComponent<FairbollController>().damage = currentLevel.fireballDamage;
        GetComponent<GrenadeCaster>().damage = currentLevel.grenadeDamage;

        var grenadeCaster = GetComponent<GrenadeCaster>();
        if (currentLevel.grenadeDamage < 0)
           grenadeCaster.enabled = false;
        else
           grenadeCaster.enabled = true;
    }
}
