using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using Unity.VisualScripting;

public class garden : MonoBehaviour
{
    public GameObject catchDialog;
    private Transform player;
    bool cantouch=false;
    //bool istouched;
    //文本按行分割
    public string[] dialogRows;
    //文本文件
    public TextAsset dialogFile;
    //文本
    public TMP_Text dialohText;
    int i = 0;
    public Button nextButton1;
    private void Start()
    {
        //ReadText(dialogFile);
        // istouched = false;
        //Debug.Log("1");
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)&& cantouch)
        {
            ReadText(dialogFile);
            ShowText();
            catchDialog.SetActive(true);
        }
 
        //if (Input.GetKeyUp(KeyCode.Escape))
        //{
        //    if (cantouch && !istouched) 
        //    {
        //        istouched=true;
        //    }
        //}

    }
        private void OnTriggerEnter2D(Collider2D _board1)
    {
        if(_board1.gameObject.CompareTag("Player"))
        {
           
                cantouch = true;
                //ReadText(dialogFile);
                //catchDialog.SetActive(true);

            //cantouch = true;
            //Debug.Log(cantouch);
        }
    }
    private void OnTriggerExit2D(Collider2D board1)
    {
        if (board1.gameObject.CompareTag("Player") )
        {
            cantouch = false;
            i = 0;
            //Debug.Log(cantouch);
            //CleacText();
            catchDialog.SetActive(false);
        }
    }
    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
        //string cell = _textAsset.text;
        //UpdateText(cell);

    }
    public void UpdateText(string _text)
    {
        dialohText.text = _text;
        //_text = null;
        
    }
    //public void CleacText()
    //{
    //    string _clean = null;
    //    UpdateText(_clean);
    //}
    public void ShowText()
    {
        if( i < dialogRows.Length-1)
        {
            string cell = dialogRows[i];
            UpdateText(cell);
            i++;
        }
        else
        {
            catchDialog.SetActive(false);
        }
    }
    public void OnClickNext()
    {
        ShowText();
    }
}
