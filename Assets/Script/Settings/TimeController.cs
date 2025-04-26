using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [Range(0f, 2f)] public float defaultTimeScale = 1;//Ĭ����Ϸʱ���ٶ�

    [Header("�ӵ�ʱ��")]
    [SerializeField, Range(0f, 2f)] float bulletTimeScale;//�ӵ�ʱ���ٶ�
    [SerializeField] private float timeRecoveryDuration;//���ɻ�Ĭ����Ϸʱ��ĳ���ʱ��

    private GUIStyle labelStyle;
    private void Awake()
    {
        Time.timeScale = defaultTimeScale;


    }
    private void Start()
    {
        labelStyle = new GUIStyle();
        labelStyle.fontSize = 120;
        labelStyle.normal.textColor = Color.white;
    }
    //�������ݲ���
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 80), "ScaleTime = " + Time.timeScale, labelStyle);

    }


    public void BulletTime()
    {
        Time.timeScale = bulletTimeScale;
        StartCoroutine(nameof(TimeRecoveryCoroutine));
    }

    //�ָ�Ĭ��ʱ���Э��
    IEnumerator TimeRecoveryCoroutine()
    {
        float ratio = 0f;
        while (ratio < 1f)
        {
            ratio += Time.unscaledDeltaTime / timeRecoveryDuration;
            //������������ʼֵ��Ŀ��ֵ�Ͳ�ֵ������0~1��
            Time.timeScale = Mathf.Lerp(bulletTimeScale, defaultTimeScale, ratio);

            yield return null;//�ȴ���һ֡�ټ���ִ��
        }

    }

}
