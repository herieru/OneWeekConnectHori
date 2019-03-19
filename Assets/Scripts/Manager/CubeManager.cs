///<summary>
/// 概要：このクラスは、Cubeを管理するためのクラスです。
/// このクラスから、初期ステージを作成し、そのステージに沿ったものを作成します。
/// 
///
/// <filename>
/// CubeManager.cs
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
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    private StageData[] stage_datas = null;

    [SerializeField]
    private GameObject resborn_game_object = null;

    /// <summary>
    /// クリアしたときに出すクリアのテキスト
    /// </summary>
    [SerializeField]
    Text clear_text = null;

    [SerializeField]
    GameObject ClearObject = null;

    [SerializeField]
    private MenuUIController menu_ui_controller;

    /// <summary>
    /// 1辺の最大の取得する場所
    /// </summary>
    private const int MAX_ADGE_NUM = 7;

    /// <summary>
    /// ステージの管理者
    /// </summary>
    private StageManager stage_manager;

    /// <summary>
    /// 管理を行うためのモノ　横ー＞縦指定
    /// </summary>
    private CubeController[,] cube_controllers;

    private int select_stage = 0;

    // Use this for initialization
    void Start()
    {
        stage_manager = new StageManager(this.gameObject, resborn_game_object, null);
        
    }

    /// <summary>
    /// ステージをロードする。
    /// </summary>
    /// <param name="_stage_no"></param>
    public void LoadStage(int _stage_no)
    {
        select_stage = _stage_no;
        StartCoroutine(stage_load());
    }

    private IEnumerator stage_load()
    {
        stage_manager.CreateStageData(stage_datas[select_stage]);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        //右クリック
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("選択終了");
            stage_manager.SelectEnd();
        }


        if(stage_manager.Clear)
        {
            stage_manager.Clear = false;
            stage_manager.UnloadStage();
            ClearObject.SetActive(true);
            clear_text.gameObject.SetActive(true);
        }
    }
}
