using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class garden1 : MonoBehaviour
{
    public GameObject catchDialog2;
    private Transform player;
    bool cantouch2 = false;
    //bool istouched;
    //文本按行分割
    public string[] dialogRows2;
    //文本文件
    public TextAsset dialogFile2;
    //文本
    public TMP_Text dialohText2;
    int i2 = 0;
    public Button nextButton2;
    private void Start()
    {
        //ReadText(dialogFile);
       // istouched = false;
        //Debug.Log("1");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&cantouch2)
        {
            ReadText2(dialogFile2);
            ShowText2();
            catchDialog2.SetActive(true);

        }
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    if (cantouch && !istouched) 
        //    {
        //        istouched=true;
        //    }
        //}

    }
    private void OnTriggerEnter2D(Collider2D board2)
    {
        if(board2.gameObject.CompareTag("Player"))
        {
             cantouch2 = true;
                //ReadText2(dialogFile2);
                //catchDialog.SetActive(true);

           
            
            //Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D board2)
    {
        if (board2.gameObject.CompareTag("Player") )
        {
            cantouch2 = false;
            //Debug.Log(cantouch);
            //CleacText();
            catchDialog2.SetActive(false);
        }
    }
    public void ReadText2(TextAsset _textAsset2)
    {
        dialogRows2 = _textAsset2.text.Split('\n');
        //string cell2 = _textAsset2.text;
        //UpdateText(cell2);

    }
    public void UpdateText(string _text2)
    {
        dialohText2.text = _text2;
        //_text2 = null;
        
    }
    //public void CleacText()
    //{
    //    string _clean = null;
    //    UpdateText(_clean);
    //}
    public void ShowText2()
    {

       if(i2 < dialogRows2.Length-1)
        {
            string cell = dialogRows2[i2];
            UpdateText(cell);
            i2++;
        }
        else
        {
            catchDialog2.SetActive(false) ;
        }
    }
    public void OnClickNext2()
    {
        ShowText2 ();
    }
}
