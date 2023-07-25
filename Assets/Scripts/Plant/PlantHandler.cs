using EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandler : MonoBehaviour
{
    private bool isFullyGrown;
    private bool growthTimerStarted;
    private float timerDuration;
    private float timerLeft;
    private Crop _crop;

    private bool enemyInContactCollider;
    private bool enemyInMeleeCollider;

    [SerializeField]
    private GameObject projectilePrefab;


    [SerializeField]
    private GameObject meleeColliders, contactColliders, projectileColliders;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnDisable()
    {
        ResetCrop();
    }

    public void SetCrop(Crop crop)
    {
        // Set crop data,timer duration and start timer
        _crop = crop;
        timerDuration = _crop.TimeToGrow;
        growthTimerStarted = true;
    }

    void HandleColliders()
    {
        switch (_crop.DamageType)
        {
            case DamageType.Contact:
                contactColliders.SetActive(true);
                break;
            case DamageType.Projectile:
                projectileColliders.SetActive(true);
                break;
            case DamageType.Melee:
                meleeColliders.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if (growthTimerStarted && !isFullyGrown)
        {
            timerLeft += Time.deltaTime;

            if (timerLeft >= timerDuration)
            {
                isFullyGrown = true;
                _spriteRenderer.sprite = _crop.Sprites[_crop.Sprites.Length - 1];
                HandleColliders();
                timerLeft = 0;
            }

            // Create number between 0 and 1 to indicate growth progress
            float growthStage = Mathf.Clamp01(timerLeft / timerDuration);
            // Multiply this number by the amount of sprites in array to indicate growth progress
            int spriteIndex = Mathf.FloorToInt(growthStage * (_crop.Sprites.Length - 1));
            _spriteRenderer.sprite = _crop.Sprites[spriteIndex];
        }
        if (enemyInContactCollider)
        {
            EventChannels.EnemyEvents.OnEnemyTakesDamage(_crop.DamagePerHit);
        }

        if (enemyInMeleeCollider)
        {
            timerLeft += Time.deltaTime;
            if (timerLeft >= 2f)
            {
                EventChannels.EnemyEvents.OnEnemyTakesDamage?.Invoke(_crop.DamagePerHit);
                timerLeft = 0;
                Debug.Log("EnemyHit");
            }
        }

        if (isFullyGrown)
        {
            _spriteRenderer.sprite = _crop.Sprites[_crop.Sprites.Length - 1];
            timerLeft += Time.deltaTime;
            if (timerLeft >= _crop.Duration)
                ObjectPoolHandler.ReturnObjectToPool(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFullyGrown)
            return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            switch (_crop.DamageType)
            {
                case DamageType.Melee:
                    enemyInMeleeCollider = true;    
                    break;
                case DamageType.Contact:
                    enemyInContactCollider = true;
                    break;
                case DamageType.Projectile:
                    GameObject projectile = ObjectPoolHandler.SpawnObject(projectilePrefab, transform.position, Quaternion.identity);
                    Vector3 directionToShoot = new Vector3(other.transform.position.x - transform.position.x, 0, other.transform.position.y - transform.position.y);
                    projectile.GetComponent<Rigidbody>().AddForce(directionToShoot * 4f, ForceMode.Impulse);
                    Debug.Log(directionToShoot);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (_crop.DamageType == DamageType.Contact)
                enemyInContactCollider = false;
            else if (_crop.DamageType == DamageType.Melee)
                enemyInMeleeCollider = false;
        }
    }

    void MeleeDamage(float damage)
    {
        EventChannels.EnemyEvents.OnEnemyTakesDamage?.Invoke(damage);
    }

    void ResetCrop()
    {
        _crop = null;
        timerLeft = 0;
        isFullyGrown = false;
        growthTimerStarted = false;
    }
}
