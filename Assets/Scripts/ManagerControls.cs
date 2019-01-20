using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ManagerControls : MonoBehaviour {

    public GameObject sliderTop;
    public GameObject sliderRight;
    public GameObject sliderBottom;
    public GameObject sliderLeft;
    
    // set to private after testing
    public float speedRight;
    public float speedRightBase;
    public float speedLeft;
    public float speedLeftBase;
    public float speedTop;
    public float speedTopBase;
    public float speedBottom;
    public float speedBottomBase;
    
    private float borderAdjustmentRight;
    private float borderAdjustmentLeft;
    private float borderAdjustmentTop;
    private float borderAdjustmentBottom;
    private float borderModifierAdjustment;

    private int borderLimitBase = 202;
    
    // border adjustments shouldn't need constant updating.. it's a constant.

    private string keyUp01;
    private string keyUp02;
    private string keyDown01;
    private string keyDown02;
    private string keyRight01;
    private string keyRight02;
    private string keyLeft01;
    private string keyLeft02;


    private void Start()
    {
        SetControls();
    }

    private void SetControls()
    {
        keyUp01 = "up";
        keyUp02 = "w";
        keyDown01 = "down";
        keyDown02 = "s";
        keyRight01 = "right";
        keyRight02 = "d";
        keyLeft01 = "left";
        keyLeft02 = "a";

        if (LevelModifiers.controlsReverseMod == true)
        {
            keyUp01 = "down";
            keyUp02 = "s";
            keyDown01 = "up";
            keyDown02 = "w";
            keyRight01 = "left";
            keyRight02 = "a";
            keyLeft01 = "right";
            keyLeft02 = "d";

            Debug.Log("Controls are reversed.");
        }
        if (LevelModifiers.controlsMessedUpMod == true)
        {
            keyUp01 = "left";
            keyUp02 = "d";
            keyDown01 = "right";
            keyDown02 = "a";
            keyRight01 = "down";
            keyRight02 = "w";
            keyLeft01 = "up";
            keyLeft02 = "s";

            Debug.Log("Controls are messed up.");
        }
    }

    void Update ()
    {
        if (Input.GetKey(keyUp01) || Input.GetKey(keyUp02))
        {
            CalculateSpeed();
            CalculateBorderAdjustments();

            if (sliderRight.transform.localPosition.y <= (borderLimitBase + borderAdjustmentRight) / borderModifierAdjustment)
            {
                sliderRight.transform.Translate(0, Time.deltaTime * speedRight, 0, Space.World);
            }
            if (sliderLeft.transform.localPosition.y <= borderLimitBase + borderAdjustmentLeft)
            {
                sliderLeft.transform.Translate(0, Time.deltaTime * speedLeft, 0, Space.World);
            }
        }

        if (Input.GetKey(keyDown01) || Input.GetKey(keyDown02))
        {
            CalculateSpeed();
            CalculateBorderAdjustments();

            if (sliderRight.transform.localPosition.y >= (-borderLimitBase - borderAdjustmentRight) / borderModifierAdjustment)
            {
                sliderRight.transform.Translate(0, -Time.deltaTime * speedRight, 0, Space.World);
            }
            if (sliderLeft.transform.localPosition.y >= -borderLimitBase - borderAdjustmentLeft)
            {
                sliderLeft.transform.Translate(0, -Time.deltaTime * speedLeft, 0, Space.World);
            }
        }
        
        if (Input.GetKey(keyRight01) || Input.GetKey(keyRight02))
        {
            CalculateSpeed();
            CalculateBorderAdjustments();

            if (sliderTop.transform.localPosition.x <= borderLimitBase + borderAdjustmentTop)
            {
                sliderTop.transform.Translate(Time.deltaTime * speedTop, 0, 0, Space.World);
            }
            if (sliderBottom.transform.localPosition.x <= borderLimitBase + borderAdjustmentBottom)
            {
                sliderBottom.transform.Translate(Time.deltaTime * speedBottom, 0, 0, Space.World);
            }
        }

        if (Input.GetKey(keyLeft01) || Input.GetKey(keyLeft02))
        {
            CalculateSpeed();
            CalculateBorderAdjustments();

            if (sliderTop.transform.localPosition.x >= -borderLimitBase - borderAdjustmentTop)
            {
                sliderTop.transform.Translate(-Time.deltaTime * speedTop, 0, 0, Space.World);
            }
            if (sliderBottom.transform.localPosition.x >= -borderLimitBase - borderAdjustmentBottom)
            {
                sliderBottom.transform.Translate(-Time.deltaTime * speedBottom, 0, 0, Space.World);
            }
        }
    }

    
    private float speedModifier;
    private float speedModifierMult;

    private void CalculateSpeed()
    {
        speedRightBase = sliderRight.GetComponentInChildren<Slider>().sliderSpeed;
        speedLeftBase = sliderLeft.GetComponentInChildren<Slider>().sliderSpeed;
        speedTopBase = sliderTop.GetComponentInChildren<Slider>().sliderSpeed;
        speedBottomBase = sliderBottom.GetComponentInChildren<Slider>().sliderSpeed;
        
        speedModifier = GetComponent<LevelModifiers>().speedVariation;

        speedModifierMult = speedModifier / 100;

        var speedChange01 = Random.Range(-speedModifierMult, speedModifierMult);
        var speedChange02 = Random.Range(-speedModifierMult, speedModifierMult);
        var speedChange03 = Random.Range(-speedModifierMult, speedModifierMult);
        var speedChange04 = Random.Range(-speedModifierMult, speedModifierMult);
        
        if (speedModifier > 0)
        {
            speedRight = speedRightBase + speedRightBase * speedChange01; // Speed = 100 + 100*(-0.15 .. 0.15) -> 100 + -15OR15 -> 85-115
            speedLeft = speedLeftBase + speedLeftBase * speedChange02; // Speed = 100 + 100*(-0.15 .. 0.15) -> 100 + -15OR15 -> 85-115
            speedTop = speedTopBase + speedTopBase * speedChange03; // Speed = 100 + 100*(-0.15 .. 0.15) -> 100 + -15OR15 -> 85-115
            speedBottom = speedBottomBase + speedBottomBase * speedChange04; // Speed = 100 + 100*(-0.15 .. 0.15) -> 100 + -15OR15 -> 85-115
            
            Mathf.FloorToInt(speedRight);
            Mathf.FloorToInt(speedLeft);
            Mathf.FloorToInt(speedTop);
            Mathf.FloorToInt(speedBottom);
        }
        else
        {
            speedRight = speedRightBase;
            speedLeft = speedLeftBase;
            speedTop = speedTopBase;
            speedBottom = speedBottomBase;
        }
    }

    private void CalculateBorderAdjustments()
    {
        borderAdjustmentRight = sliderRight.GetComponentInChildren<Slider>().borderSliderAdjustment;
        borderAdjustmentLeft = sliderLeft.GetComponentInChildren<Slider>().borderSliderAdjustment;
        borderAdjustmentTop = sliderTop.GetComponentInChildren<Slider>().borderSliderAdjustment;
        borderAdjustmentBottom = sliderBottom.GetComponentInChildren<Slider>().borderSliderAdjustment;

        borderModifierAdjustment = GetComponent<LevelModifiers>().sliderModifier;

        if (borderModifierAdjustment == 0)
        {
            borderModifierAdjustment = 1;
        }
    }


}
