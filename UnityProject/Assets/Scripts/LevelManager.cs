using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("是否亦開始顯示隨機技能")]
    public bool showRandomSkill;
    [Header("是否自動開門")]
    public bool autoOpenDoor;
    [Header("隨機技能介面")]
    public GameObject randomSkill;

    private Animator door;

    /// <summary>
    /// 顯示隨機技能介面
    /// </summary>
    private void Start()
    {
        door = GameObject.Find("門").GetComponent<Animator>();

        if (autoOpenDoor) Invoke("OpenDoor", 6);       // 延遲調用("方法名稱"，延遲時間)
        if (showRandomSkill) ShowRandomSkill();
    }

    private void ShowRandomSkill()
    {
        randomSkill.SetActive(true);
    }

    private void OpenDoor()
    {
        door.SetTrigger("開門");     // 動畫控制器.設定觸發("參數名稱")
    }
}
