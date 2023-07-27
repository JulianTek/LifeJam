using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventSystem;
using System;

public class CropInventoryUIHandler : MonoBehaviour
{
    [SerializeField]
    private List<Image> cropIcons;

    private void Start()
    {
        for (int i = 1; i < cropIcons.Count; i++)
        {
            cropIcons[i].gameObject.SetActive(false);
        }

        EventChannels.PlayerEvents.OnPlayerLevelUp += UnlockNewCrop;
    }

    private void UnlockNewCrop(int level)
    {
        cropIcons[level -1].gameObject.SetActive(true);
    }
}
