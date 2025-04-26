using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class garden2 : MonoBehaviour
{
    public GameObject catchDialog3;
    private Transform player;
    bool cantouch3;
    //bool istouched;
    //文本按行分割
    public string[] dialogRows3;
    //文本文件
    public TextAsset dialogFile3;
    //文本
    public TMP_Text dialohText3;
    int i3 = 0;
    public Button nextButton3;
    private void Start()
    {
        //ReadText(dialogFile);
       // istouched = false;
        //Debug.Log("1");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&cantouch3)
        {
            ReadText3(dialogFile3);
            ShowText3();
            catchDialog3.SetActive(true);

        }
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    if (cantouch && !istouched) 
        //    {
        //        istouched=true;
        //    }
        //}

    }
    private void OnTriggerEnter2D(Collider2D board3)
    {
        if(board3.gameObject.CompareTag("Player"))
        {

            //ReadText2(dialogFile3);
            //catchDialog.SetActive(true);


            cantouch3 = true;
            //Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D board3)
    {
        if (board3.gameObject.CompareTag("Player") )
        {
            cantouch3 = false;
            i3 = 0;
            //Debug.Log(cantouch);
            //CleacText();
            catchDialog3.SetActive(false);
        }
    }
    public void ReadText3(TextAsset _textAsset3)
    {
        dialogRows3 = _textAsset3.text.Split('\n');
        //string cell3 = _textAsset3.text;
        //UpdateText(cell3);

    }
    public void UpdateText(string _text3)
    {
        dialohText3.text = _text3;
        //_text = null;
        
    }
    //public void CleacText()
    //{
    //    string _clean = null;
    //    UpdateText(_clean);
    //}
    public void ShowText3()
    {
        
        if (i3 < dialogRows3.Length-1)
        {
            string cell = dialogRows3[i3];
            UpdateText(cell);
            i3++;
        }
        else
        {
            catchDialog3.SetActive(false) ;
        }
    }
    public void OnClickNext3()
    {
        ShowText3 ();
    }
}
