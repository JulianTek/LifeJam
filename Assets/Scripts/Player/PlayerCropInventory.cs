using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventSystem;

public class PlayerCropInventory : MonoBehaviour
{
    [SerializeField]
    private List<Crop> crops = new List<Crop>();
    private int selectedIndex;
    [SerializeField]
    private GameObject objectToPlant;

    void Start()
    {
        selectedIndex = 0;

        EventChannels.InputEvents.OnPlayerInteract += PlantCrop;
        EventChannels.InputEvents.OnPlayerSwitchCrops += SwitchCrop;
    }

    private void OnDestroy()
    {
        EventChannels.InputEvents.OnPlayerInteract -= PlantCrop;
        EventChannels.InputEvents.OnPlayerSwitchCrops -= SwitchCrop;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchCrop(float direction)
    {
        int nextIndex = (int)direction;
        selectedIndex += nextIndex;
        if (crops.Count - 1 < selectedIndex)
        {
            selectedIndex = 0;
        }
        if (selectedIndex < 0)
        {
            selectedIndex = crops.Count - 1;
        }
        Debug.Log(crops[selectedIndex]);
    }

    void PlantCrop()
    {
        if (crops[selectedIndex] != null)
        {
            GameObject plantedCrop = ObjectPoolHandler.SpawnObject(objectToPlant, gameObject.transform.position, Quaternion.identity);
            plantedCrop.GetComponent<PlantHandler>().SetCrop(crops[selectedIndex]);
        }
    }
}
