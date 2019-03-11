///<summary>
/// 概要：このクラスは、Cubeを操作するためのものです、
/// Castを受け取ると、Managerに対して通知をしたりしなかったりします。
/// 
/// また、その際に選択されているか、つながっているかなどの確認を行っていきます。
/// 
/// ここが持つ情報としては、あくまでもここのクラス個人で扱えるものだけを扱います。
///
/// <filename>
/// CubeController.cs
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
using UnityEngine.EventSystems;

/// <summary>
/// Cubeからの通知を行う際のもの
/// </summary>
public class CubeNotice
{
    public int x_index { get; set; }
    public int y_index { get; set; }
}


public class CubeController : MonoBehaviour ,IPointerDownHandler
{

    /// <summary>
    /// CubeのState
    /// </summary>
    private CubeState cube_state = CubeState.Normal;

    /// <summary>
    /// それぞれの状態時に、適用するマテリアル。
    /// </summary>
    [SerializeField]
    private Material mat_normal, mat_select, mat_confilm;

    /// <summary>
    /// 自身のマテリアル情報
    /// </summary>
    private Material my_material;

    /// <summary>
    /// 辺の場所を示すためのものインデックス番号
    /// </summary>
    private int x_adge_no = 0;
    private int y_adge_no = 0;

    private Subject<CubeNotice> select_notice = new Subject<CubeNotice>();

    /// <summary>
    /// 選択を行った際に、通知を行うもの
    /// </summary>
    public Subject<CubeNotice> SelectNotice
    {
        get
        {
            return select_notice;
        }
    }

  

    public void SettingPosition(int _adge_x,int _adge_y)
    {
        x_adge_no = _adge_x;
        y_adge_no = _adge_y;

        //TODO:ここは、辺に沿った数分移動をさせる
    }

    /// <summary>
    /// 状態を変更させる。
    /// </summary>
    /// <param name="_set_state"></param>
    public void SettingState(CubeState _set_state)
    {
        cube_state = _set_state;
    }

    /// <summary>
    /// 状態の変化によって、マテリアルを変更する
    /// </summary>
    /// <param name="_state">今のステートを引数として渡す。</param>
    private void change_material(CubeState _state)
    {
        switch (_state)
        {
            case CubeState.Normal:
                my_material = mat_normal;
                break;
            case CubeState.Select:
                my_material = mat_select;
                break;
            case CubeState.Confilm:
                my_material = mat_confilm;
                break;
        }
    }


    #region monobehevior
    

    // Use this for initialization
    void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
    #endregion monobehevior


    /// <summary>
    /// クリックされた時の反応
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(cube_state == CubeState.Confilm)
        {
            //TODO:選択失敗みたいな音を鳴らす
            return;
        }
        //TODO:選択した音を鳴らす

        CubeNotice _notice = new CubeNotice()
        {
            x_index = x_adge_no,
            y_index = y_adge_no,
        };

        SelectNotice.OnNext(_notice);

        if(cube_state == CubeState.Normal)
        {
            cube_state = CubeState.Select;
        }
        else if(cube_state == CubeState.Select)
        {
            cube_state = CubeState.Normal;
        }

        change_material(cube_state);
    }

}
