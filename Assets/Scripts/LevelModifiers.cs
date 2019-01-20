using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModifiers : MonoBehaviour
{
    public GameObject badGuysPlaceholder;
    private GameObject badGuyActiveObject;
    
    private int previousRoundNumber;
    private int activeRoundNumber;

    [Header("Slider Placeholders")]
    public GameObject sliderTop;
    public GameObject sliderRight;
    public GameObject sliderBottom;
    public GameObject sliderLeft;

    [Header("Modifier Bools")] // activators. Place within LevelX to activate
    private bool fireRateBool;
    private bool bulletSpeedBool;
    private bool enemyRotateDegreesBool;
    private bool sliderSizeBool;
    private bool sliderSpeedBool;
    private bool zigZagBool;
    
    [Header("Modifier Boss Bools")] // activators. Place within LevelX to activate
    private bool bulletBounceBossBool;
    private bool controlsReverseBossBool;
    private bool controlsMessedUpBossBool;
    private bool dualWieldBossBool;

    [Header("Modifier values")]
    private float fireRateCurrent;
    private float fireRateRound01 = 0.9f; // based of original value
    private float fireRateRound02 = 0.8f;
    private float fireRateRound03 = 0.7f;
    private float fireRateRound04 = 0.6f;
    private float fireRateRound05 = 0.5f;

    private float bulletSpeedCurrent;
    private float bulletSpeedRound01 = 1.1f;
    private float bulletSpeedRound02 = 1.2f;
    private float bulletSpeedRound03 = 1.3f;
    private float bulletSpeedRound04 = 1.4f;
    private float bulletSpeedRound05 = 1.5f;

    public int speedVariation; // %
    private int speedVariationRound01 = 120; // = 120% differential both up and down
    private int speedVariationRound02 = 150;
    private int speedVariationRound03 = 180;
    private int speedVariationRound04 = 200;
    private int speedVariationRound05 = 250;

    public static float zigZagCurrent; // GET RID OF STATIC??
    private float zigZagRound01 = 0.4f; // = amount of seconds to turn in either direction 
    private float zigZagRound02 = 0.35f;
    private float zigZagRound03 = 0.3f;
    private float zigZagRound04 = 0.25f;
    private float zigZagRound05 = 0.2f;

    [Header("Static Bools (if Mod is active)")]
    public static bool fireRateMod;
    public static bool bulletSpeedMod;
    public static bool enemyRotationMod;
    public static bool sliderSizeMod;
    public static bool sliderSpeedMod;
    public static bool ZigZagMod;
    public static bool bulletBounceMod;
    public static bool controlsReverseMod;
    public static bool controlsMessedUpMod;
    public static bool dualWieldMod;

    public static bool rotationAngleRound01;
    public static bool rotationAngleRound02;
    public static bool rotationAngleRound03;

    [HideInInspector]
    public float sliderModifier; // used in ManagerControls
    private float sliderSize01 = 0.1f; // - 10%
    private float sliderSize02 = 0.2f; // - 20%
    private float sliderSize03 = 0.3f;
    private float sliderSize04 = 0.4f;
    private float sliderSize05 = 0.5f;


    private void Awake()
    {
        DeactivateAllBadGuys(); // ACTIVATE THIS SHIT AFTER TESTING~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        DeactivateAllModifiers();
        DeactivateAllRotationModifiers();
        
        previousRoundNumber = activeRoundNumber;

        LoadLevelChoice();

        ModifierUpdate(); // activates the modifiers before the round is officially starting (to not have to wait for the delay for modifiers to activate)
    }

    private void LoadLevelChoice() // I'm sure this can be simplified.. ?
    {
        if (ManagerScenes.levelChosenNumberStatic == 101)
        {
            LevelBoss01();
        }
        if (ManagerScenes.levelChosenNumberStatic == 102)
        {
            LevelBoss02();
        }
        if (ManagerScenes.levelChosenNumberStatic == 103)
        {
            LevelBoss03();
        }
        if (ManagerScenes.levelChosenNumberStatic == 104)
        {
            LevelBoss04();
        }

        if (ManagerScenes.levelChosenNumberStatic == 1)
        {
            Level01();
        }
        if (ManagerScenes.levelChosenNumberStatic == 2)
        {
            Level02();
        }
        if (ManagerScenes.levelChosenNumberStatic == 3)
        {
            Level03();
        }
        if (ManagerScenes.levelChosenNumberStatic == 4)
        {
            Level04();
        }
        if (ManagerScenes.levelChosenNumberStatic == 5)
        {
            Level05();
        }
        if (ManagerScenes.levelChosenNumberStatic == 6)
        {
            Level06();
        }
        if (ManagerScenes.levelChosenNumberStatic == 7)
        {
            Level07();
        }
        if (ManagerScenes.levelChosenNumberStatic == 8)
        {
            Level08();
        }
        if (ManagerScenes.levelChosenNumberStatic == 9)
        {
            Level09();
        }
        if (ManagerScenes.levelChosenNumberStatic == 10)
        {
            Level10();
        }
    }
    
    private void LevelBoss01()
    {
        EnableBadGuy(1);
        fireRateBool = true;
        zigZagBool = true;
        dualWieldBossBool = true;
    }
    private void LevelBoss02()
    {
        EnableBadGuy(1);
        bulletSpeedBool = true;
        enemyRotateDegreesBool = true;
        controlsReverseBossBool = true;
    }
    private void LevelBoss03()
    {
        EnableBadGuy(1);
        bulletSpeedBool = true;
        enemyRotateDegreesBool = true;
        controlsReverseBossBool = true;
    }
    private void LevelBoss04()
    {
        EnableBadGuy(1);
        bulletSpeedBool = true;
        enemyRotateDegreesBool = true;
        controlsReverseBossBool = true;
    }


    private void Level01()
    {
        EnableBadGuy(0); // ?? change #number to ManagerScenes.levelChosenNumberStatic -> Use a new enemy per level
        fireRateBool = true; // add all active modifiers to a list. When new round is starting, get all modifiers in this list, add +1 to these modifiers and empty the list, then readd the leveled up modifiers to this list.
        //sliderSizeBool = true;
        //sliderSpeedBool = true;
        //bulletBounceBossBool = true;
        //controlsMessedUpBossBool = true;
        zigZagBool = true;
        dualWieldBossBool = true;
    }

    private void Level02()
    {
        EnableBadGuy(1);
        bulletSpeedBool = true;
        enemyRotateDegreesBool = true;
        controlsReverseBossBool = true;
    }

    private void Level03()
    {
        EnableBadGuy(1);
        sliderSpeedBool = true;
        controlsMessedUpBossBool = true;
    }

    private void Level04()
    {
        EnableBadGuy(0);
        bulletBounceBossBool = true;
        sliderSizeBool = true;
    }

    private void Level05()
    {
        EnableBadGuy(0);
        bulletBounceBossBool = true;
        sliderSizeBool = true;
    }

    private void Level06()
    {
        EnableBadGuy(0);
        bulletBounceBossBool = true;
        sliderSizeBool = true;
    }

    private void Level07()
    {
        EnableBadGuy(0);
        bulletBounceBossBool = true;
        sliderSizeBool = true;
    }

    private void Level08()
    {
        EnableBadGuy(0);
        bulletBounceBossBool = true;
        sliderSizeBool = true;
    }

    private void Level09()
    {
        EnableBadGuy(0);
        bulletBounceBossBool = true;
        sliderSizeBool = true;
    }

    private void Level10()
    {
        EnableBadGuy(0);
        bulletBounceBossBool = true;
        sliderSizeBool = true;
    }


    public void FireRateModifier() // int roundNumber
    {
        fireRateMod = true;

        fireRateCurrent = badGuyActiveObject.transform.GetComponent<BadGuy>().fireRate; // get the value
        float fireRate = fireRateCurrent;

        if (activeRoundNumber == 1) // first round
        {
            fireRate = fireRateCurrent * fireRateRound01;
        }
        if (activeRoundNumber == 2)
        {
            fireRate = fireRateCurrent / fireRateRound01 * fireRateRound02; // remove the "/ fireRateRound01", to have it stack multiplicatively instead of additively
        }
        if (activeRoundNumber == 3)
        {
            fireRate = fireRateCurrent / fireRateRound02 * fireRateRound03;
        }
        if (activeRoundNumber == 4)
        {
            fireRate = fireRateCurrent / fireRateRound03 * fireRateRound04;
        }
        if (activeRoundNumber == 5)
        {
            fireRate = fireRateCurrent / fireRateRound04 * fireRateRound05;
        }
        
        badGuyActiveObject.transform.GetComponent<BadGuy>().fireRate = fireRate; // sets the new value
        Debug.Log("Changed fireRate from: " + fireRateCurrent + " to: " + fireRate);
    }
    
    public void BulletSpeedModifier()
    {
        bulletSpeedMod = true;

        GameObject bulletObject = badGuyActiveObject.transform.GetComponent<BadGuy>().Bullet;
        bulletSpeedCurrent = bulletObject.transform.GetComponentInChildren<Bullet>().bulletSpeed;
        float bulletSpeedModified = bulletSpeedCurrent;

        if (activeRoundNumber == 1)
        {
            bulletSpeedModified = bulletSpeedCurrent * bulletSpeedRound01;
        }
        if (activeRoundNumber == 2)
        {
            bulletSpeedModified = bulletSpeedCurrent / bulletSpeedRound01 * bulletSpeedRound02;
        }
        if (activeRoundNumber == 3)
        {
            bulletSpeedModified = bulletSpeedCurrent / bulletSpeedRound02 * bulletSpeedRound03;
        }
        if (activeRoundNumber == 4)
        {
            bulletSpeedModified = bulletSpeedCurrent / bulletSpeedRound03 * bulletSpeedRound04;
        }
        if (activeRoundNumber == 5)
        {
            bulletSpeedModified = bulletSpeedCurrent / bulletSpeedRound04 * bulletSpeedRound05;
        }
        
        badGuyActiveObject.transform.GetComponent<BadGuy>().Bullet.transform.GetComponentInChildren<Bullet>().bulletSpeed = bulletSpeedModified;
        //Debug.Log("Changed bulletSpeed from: " + bulletSpeedCurrent + " to: " + bulletSpeedMod);
    }
    
    public void EnemyRotateModifier()
    {
        enemyRotationMod = true;

        if (activeRoundNumber == 1)
        {
            rotationAngleRound01 = true;
        }
        if (activeRoundNumber == 2)
        {
            rotationAngleRound02 = true;
        }
        if (activeRoundNumber == 3)
        {
            rotationAngleRound03 = true;
        }
    }
    
    public void SliderSizeModifier()
    {
        sliderSizeMod = true;

        RectTransform[] topChildArray = sliderTop.GetComponentsInChildren<RectTransform>(true); // (true) -> ALSO GRABS INACTIVE OBJECTS!!!
        RectTransform[] rightChildArray = sliderRight.GetComponentsInChildren<RectTransform>(true);
        RectTransform[] bottomChildArray = sliderBottom.GetComponentsInChildren<RectTransform>(true);
        RectTransform[] leftChildArray = sliderLeft.GetComponentsInChildren<RectTransform>(true);

        List<RectTransform> topSliders = new List<RectTransform>();
        List<RectTransform> rightSliders = new List<RectTransform>();
        List<RectTransform> bottomSliders = new List<RectTransform>();
        List<RectTransform> leftSliders = new List<RectTransform>();
        
        
        foreach (RectTransform child in topChildArray)
        {
            topSliders.Add(child);
        }
        foreach (RectTransform child in rightChildArray)
        {
            rightSliders.Add(child);
        }
        foreach (RectTransform child in bottomChildArray)
        {
            bottomSliders.Add(child);
        }
        foreach (RectTransform child in leftChildArray)
        {
            leftSliders.Add(child);
        }


        float sliderOldModifier = sliderModifier;

        if (sliderOldModifier == 0)
        {
            sliderOldModifier = 1;
        }

        sliderModifier = 1;

        if (activeRoundNumber == 1)
        {
            sliderModifier = 1 - sliderSize01;
        }
        if (activeRoundNumber == 2)
        {
            sliderModifier = 1 - sliderSize02;
        }
        if (activeRoundNumber == 3)
        {
            sliderModifier = 1 - sliderSize03;
        }
        if (activeRoundNumber == 4)
        {
            sliderModifier = 1 - sliderSize04;
        }
        if (activeRoundNumber == 5)
        {
            sliderModifier = 1 - sliderSize05;
        }

        foreach (RectTransform child in topSliders)
        {
            child.sizeDelta = new Vector2(child.sizeDelta.x / sliderOldModifier * sliderModifier, child.sizeDelta.y);
        }
        foreach (RectTransform child in bottomSliders)
        {
            child.sizeDelta = new Vector2(child.sizeDelta.x / sliderOldModifier * sliderModifier, child.sizeDelta.y);
        }
        foreach (RectTransform child in rightSliders)
        {
            child.sizeDelta = new Vector2(child.sizeDelta.x, child.sizeDelta.y / sliderOldModifier * sliderModifier);
        }
        foreach (RectTransform child in leftSliders)
        {
            child.sizeDelta = new Vector2(child.sizeDelta.x, child.sizeDelta.y / sliderOldModifier * sliderModifier);
        }
    }

    public void SliderSpeedModifier()
    {
        sliderSpeedMod = true;

        if (activeRoundNumber == 1)
        {
            speedVariation = speedVariationRound01;
        }
        if (activeRoundNumber == 2)
        {
            speedVariation = speedVariationRound02;
        }
        if (activeRoundNumber == 3)
        {
            speedVariation = speedVariationRound03;
        }
        if (activeRoundNumber == 4)
        {
            speedVariation = speedVariationRound04;
        }
        if (activeRoundNumber == 5)
        {
            speedVariation = speedVariationRound05;
        }
        //Debug.Log("Changed Slider Speed by: " + speedVariation + "%.");
    }

    public void ZigZagModifier()
    {
        ZigZagMod = true;

        if (activeRoundNumber == 1)
        {
            zigZagCurrent = zigZagRound01;
        }
        if (activeRoundNumber == 2)
        {
            zigZagCurrent = zigZagRound02;
        }
        if (activeRoundNumber == 3)
        {
            zigZagCurrent = zigZagRound03;
        }
        if (activeRoundNumber == 4)
        {
            zigZagCurrent = zigZagRound04;
        }
        if (activeRoundNumber == 5)
        {
            zigZagCurrent = zigZagRound05;
        }
    }

    public void BulletBounceBossModifier()
    {
        bulletBounceMod = true;
    }

    public void ControlsReverseBossModifier()
    {
        controlsReverseMod = true;
    }

    public void ControlsMessedUpBossModifier()
    {
        controlsMessedUpMod = true;
    }

    public void DualWieldBossModifier()
    {
        dualWieldMod = true;
    }

    private void EnableBadGuy(int badGuyObject)
    {
        var badGuyChild = badGuyObject;
        var badGuy = badGuysPlaceholder.transform.GetChild(badGuyChild);
        badGuy.gameObject.SetActive(true);

        badGuyActiveObject = badGuy.gameObject; //
    }
    
    private void DeactivateAllBadGuys()
    {
        //var a = badGuysPlaceholder.transform.GetChild(0);

        for (int i = 0; i < badGuysPlaceholder.transform.childCount; i++)
        {
            var child = badGuysPlaceholder.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
    }

    private void DeactivateAllModifiers()
    {
        fireRateBool = false;
        bulletSpeedBool = false;
        enemyRotateDegreesBool = false;
        sliderSizeBool = false;
        sliderSpeedBool = false;
        zigZagBool = false;
        bulletBounceBossBool = false;
        controlsReverseBossBool = false;
        controlsMessedUpBossBool = false;
        dualWieldBossBool = false;

        // Statics
        fireRateMod = false;
        bulletSpeedMod = false;
        enemyRotationMod = false;
        sliderSizeMod = false;
        sliderSpeedMod = false;
        ZigZagMod = false;
        bulletBounceMod = false;
        controlsReverseMod = false;
        controlsMessedUpMod = false;
        dualWieldMod = false;
}

    private void DeactivateAllRotationModifiers()
    {
        rotationAngleRound01 = false;
        rotationAngleRound02 = false;
        rotationAngleRound03 = false;
    }
    
    private void FixedUpdate()
    {
        // read all modifiers in the list, add a level to all items that were in the list, empty the list, then readd them to the list after having them leveled up

        activeRoundNumber = transform.GetComponent<Manager>().roundNumber;
        
        if (previousRoundNumber != activeRoundNumber) // update is only be called when going to the next round.
        {
            ModifierUpdate(); // instead of calling the function, call only the functions that are in the list. // testing only
        }
    }

    private void ModifierUpdate()
    {
        if (fireRateBool)
        {
            FireRateModifier();
        }
        if (bulletSpeedBool)
        {
            BulletSpeedModifier();
        }
        if (enemyRotateDegreesBool)
        {
            EnemyRotateModifier();
        }
        if (sliderSizeBool)
        {
            SliderSizeModifier();
        }
        if (sliderSpeedBool)
        {
            SliderSpeedModifier();
        }
        if (zigZagBool)
        {
            ZigZagModifier();
        }

        if (bulletBounceBossBool)
        {
            BulletBounceBossModifier();
        }
        if (controlsReverseBossBool)
        {
            ControlsReverseBossModifier();
        }
        if (controlsMessedUpBossBool)
        {
            ControlsMessedUpBossModifier();
        }
        if (dualWieldBossBool)
        {
            DualWieldBossModifier();
        }

        previousRoundNumber = activeRoundNumber;
    }
}