using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class garden3 : MonoBehaviour
{
    public GameObject catchDialog4;
    private Transform player;
    bool cantouch4=false;
    //bool istouched;
    //文本按行分割
    public string[] dialogRows4;
    //文本文件
    public TextAsset dialogFile4;
    //文本
    public TMP_Text dialohText4;
    int i4 = 0;
    public Button nextButton4;
    private void Start()
    {
        //ReadText(dialogFile);
       // istouched = false;
        //Debug.Log("1");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&cantouch4)
        {
            ReadText4(dialogFile4);
            ShowText4();
            catchDialog4.SetActive(true);

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
 
                cantouch4 = true;
                //ReadText2(dialogFile4);
                //catchDialog.SetActive(true);

            //cantouch = true;
            //Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D board4)
    {
        if (board4.gameObject.CompareTag("Player") )
        {
            cantouch4 = false;
            i4 = 0;
            //Debug.Log(cantouch);
            //CleacText();
            catchDialog4.SetActive(false);
        }
    }
    public void ReadText4(TextAsset _textAsset4)
    {
        dialogRows4 = _textAsset4.text.Split('\n');
        //string cell4 = _textAsset4.text;
        //UpdateText(cell4);

    }
    public void UpdateText(string _text4)
    {
        dialohText4.text = _text4;
        //_text = null;
        
    }
    //public void CleacText()
    //{
    //    string _clean = null;
    //    UpdateText(_clean);
    //}
    public void ShowText4()
    {
        if (i4 < dialogRows4.Length - 1)
        {
            string cell = dialogRows4[i4];
            UpdateText(cell);
            i4++;
        }
        else
        {
            catchDialog4.SetActive(false);
        } 
    }
    public void OnClickNext4()
    {
        ShowText4();
    }
}
