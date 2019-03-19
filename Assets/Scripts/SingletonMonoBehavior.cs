///<summary>
/// 概要：シングルトンのMonoBeheivior継承したもの
/// 更新とか起動時に、色々を行えるようにしているものの基底
///
/// Comment:
/// GameObjectとして存在した上で、そこに対して、コンポ―ネントとして、値を保持等を行っていても良いかもしれない。
/// <filename>
/// 
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

public class SingletonMonoBehavior<T> : MonoBehaviour where T :MonoBehaviour
{
    protected static T instance;


    public static T Instance
    {
        get
        {
            //Hieraruchyに対して検索をかける
            if (null == instance)
            {
                instance = FindObjectHaveComponent();
            }

            //それでもなければ、生成してそれに対してつける
            if(null == instance)
            {
                GameObject _obj = new GameObject(typeof(T).Name + "SingletonMonoBehebiorSystem");
                instance = _obj.AddComponent<T>();
            }
            return instance;
        }
    }

    /// <summary>
    /// インスタンスを明示的に作成
    /// </summary>
    public static T CreateInstance()
    {
        if (null == instance)
        {
            instance = FindObjectHaveComponent();
        }


        //それでもなければ、生成してそれに対してつける
        if (null == instance)
        {
            GameObject _obj = new GameObject(typeof(T).Name + "SingletonMonoBehebiorSystem");
            instance = _obj.AddComponent<T>();
        }
        return instance;
    }

    
    /// <summary>
    /// ついているオブジェクトを見つける。処理は重めなので、頻繁に使わない事
    /// </summary>
    /// <returns></returns>
    private static T FindObjectHaveComponent()
    {
        return FindObjectOfType<T>();
    }

    /// <summary>
    /// インスタンスが存在するか？の確認。
    /// 存在すればtrue
    /// </summary>
    public static bool ExistInstance
    {
        get { return null != instance; }
    }
}
