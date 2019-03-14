///<summary>
/// 概要：このクラスは、ステージを管理するためのクラスです。
/// 
///
/// <filename>
/// StageManager.cs
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
using System.Linq;

public class StageManager 
{
    /// <summary>
    /// 1辺の最大の取得する場所
    /// </summary>
    private const int MAX_ADGE_NUM = 7;

    /// <summary>
    /// 管理を行うためのモノ　横ー＞縦指定
    /// </summary>
    private CubeController[,] cube_controllers;

    private GameObject cube_prefab;
    private GameObject coin_prefab;
    private StageData now_stage_data;

    private GameObject player = null;

    /// <summary>
    /// 道をつなぐためのGameObject
    /// </summary>
    private List<GameObject> Cube = new List<GameObject>();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="_root_object">ルートとなるオブジェクト</param>
    /// <param name="_stage_cube_prefab">ステージオブジェクト</param>
    /// <param name="_coin_prefab">コインプレハブ</param>
    public StageManager(GameObject _root_object ,GameObject _stage_cube_prefab,GameObject _coin_prefab)
    {
        
        cube_prefab = _stage_cube_prefab;
        coin_prefab = _coin_prefab;
        cube_controllers = new CubeController[MAX_ADGE_NUM, MAX_ADGE_NUM];
        //色々と作成
        for (int _x = 0; _x < MAX_ADGE_NUM; _x++)
        {
            for (int _y = 0; _y < MAX_ADGE_NUM; _y++)
            {
                GameObject _cube = GameObject.Instantiate(cube_prefab);
                _cube.name = string.Format("Cube_{0}_{1}", _x, _y);
                _cube.transform.parent = _root_object.transform;
                cube_controllers[_x, _y] = _cube.GetComponent<CubeController>();
                cube_controllers[_x, _y].SettingPosition(_x, _y);
            }
        }
    }

    /// <summary>
    /// ステージデータを作成する。
    /// </summary>
    /// <param name="_stage_data"></param>
    public void CreateStageData(StageData _stage_data)
    {
        now_stage_data = _stage_data;
        Reset();
    }

    /// <summary>
    /// リセットを行う
    /// </summary>
    public void Reset()
    {
        stage_infomation_reset();
        setting_island_data();
        setting_coin_data();
        setting_player();
    }

    /// <summary>
    /// チェックしたい位置から、状態の取得を行う
    /// たぶん処理的にはちょっと重い
    /// </summary>
    /// <param name="_check_x"></param>
    /// <param name="_check_y"></param>
    /// <returns></returns>
    public List<StageIslandData>GetPlayerPosIsland(int _check_x,int _check_y)
    {
        foreach(var _list_data in now_stage_data.ConnectIsland)
        {
           if( _list_data.ConnetIsland.Exists((x) => x.x_index == _check_x && x.y_index == _check_y))
            {
                return _list_data.ConnetIsland;
            }
        }

        return null;
    }

    /// <summary>
    /// ステージの情報をリセットする
    /// </summary>
    private void stage_infomation_reset()
    {
        for(int _x = 0; _x < MAX_ADGE_NUM;_x++)
        {
            for (int _y = 0; _y < MAX_ADGE_NUM; _y++)
            {
                cube_controllers[_x, _y].SettingState(CubeState.Normal);
            }
        }
    }

    /// <summary>
    /// 島単位のデータ作成
    /// </summary>
    private void setting_island_data()
    {
        foreach(var _obj in Cube)
        {
            GameObject.Destroy(_obj);
        }
        Cube.Clear();

        var _list = now_stage_data.ConnectIsland;

       

        foreach (var _data_list in _list)
        {
            StageIslandData _prev_data = null;
            StageIslandData _next_data = null;

            foreach(var _data in _data_list.ConnetIsland)
            {
                if(null == _prev_data)
                {
                    _prev_data = _data;
                    continue;
                }
                _next_data = _data;
                create_load_cube(
                    cube_controllers[_prev_data.x_index, _prev_data.y_index].gameObject.transform.position
                    , cube_controllers[_next_data.x_index, _next_data.y_index].gameObject.transform.position
                    , _next_data.x_index - _prev_data.x_index
                    , _next_data.y_index - _prev_data.y_index);

                _prev_data = _next_data;

                cube_controllers[_prev_data.x_index, _prev_data.y_index].SettingState(CubeState.Confilm);
            }   
        }
    }

    /// <summary>
    /// Cubeの配置を行う
    /// </summary>
    /// <param name="_prev_pos">前半の位置</param>
    /// <param name="_next_pos">後半の位置</param>
    /// <param name="_diff_x">差分のX</param>
    /// <param name="_diff_y">差分のY</param>
    private void create_load_cube(Vector3 _prev_pos ,Vector3 _next_pos ,int _diff_x,int _diff_y)
    {
        Vector3 _diff = _next_pos - _prev_pos;
        Vector3 _temp_x = _diff;
        _temp_x.y = _temp_x.z = 0;
        Vector3 _temp_y = _diff;
        _temp_y.y = _temp_y.x = 0;

        //X方向への移動
        for(int _x = 0; _x < _diff_x;_x++)
        {
            GameObject _gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //ここの処理は飛びがない状態での処理
            _gameObject.transform.position = _prev_pos + ((_temp_x / (_diff_x + 1)) * (_x + 1));
            Cube.Add(_gameObject);
        }

        //Z方向への移動
        for (int _y = 0; _y < _diff_y; _y++)
        {
            GameObject _gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //ここの処理は、飛びがない状態での判断
            _gameObject.transform.position = _prev_pos + ((_temp_y / (_diff_y + 1)) * (_y + 1));
            Cube.Add(_gameObject);
        }
    }

    /// <summary>
    /// コインなどの配置
    /// </summary>
    private void setting_coin_data()
    {

    }

    /// <summary>
    /// Cubeが存在しないデータを作成する。
    /// </summary>
    private void setting_non_cube_data()
    {

    }

    /// <summary>
    /// プレイヤーをセットする。
    /// </summary>
    private void setting_player()
    {
        Debug.Log("きてる");
        if(null != player)
        {
            GameObject.Destroy(player);
        }
        player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        var _around_character = player.AddComponent<AroundCharacter>();
        _around_character.Init(now_stage_data.PlayerPos.x_index,now_stage_data.PlayerPos.y_index,this);
    }



}
