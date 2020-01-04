using UnityEngine;

[CreateAssetMenu(fileName = "玩家資料", menuName = "KID/EnemyData")]
public class PlaysData : MonoBehaviour
{
    [Header("血量"), Range(100, 3000)]
    public float hp = 200;
}
