///<summary>
/// 概要：このクラスは、Managerに対して、この場所はいく事ができますか？などを問い合わせて、
/// それに合わせた、動きで、巡回を行います。
/// 基本的には、このキャラクターに関しては、すでにつながっている部分の島を巡回する事になりますが、
/// 
/// <filename>
/// AroundCharacter.cs
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

public class AroundCharacter : MonoBehaviour 
{
    /// <summary>
    /// 動いていいか？
    /// </summary>
    private bool move_ok;

    /// <summary>
    /// 位置情報インデックス
    /// </summary>
    [SerializeField]
    private int x = 0, y = 0;

    /// <summary>
    /// 次に向かうべき土地
    /// </summary>
    private int next_x = 0, next_y = 0;

    /// <summary>
    /// 島をめぐる際のindex 渡ったさいなどには取得が必要
    /// </summary>
    [SerializeField]
    private int island_index = 0;

    /// <summary>
    /// 向かう方向
    /// true = 増えていく　false 減っていく。
    /// </summary>
    [SerializeField]
    private bool dirction_move_flg = true;

    /// <summary>
    /// ステージデータ部分
    /// </summary>
    private StageManager stage_manager;

    List<StageIslandData> now_island;


    /// <summary>
    /// ステージ上のインデックス。
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_y"></param>
    public void Init(int _x,int _y, StageManager _stage_manager)
    {
        x = _x;
        y = _y;
        stage_manager = _stage_manager;
        gameObject.transform.position = new Vector3(x * 2f, 1f, y * 2f);
        now_island = stage_manager.GetPlayerPosIsland(x, y);
        if(null == now_island)
        {
            Debug.LogError("not getting now_island");
            return;
        }

        island_index = now_island.FindIndex((x) => x.x_index == this.x && x.y_index == this.y);
        dirction_move_flg = true;
        next_position_setting();
        move_ok = true;
        Debug.LogFormat("direction :{0},move:{1}", dirction_move_flg, move_ok);
    }

	// Use this for initialization
	void Start () 
	{
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(false == move_ok)
        {
            return;
        }

		if(Input.GetKeyDown(KeyCode.P))
        {
            transform_positon();
            next_position_setting();
        }
	}


    /// <summary>
    /// 位置を移動する　デバック
    /// </summary>
    private void transform_positon()
    {
        gameObject.transform.position = new Vector3(next_x * 2f, 1f, next_y * 2f);
    }

    /// <summary>
    /// 島の次のIndexの場所に対して移動する。
    /// </summary>
    private void next_position_setting()
    {
        if(dirction_move_flg)
        {
            
            if (now_island.Count <= island_index + 1)
            {
                dirction_move_flg = !dirction_move_flg;
            }
            else
            {
                island_index++;
                var _data = now_island[island_index];
                next_x = _data.x_index;
                next_y = _data.y_index;
            }
        }
        else
        {    
            if(0 > island_index - 1)
            {
                dirction_move_flg = !dirction_move_flg;
            }
            else
            {
                island_index--;
                var _data = now_island[island_index];
                next_x = _data.x_index;
                next_y = _data.y_index;
            }
        }

       
    }
}
