using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePoints : MonoBehaviour
{
    public GameObject sliderPlaceholder;
    public GameObject loseGame; // add this with code, instead of public gameobject


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ShrinkSlider();
    }


    private void ShrinkSlider()
    {
        //if (sliderPlaceholder.transform.gameObject.activeInHierarchy == false)
        if (loseGame.transform.gameObject.activeInHierarchy == false)
        {
            //freeze timer
            //pop-up the menu ; restart/return to menu
            //Time.timeScale = 0;
            Debug.Log("Lost the Game.");
        }

        if (sliderPlaceholder.transform.GetChild(2).transform.gameObject.activeInHierarchy == true)
        {
            sliderPlaceholder.transform.GetChild(2).transform.gameObject.SetActive(false);
            sliderPlaceholder.transform.GetChild(3).transform.gameObject.SetActive(true);
            loseGame.transform.gameObject.SetActive(false);
            //sliderPlaceholder.transform.gameObject.SetActive(false);
        }
        if (sliderPlaceholder.transform.GetChild(1).transform.gameObject.activeInHierarchy == true)
        {
            sliderPlaceholder.transform.GetChild(1).transform.gameObject.SetActive(false);
            sliderPlaceholder.transform.GetChild(2).transform.gameObject.SetActive(true);
        }

        if (sliderPlaceholder.transform.GetChild(0).transform.gameObject.activeInHierarchy == true)
        {
            sliderPlaceholder.transform.GetChild(0).transform.gameObject.SetActive(false);
            sliderPlaceholder.transform.GetChild(1).transform.gameObject.SetActive(true);
        }


        //sliderPlaceholder.transform.GetComponent<RectTransform>().localScale -= new Vector3 (0.05f , 0.05f, 0);
        //Debug.Log("Lose points.");

    }

}
