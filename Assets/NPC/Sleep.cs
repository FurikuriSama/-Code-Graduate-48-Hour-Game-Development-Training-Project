using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class Sleep : MonoBehaviour
{
    public GameObject catchDialog7;
    private Transform player;
    bool cantouch7=false;
    //bool istouched;
    //文本按行分割
    public string[] dialogRows7;
    //文本文件
    public TextAsset dialogFile7;
    //文本
    public TMP_Text dialohText7;
    int i7 = 0;
    public Button nextButton7;
    private void Start()
    {
        //ReadText(dialogFile);
       // istouched = false;
        //Debug.Log("1");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&cantouch7)
        {
            ReadText6(dialogFile7);
            ShowText7();
            catchDialog7.SetActive(true);

        }
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    if (cantouch && !istouched) 
        //    {
        //        istouched=true;
        //    }
        //}

    }
    private void OnTriggerEnter2D(Collider2D board7)
    {
        if(board7.gameObject.CompareTag("Player"))
        {
 
                cantouch7 = true;
                //ReadText2(dialogFile4);
                //catchDialog.SetActive(true);

            //cantouch = true;
            //Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D board7)
    {
        if (board7.gameObject.CompareTag("Player") )
        {
            cantouch7 = false;
            i7 = 0;
            //Debug.Log(cantouch);
            //CleacText();
            catchDialog7.SetActive(false);
        }
    }
    public void ReadText6(TextAsset _textAsset7)
    {
        dialogRows7 = _textAsset7.text.Split('\n');
        //string cell4 = _textAsset4.text;
        //UpdateText(cell4);

    }
    public void UpdateText(string _text7)
    {
        dialohText7.text = _text7;
        //_text = null;
        
    }
    //public void CleacText()
    //{
    //    string _clean = null;
    //    UpdateText(_clean);
    //}
    public void ShowText7()
    {
        if (i7 < dialogRows7.Length - 1)
        {
            string cell = dialogRows7[i7];
            UpdateText(cell);
            i7++;
        }
        else
        {
            catchDialog7.SetActive(false);
        } 
    }
    public void OnClickNext7()
    {
        ShowText7();
    }
}
