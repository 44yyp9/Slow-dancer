using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemySpwner:MonoBehaviour
{
    [SerializeField] private List<Enemy1AnimationManeger> Enemies=new List<Enemy1AnimationManeger>();
    [SerializeField] private PlayerAnimationManeger player;
    private const float CameraLength = 30f;
    private void SetEnemys()
    {
        foreach (var enemy in Enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        SetEnemys();
    }
    private void Update()
    {
        SpwnEnemy();
        FadeEnemy();
    }
    private void SpwnEnemy()
    {
        var playerPosi=player.gameObject.transform.position;
        foreach (var enemy in Enemies)
        {
            if (!enemy.gameObject.activeInHierarchy)
            {
                var enemyPosi=enemy.gameObject.transform.position;
                var XLength=enemyPosi.x-playerPosi.x;
                if (XLength < CameraLength)
                {
                    enemy.gameObject.SetActive(true);
                }
            }
        }
    }
    private void FadeEnemy()
    {
        var playerPosi = player.transform.position;

        for (int i = Enemies.Count - 1; i >= 0; i--)
        {
            var enemy = Enemies[i];
            if (enemy.gameObject.activeInHierarchy)
            {
                var enemyPosi = enemy.transform.position;
                var xDistance = playerPosi.x - enemyPosi.x;
                if (xDistance > CameraLength)
                {
                    enemy.gameObject.SetActive(false);
                    Enemies.RemoveAt(i); // à¿ëSÇ…ÉäÉXÉgÇ©ÇÁçÌèú
                }
            }
        }
    }
}
