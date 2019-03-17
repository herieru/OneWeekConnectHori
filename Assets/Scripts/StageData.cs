///<summary>
/// 概要：このクラスは、ステージを表現するためのクラスです。
/// このクラスのデータの構造としては以下のようなものです。
/// プレイヤーに関しての情報
/// ・プレイヤーの位置インデクスX,Y　これは、現在立っている島を表す
/// ・現在のインデックス　これは、島の巡回をする際に使用する。
/// 
/// 
/// 島情報
/// ・どの島とつながっているか？
/// ・OFFにするもの
/// 
/// 
/// <filename>
/// StageData.cs
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

[System.Serializable]
public class StageIslandData
{
    [SerializeField]
    public int x_index;
    [SerializeField]
    public int y_index;
}

[System.Serializable]
public class StageIslandDataList
{
    [SerializeField]
    public List<StageIslandData> ConnetIsland;

}


public class StageData :ScriptableObject
{
    /// <summary>
    /// プレイヤーの位置
    /// </summary>
    [SerializeField]
    public StageIslandData PlayerPos;

    /// <summary>
    /// プレイヤー自体が、移動する際に、どのインデックスに向かうか？
    /// 設定する際には、必ず隣接している部分と、つながっている数を元に、選ぶ必要がある。
    /// </summary>
    public int LoopIndex;

    /// <summary>
    /// つながっている島の情報
    /// </summary>
    [SerializeField]
    public List<StageIslandDataList> ConnectIsland;

    /// <summary>
    /// アイテムのデータのリストe
    /// </summary>
    [SerializeField]
    public List<StageIslandData> item_data_list;

    /// <summary>
    /// ゴールの場所
    /// </summary>
    [SerializeField]
    public StageIslandData goal_data;

}

//プレイ用のステージデータ
public class PlayableStageData
{
    /// <summary>
    /// ステージデータの中身をコピーする
    /// </summary>
    /// <param name="_stage_data"></param>
    public PlayableStageData(StageData _stage_data)
    {
        PlayerPos = new StageIslandData()
        {
            x_index = _stage_data.PlayerPos.x_index,
            y_index = _stage_data.PlayerPos.y_index
        };

        LoopIndex = _stage_data.LoopIndex;

        ConnectIsland = new List<StageIslandDataList>();

        foreach(var _list_data in _stage_data.ConnectIsland)
        {
            List<StageIslandData> _is_land_data = new List<StageIslandData>();

            foreach(var _data in _list_data.ConnetIsland)
            {
                StageIslandData _island_data = new StageIslandData()
                {
                    x_index = _data.x_index,
                    y_index = _data.y_index
                };

                _is_land_data.Add(_island_data);
            }
            StageIslandDataList _chank_list = new StageIslandDataList()
            {
                ConnetIsland = _is_land_data,
            };
            ConnectIsland.Add(_chank_list);
        }//for each


        StageIslandData _goaldata = new StageIslandData()
        {
            x_index = _stage_data.goal_data.x_index,
            y_index = _stage_data.goal_data.y_index
        };

        GoalData = _goaldata;


    }

    /// <summary>
    /// プレイヤーの位置
    /// </summary>
    public StageIslandData PlayerPos;

    /// <summary>
    /// プレイヤー自体が、移動する際に、どのインデックスに向かうか？
    /// 設定する際には、必ず隣接している部分と、つながっている数を元に、選ぶ必要がある。
    /// </summary>
    public int LoopIndex;

    /// <summary>
    /// つながっている島の情報
    /// </summary>
    public List<StageIslandDataList> ConnectIsland;

    /// <summary>
    /// アイテムのデータのリスト
    /// </summary>
    public List<StageIslandData> item_data_list;

    /// <summary>
    /// ゴールの場所
    /// </summary>
    [SerializeField]
    public StageIslandData GoalData;
}