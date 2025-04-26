using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class Learn : MonoBehaviour
{
    public GameObject catchDialog6;
    private Transform player;
    bool cantouch6=false;
    //bool istouched;
    //文本按行分割
    public string[] dialogRows6;
    //文本文件
    public TextAsset dialogFile6;
    //文本
    public TMP_Text dialohText6;
    int i6 = 0;
    public Button nextButton6;
    private void Start()
    {
        //ReadText(dialogFile);
       // istouched = false;
        //Debug.Log("1");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&cantouch6)
        {
            ReadText6(dialogFile6);
            ShowText6();
            catchDialog6.SetActive(true);

        }
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    if (cantouch && !istouched) 
        //    {
        //        istouched=true;
        //    }
        //}

    }
    private void OnTriggerEnter2D(Collider2D board6)
    {
        if(board6.gameObject.CompareTag("Player"))
        {
 
                cantouch6 = true;
                //ReadText2(dialogFile4);
                //catchDialog.SetActive(true);

            //cantouch = true;
            //Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D board6)
    {
        if (board6.gameObject.CompareTag("Player") )
        {
            cantouch6 = false;
            i6 = 0;
            //Debug.Log(cantouch);
            //CleacText();
            catchDialog6.SetActive(false);
        }
    }
    public void ReadText6(TextAsset _textAsset6)
    {
        dialogRows6 = _textAsset6.text.Split('\n');
        //string cell4 = _textAsset4.text;
        //UpdateText(cell4);

    }
    public void UpdateText(string _text6)
    {
        dialohText6.text = _text6;
        //_text = null;
        
    }
    //public void CleacText()
    //{
    //    string _clean = null;
    //    UpdateText(_clean);
    //}
    public void ShowText6()
    {
        if (i6 < dialogRows6.Length - 1)
        {
            string cell = dialogRows6[i6];
            UpdateText(cell);
            i6++;
        }
        else
        {
            catchDialog6.SetActive(false);
        } 
    }
    public void OnClickNext6()
    {
        ShowText6();
    }
}
