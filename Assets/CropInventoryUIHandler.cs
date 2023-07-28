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

    private void Start()
    {
        for (int i = 0; i < iconsOnHUD.Count; i++)
        {
            iconsOnHUD[i].gameObject.SetActive(false);
        }

        EventChannels.PlayerEvents.OnPlayerLevelUp += UnlockNewCrop;
        UnlockNewCrop(1);
    }

    private void UnlockNewCrop(int level)
    {
        iconsOnHUD[level -1].gameObject.SetActive(true);
        iconsOnHUD[level - 1].sprite = cropIcons[level - 1];
    }
}
