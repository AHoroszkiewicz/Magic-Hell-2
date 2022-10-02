using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private int level;
    private Image xpBar;
    public float currentXp;
    [SerializeField] float requiredXp;

    [Header("Multipliers")]
    [Range(1f,300f)]
    [SerializeField] float additionMultiplier = 300;
    [Range(2f,4f)]
    [SerializeField] float powerMultiplier = 2;
    [Range(7f,14f)]
    [SerializeField] float divisionMultiplier = 7;

    [Header("UI")]
    [SerializeField] GameObject xpBarObject;
    [SerializeField] StatsSO statsSO;
    [SerializeField] GameObject UI;
    private LevelScreen levelScreen;

    private void Start()
    {
        level = statsSO.level;
        xpBar = xpBarObject.GetComponent<Image>();
        requiredXp = CalculateRequiredXp();
        xpBar.fillAmount = currentXp / requiredXp;
        levelScreen = UI.GetComponent<LevelScreen>();
    }

    private void Update()
    {
        xpBar.fillAmount = currentXp / requiredXp;
        if (currentXp >= requiredXp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        currentXp = 0f;
        requiredXp = CalculateRequiredXp();
        levelScreen.LevelUpScreen();
    }

    private int CalculateRequiredXp()
    {
        int solveForRequeredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequeredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveForRequeredXp / 4;
    }
}
