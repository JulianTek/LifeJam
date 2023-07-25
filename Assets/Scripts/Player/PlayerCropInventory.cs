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
    }

    private void OnDestroy()
    {
        EventChannels.InputEvents.OnPlayerInteract -= PlantCrop;
    }

    // Update is called once per frame
    void Update()
    {
        
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
