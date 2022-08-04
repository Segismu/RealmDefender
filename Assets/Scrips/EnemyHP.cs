using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHP : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Increase maxHitPoints when enemy destroyed.")]
    [SerializeField] int difficultyLvl = 1;
    int currentHitPoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyLvl;
            enemy.RewardGold();
        }

    }
}
