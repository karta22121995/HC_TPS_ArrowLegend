using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("敵人資料")]
    public EnemyData data;            // 敵人資料

    protected NavMeshAgent agent;     // 導覽代理器
    protected Transform player;       // 玩家變形
    protected Animator ani;           // 動畫控制器
    protected float timer;            // 計時器

    private void Start()
    {
        // 先取得元件
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
        player = GameObject.Find("玩家").transform;
        agent.SetDestination(player.position);
    }

    private void Update()
    {
        Move();
    }

    // virtual 虛擬 : 讓子類別可以複寫
    protected virtual void Attack()
    {
        timer = 0;                          // 計時器 歸零
        ani.SetTrigger("攻擊觸發");         // 攻擊動畫
    }

    protected virtual void Move()
    {
        agent.SetDestination(player.position);  // 代理器.設定目的地(玩家.座標)
        
        Vector3 posTarget = player.position;    // 
        posTarget.y = transform.position.y;     // 
        transform.LookAt(posTarget);            // 

        

        if (agent.remainingDistance <= data.stopDistance)    // 如果 距離 <=
        {
            Wait();
        }
        else
        {
            agent.isStopped = false;            // 代理器.是否停止 = 否
            ani.SetBool("跑步開關", true);      // 開啟跑步開關
        }
    }

    protected virtual void Wait()
    {
        // base.Wait(); //使用付費方法內容

        agent.isStopped = true;             // 代理器.是否停止 = 是
        agent.velocity = Vector3.zero;      // 代理器.加速度 = 零
        ani.SetBool("跑步開關", false);     // 關閉跑步開關

        if (timer <= data.cd)
        {
            timer += Time.deltaTime;        // 時間累加

        }
        else
        {
            Attack();                       // 否則 計時器 > 冷卻時間 攻擊
        }
    }

    private void Hit()
    {

    }

    private void Dead()
    {

    }

}