///<summary>
/// 概要：サウンドをどうにかするためのもの
/// 音源を入れて、数値で設定する。
/// 場合によってはEnum－＞intで制御を行う
///
/// <filename>
/// SoundController.cs
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

public class SoundController : SingletonMonoBehavior<SoundController> 
{

    [SerializeField]
    private List<AudioClip> bgm = new List<AudioClip>();


    [SerializeField]
    private List<AudioClip> se = new List<AudioClip>();


    /// <summary>
    /// 鳴らすために必要なもの
    /// </summary>
    [SerializeField]
    private AudioSource bgm_audio = null;

    [SerializeField]
    private AudioSource se_audio = null;

    /// <summary>
    /// 現在再生中のBGM
    /// </summary>
    private AudioClip now_playing_bgm = null;

    /// <summary>
    /// Bgmを鳴らす
    /// </summary>
    /// <param name="_no"></param>
    public void PlayBgm(int _no)
    {
        if(bgm.Count >_no)
        {
            if(null == now_playing_bgm)
            {
                now_playing_bgm = bgm[_no];
                bgm_audio.clip = now_playing_bgm;
                bgm_audio.Play();
            }
            else
            {
                bgm_audio.Stop();
                now_playing_bgm = bgm[_no];
                bgm_audio.clip = now_playing_bgm;
                bgm_audio.Play();
            }
        }
    }

    /// <summary>
    /// SEを鳴らす
    /// </summary>
    /// <param name="_no"></param>
    public void PlaySe(int _no)
    {
        se_audio.clip = se[_no];
        se_audio.Play();

    }

}
