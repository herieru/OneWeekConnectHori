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
    /// <summary>
    /// 1辺の最大の取得する場所
    /// </summary>
    private const int MAX_ADGE_NUM = 7;

    /// <summary>
    /// 管理を行うためのモノ　横ー＞縦指定
    /// </summary>
    private CubeController[,] cube_controllers;

	// Use this for initialization
	void Start () 
	{
        cube_controllers = new CubeController[MAX_ADGE_NUM, MAX_ADGE_NUM];

        for(int _x = 0;_x< MAX_ADGE_NUM;_x++)
        {
            for(int _y = 0;_y < MAX_ADGE_NUM;_y++)
            {
                GameObject _cube = new GameObject(string.Format("Cube_{0}_{1}",_x,_y));
                cube_controllers[_x,_y] = _cube.AddComponent<CubeController>();
                cube_controllers[_x, _y].SettingPosition(_x, _y);
            }
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
