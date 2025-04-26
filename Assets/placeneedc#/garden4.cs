using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class garden4 : MonoBehaviour
{
    public GameObject catchDialog5;
    private Transform player;
    bool cantouch5=false;
    //bool istouched;
    //文本按行分割
    public string[] dialogRows5;
    //文本文件
    public TextAsset dialogFile5;
    //文本
    public TMP_Text dialohText5;
    int i5 = 0;
    public Button nextButton5;
    private void Start()
    {
        //ReadText(dialogFile);
       // istouched = false;
        //Debug.Log("1");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&cantouch5)
        {
            ReadText5(dialogFile5);
            ShowText5();
            catchDialog5.SetActive(true);

        }
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    if (cantouch && !istouched) 
        //    {
        //        istouched=true;
        //    }
        //}

    }
    private void OnTriggerEnter2D(Collider2D board5)
    {
        if(board5.gameObject.CompareTag("Player"))
        {
 
                cantouch5 = true;
                //ReadText2(dialogFile4);
                //catchDialog.SetActive(true);

            //cantouch = true;
            //Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D board5)
    {
        if (board5.gameObject.CompareTag("Player") )
        {
            cantouch5 = false;
            i5 = 0;
            //Debug.Log(cantouch);
            //CleacText();
            catchDialog5.SetActive(false);
        }
    }
    public void ReadText5(TextAsset _textAsset5)
    {
        dialogRows5 = _textAsset5.text.Split('\n');
        //string cell4 = _textAsset4.text;
        //UpdateText(cell4);

    }
    public void UpdateText(string _text5)
    {
        dialohText5.text = _text5;
        //_text = null;
        
    }
    //public void CleacText()
    //{
    //    string _clean = null;
    //    UpdateText(_clean);
    //}
    public void ShowText5()
    {
        if (i5 < dialogRows5.Length - 1)
        {
            string cell = dialogRows5[i5];
            UpdateText(cell);
            i5++;
        }
        else
        {
            catchDialog5.SetActive(false);
        } 
    }
    public void OnClickNext5()
    {
        ShowText5();
    }
}
