using UnityEngine;
using UnityEngine.UI;

public class PlayerXP : MonoBehaviour
{
    public int currentXP = 0;
    public int maxXP = 100;
    public int level = 1;

    public Image xpFill;

    public BackgroundProgress bg;

    private bool locked = false;

    void Start()
    {
        currentXP = 0;
        UpdateBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentXP >= maxXP)
            {
                ResetXP();

                if (bg != null)
                    bg.AddProgress();
            }
        }
    }


    // 🔥 ÚNICO PONTO DE ENTRADA DO XP
    public void AddXP(int value)
    {
        if (locked) return;

        // 🔴 BLOQUEIO ABSOLUTO
        if (currentXP >= maxXP)
            return;

        currentXP += value;

        if (currentXP >= maxXP)
        {
            currentXP = maxXP;
        }

        UpdateBar();
    }

    public bool IsFull()
    {
        return currentXP >= maxXP;
    }

    void UpdateBar()
    {
        if (xpFill != null)
            xpFill.fillAmount = (float)currentXP / maxXP;
    }

    void ResetXP()
    {
        locked = true;

        currentXP = 0;
        UpdateBar();

        locked = false;
    }
}