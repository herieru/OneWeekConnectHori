///<summary>
/// 概要：このクラスはメニューのUIを制御する系のものです。
/// 
/// <filename>
/// MenuUIController.cs
/// </filename>
///
/// <creatername>
/// 作成者：堀　明博
/// </creatername>
/// 
/// <address>
/// mailladdress:herie270714@gmail.com
/// </address>
///</summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MenuUIController : MonoBehaviour 
{

    [SerializeField]
    private GameObject title_menu = null;

    [SerializeField]
    private GameObject stage_select = null;

    [SerializeField]
    private GameObject result = null;

    private Subject<int> stage_select_subject = new Subject<int>();

    /// <summary>
    /// ステージセレクトの通知
    /// </summary>
    public Subject<int> StageSelectNotice
    {
        get
        {
            return stage_select_subject;
        }
    }


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
