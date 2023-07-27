using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperienceHandler : MonoBehaviour
{
    private int playerLevel;
    private int totalExperience;
    // Start is called before the first frame update
    void Start()
    {
        playerLevel = 1;
        totalExperience = 0;
    }

    private int GetExperienceNeededForLevel(int level)
    {
        return 50 + (10 * (level - 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool GetLevelUp()
    {
        return totalExperience >= GetExperienceNeededForLevel(playerLevel + 1);
    }

    private void AddExperience(int experience)
    {
        totalExperience += experience;
        if (GetLevelUp())
            playerLevel++;
    }
}
