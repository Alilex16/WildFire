using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerModifiersIcons : MonoBehaviour
{
    // used in both scenes

    [Header("Modifiers")]
    public GameObject fireRate;
    public GameObject bulletSpeed;
    public GameObject enemyRotation;
    public GameObject sliderSize;
    public GameObject sliderSpeed;
    public GameObject zigZag;
    public GameObject projectileBounces;
    public GameObject controlsReversed;
    public GameObject controlsWeird; // chaotic controls
    public GameObject dualWield; // dual shot

    private void Start()
    {
        ActiveModifiers();

        if (LevelModifiers.fireRateMod)
        {
            fireRate.SetActive(true);
        }

        if (LevelModifiers.bulletSpeedMod)
        {
            bulletSpeed.SetActive(true);
        }

        if (LevelModifiers.enemyRotationMod)
        {
            enemyRotation.SetActive(true);
        }

        if (LevelModifiers.sliderSizeMod)
        {
            sliderSize.SetActive(true);
        }

        if (LevelModifiers.sliderSpeedMod)
        {
            sliderSpeed.SetActive(true);
        }

        if (LevelModifiers.ZigZagMod)
        {
            zigZag.SetActive(true);
        }

        if (LevelModifiers.bulletBounceMod)
        {
            projectileBounces.SetActive(true);
        }

        if (LevelModifiers.controlsReverseMod)
        {
            controlsReversed.SetActive(true);
        }

        if (LevelModifiers.controlsMessedUpMod)
        {
            controlsWeird.SetActive(true);
        }

        if (LevelModifiers.dualWieldMod)
        {
            dualWield.SetActive(true);
        }
    }

    public void ActiveModifiers()
    {
        fireRate.SetActive(false);
        bulletSpeed.SetActive(false);
        enemyRotation.SetActive(false);
        sliderSize.SetActive(false);
        sliderSpeed.SetActive(false);
        zigZag.SetActive(false);
        projectileBounces.SetActive(false);
        controlsReversed.SetActive(false);
        controlsWeird.SetActive(false);
        dualWield.SetActive(false);
    }
}