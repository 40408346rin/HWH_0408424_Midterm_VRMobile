using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject groupLight;
    [Header("會動的石頭")]
    public Transform chest;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("滑動音效")]
    public AudioClip soundWoodMove;
    [Header("動畫控制器")]
    public Animator aniDoor;

    public void LookDoor()
    {
        {
            aniDoor.SetTrigger("觸發器");
        }
    }

    public IEnumerator LightEffect()
    {
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        groupLight.SetActive(true);
        yield return new WaitForSeconds(0.3f);
    }

    public void StartMoveChest()
    {
        StartCoroutine(MoveChest());
    }
    public IEnumerator MoveChest()
    {
            for (int i = 0; i < 25; i++)
            {
                chest.position += chest.forward * 0.3f;             
                yield return new WaitForSeconds(0.001f);
            }
            chest.GetComponent<CapsuleCollider>().enabled = false;
            aud.PlayOneShot(soundWoodMove, 2.5f);
    }
    private void Start()
    {
        //LightEffect();                        // 呼叫自定義方法：一般呼叫方式
        StartCoroutine(LightEffect());          // 呼叫協程方式
    }
}