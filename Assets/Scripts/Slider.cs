using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    [HideInInspector]
    public int sliderSpeed; // sets the speed for each slider. Used in ManagerControls.

    [HideInInspector]
    public int borderSliderAdjustment; // @ ManagerControls
    
    [Header("Slider Border Adjustment")] //Simple script to easily adjust the Borders of all sliders, depending on size
    private int sliderLargeBorderAdjustment = 0;
    private int sliderMediumBorderAdjustment = 10;
    private int sliderSmallSBorderAdjustment = 20; // * size change

    [Header("Slider Speed")] //Simple script to easily adjust the speed of all sliders, depending on size
    private int sliderLargeSpeed = 280;
    private int sliderMediumSpeed = 320;
    private int sliderSmallSpeed = 360;
    
    private void Start()
    {
        SetSliderSpeed();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NICE CATCH!");
    }

    private void SetSliderSpeed()
    {
        var sliderIndex = transform.GetSiblingIndex();

        if (sliderIndex == 0)
        {
            sliderSpeed = sliderLargeSpeed;
            borderSliderAdjustment = sliderLargeBorderAdjustment;
        }
        if (sliderIndex == 1)
        {
            sliderSpeed = sliderMediumSpeed;
            borderSliderAdjustment = sliderMediumBorderAdjustment;
        }
        if (sliderIndex == 2)
        {
            sliderSpeed = sliderSmallSpeed;
            borderSliderAdjustment = sliderSmallSBorderAdjustment;
        }
    }
}
