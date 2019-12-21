using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// [添加元件(類型(任何元件類型))] - 套用此腳本實執行
[RequireComponent(typeof(AudioSource))]
public class RandomSkill : MonoBehaviour
{
    [Header("圖片隨機圖片")]
    public Sprite[] spritesRandom;
    [Header("技能圖片")]
    public Sprite[] sprites;
    [Header("間隔時間"), Range(0f, 1f)]
    public float speed = 0.1f;
    [Header("次數"), Range(1, 10)]
    public int conut = 3;
    [Header("音效區域")]
    public AudioClip soundRandom;
    public AudioClip soundSkill;
    [Header("技能名稱")]
    public string[] skillsName = { "連射", "添加弓箭", "前後", "左右", "添加血量", "添加傷害", "添加攻速", "添加爆傷", };
    
    private Image imgSkill;
    private AudioSource aud;
    private Text textSkill;

    private int randomIndex;
    private Button btn;
    private GameObject objskill;

    private void Start()
    {
        imgSkill = GetComponent<Image>();
        aud = GetComponent<AudioSource>();
        btn = GetComponent<Button>();
        textSkill = transform.GetChild(0).GetComponent<Text>();  // 變形.取得子物件(索引值)
        objskill = GameObject.Find("隨機技能");

        StartCoroutine(StartRandom());                           // 啟動協成(開始隨機())

        btn.onClick.AddListener(ChooseSkill);
    }

    /// <summary>
    /// 選取技能
    /// </summary>
    private void ChooseSkill()
    {
        print("選取技能!" + skillsName[randomIndex]);
        objskill.SetActive(false);
    }

    /// <summary>
    /// 開始隨機效果
    /// </summary>
    /// <returns></returns>
    public IEnumerator StartRandom()
    {
        for (int J = 0; J < conut; J++)
        { 
            for (int i = 0; i < spritesRandom.Length; i++)
            {
            imgSkill.sprite = spritesRandom[i];            // 技能圖片.圖片 = 圖片隨機[索引值]
            aud.PlayOneShot(soundRandom, 0.1f);            // 音源.播放一次音效(音效片段，音量)
            yield return new WaitForSeconds(speed);        // 等待
            }
        }

        randomIndex = Random.Range(0, sprites.Length);      // 隨機值 = 隨機.範圍(最小，最大)
        imgSkill.sprite = sprites[randomIndex];             // 技能圖片.圖片 = 技能圖片[隨機值]
        textSkill.text = skillsName[randomIndex];           // 技能文字.文字 = 技能名稱[隨機值]
        aud.PlayOneShot(soundSkill, 0.7f);                  // 音源.播放一次音效(音效片段，音量)
        btn.interactable = true;                            //啟動互動
    }
}


