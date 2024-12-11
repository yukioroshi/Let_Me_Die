using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Button DmgButton, speedButton;

    public GameObject UpgradeInterface;

    private void Start()
    {
        UpgradeInterface.SetActive(false);
        DmgButton.enabled = false;
        speedButton.enabled = false;
    }

    private void Update()
    {
        if(MoneyManager.score >= 30)
        {
            DmgButton.enabled = true;
            speedButton.enabled = true;
            
        }
        else
        {
            DmgButton.enabled = false;
            speedButton.enabled = false;
        }
    }

    public void UpgradeUIopen()
    {
        UpgradeInterface.SetActive(true);
    }

    public void UpgradeUIclose()
    {
        UpgradeInterface.SetActive(false);
    }
}
