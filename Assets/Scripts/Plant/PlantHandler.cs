using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{
    private bool isFullyGrown;
    private bool timerStarted;
    private float timerDuration;
    private float timerLeft;
    private Crop _crop;


    private int spriteIndex;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetCrop(Crop crop)
    {
        // Set crop data,timer duration and start timer
        _crop = crop;
        timerDuration = _crop.TimeToGrow;
        timerStarted = true;
        _spriteRenderer.sprite = _crop.Sprites[0];
    }

    private void Update()
    {
        if (timerStarted && !isFullyGrown)
        {
            timerLeft += Time.deltaTime;

            if (timerLeft >= timerDuration)
            {
                isFullyGrown = true;
                _spriteRenderer.sprite = _crop.Sprites[_crop.Sprites.Length - 1];
            }

            // Create number between 0 and 1 to indicate growth progress
            float growthStage = Mathf.Clamp01(timerLeft / timerDuration);
            // Multiply this number by the amount of sprites in array to indicate growth progress
            int spriteIndex = Mathf.FloorToInt(growthStage * (_crop.Sprites.Length - 1));
            _spriteRenderer.sprite = _crop.Sprites[spriteIndex];
        }
    }

    private void Attack()
    {
    }
}
