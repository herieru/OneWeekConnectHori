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
    private GameObject title_menu_and_stage_select = null;


    [SerializeField]
    private GameObject result = null;

    private Subject<int> stage_select_subject = new Subject<int>();

    [SerializeField]
    private CubeManager cube = null;

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
		SoundController.Instance.PlayBgm(0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    /// <summary>
    /// ボタンクリックによるステージのロードと、非アクティブ
    /// </summary>
    /// <param name="_stage_no"></param>
    public void ButtonClickSelectStage(int _stage_no)
    {
        Debug.LogFormat("{0}",_stage_no);
        title_menu_and_stage_select.SetActive(false);
        cube.LoadStage(_stage_no);
    }


    /// <summary>
    /// タイトルに戻るためのもの
    /// </summary>
    public void ButtonClickReturnTitle()
    {
        result.SetActive(false);
        title_menu_and_stage_select.SetActive(true);
    }

}
