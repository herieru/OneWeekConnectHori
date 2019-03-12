///<summary>
/// 概要： フィールドのアセットを作成するためのものです
///
/// <filename>
/// FieldCreater.cs
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
using UnityEditor;

public class FieldCreater : EditorWindow 
{

    [MenuItem("Creater/MapCreater")]
    private static void open_tool()
    {
        GetWindow<FieldCreater>();
    }

    private int map_no = 0;

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField("マップ番号");
            map_no = EditorGUILayout.IntField(map_no);
        }
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("これで作成する"))
        {
            CreateAsset();
        }
    }

    /// <summary>
    ///　フィールドのアセットを作成する。
    /// </summary>
    public void CreateAsset()
    {
        ScriptableObject _create_object = ScriptableObject.CreateInstance<StageData>();
        string _path = AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/StageData/MapData"+ map_no + ".asset");
        // 該当パスにオブジェクトアセットを生成
        AssetDatabase.CreateAsset(_create_object, _path);
        // 未保存のアセットをアセットデータベースに保存
        AssetDatabase.SaveAssets();
    }






}
