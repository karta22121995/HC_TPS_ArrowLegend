using UnityEngine;
using System.Collections;  // 引用 系統.集合 API

public class EnemyFar : Enemy
{
    [Header("子彈物件")]
    public GameObject bullet;

    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(CreateBullet());                                    // 啟動協程

    }

    private IEnumerator CreateBullet()
    {
        yield return new WaitForSeconds(data.attackDelay);                         // 等待 
        Vector3 pos = new Vector3(0, data.attackOffset.y, data.attackOffset.z);    // 區域變數 座標 = 新 三維向量(0，位移.Y，0)
        // 座標 : 本身.座標 + 座標 + 前方 * 座標.Z
        Instantiate(bullet, transform.position + pos + transform.forward * data.attackOffset.z, Quaternion.identity);   // 實例化
    }

}
