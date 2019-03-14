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

public class CubeManager : MonoBehaviour
{
    [SerializeField]
    private StageData[] stage_datas;

    [SerializeField]
    private GameObject resborn_game_object;

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

    // Use this for initialization
    void Start()
    {
        stage_manager = new StageManager(this.gameObject, resborn_game_object, null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            stage_manager.CreateStageData(stage_datas[0]);
        }
    }
}
