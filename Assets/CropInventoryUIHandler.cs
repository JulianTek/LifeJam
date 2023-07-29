using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventSystem;
using System;

public class CropInventoryUIHandler : MonoBehaviour
{
    [SerializeField]
    private List<Image> iconsOnHUD;
    [SerializeField]
    private List<Sprite> cropIcons;

    private int selectedIndex = 0;
    private int unlockedIcons = 0;

    private void Start()
    {
        for (int i = 0; i < iconsOnHUD.Count; i++)
        {
            iconsOnHUD[i].gameObject.SetActive(false);
        }

        EventChannels.PlayerEvents.OnPlayerLevelUp += UnlockNewCrop;
        UnlockNewCrop(1);
        EventChannels.InputEvents.OnPlayerSwitchCrops += SetSelected;
        iconsOnHUD[0].color = Color.green;
    }

    private void UnlockNewCrop(int level)
    {
        iconsOnHUD[level - 1].gameObject.SetActive(true);
        iconsOnHUD[level - 1].sprite = cropIcons[level - 1];
        unlockedIcons++;
    }

    void SetSelected(float modifier)
    {
        int nextIndex = (int)modifier;
        selectedIndex += nextIndex;
        if (unlockedIcons - 1 < selectedIndex)
        {
            selectedIndex = 0;
        }
        if (selectedIndex < 0)
        {
            selectedIndex = unlockedIcons - 1;
        }

        iconsOnHUD[selectedIndex].color = Color.green;
        for (int i = 0; i < iconsOnHUD.Count; i++)
        {
            if (i != selectedIndex)
                iconsOnHUD[i].color = Color.white;
        }
    }
}
