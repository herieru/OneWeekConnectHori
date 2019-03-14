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

}
