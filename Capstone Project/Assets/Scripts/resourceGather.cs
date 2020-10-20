﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resourceGather : MonoBehaviour
{
    public Transform resourceTarget;
    public Text resourceAmount;
    public Text enemyCount;
    public Text currencyAmount;
    public int resourceNumber = 0;
    public int currencyNumber = 0;
    public int monstersKilled = 0;
    public int maxWoodAmount = 100;
    public int maxCurrencyAmount = 100;
    public ResourceBar woodAmt;
    public ResourceBar currencyAmt;


    private void Start()
    {
        woodAmt.SetMaxAmount(maxWoodAmount);
        currencyAmt.SetMaxAmount(maxCurrencyAmount);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tree"))
        {
            resourceTarget = other.gameObject.transform;
        }
    }

    public void getResource()
    {
        if(resourceTarget != null)
        {
            Destroy(resourceTarget.gameObject);
            resourceTarget = null;
            resourceNumber += 10;
            updateResources();
        }
    }

    public void removecannonResources(int subAmt)
    {
        resourceNumber -= subAmt;
        updateResources();
    }

    public void incrementMonsterKill()
    {
        monstersKilled++;
        currencyNumber += 10;
        updateResources();
    }

    public int getcannonResources()
    {
        return resourceNumber;
    }

    public string GetMonstersKilled()
    {
        return monstersKilled.ToString();
    }

    void updateResources()
    {
        enemyCount.text = "Kills: " + monstersKilled.ToString();
        resourceAmount.text = resourceNumber.ToString();
        currencyAmount.text = currencyNumber.ToString();
        woodAmt.SetAmount(resourceNumber);
        currencyAmt.SetAmount(currencyNumber);
    }



    /*Not currently working *Check Later*
     * void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Tree") && other.gameObject == resourceTarget)
        {
            resourceTarget = null;
        }
    }
        */
}