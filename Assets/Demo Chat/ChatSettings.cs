﻿using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ChatSettings : ScriptableObject
{
    public string AppId = "be44346f-4545-4696-b842-8c4770a605f8";
    [HideInInspector]
    public bool WizardDone;


    private static ChatSettings instance;
    public static ChatSettings Instance
    {
        get
        {
            if (instance != null) return instance;
            instance = Load();
            return instance;
        }
    }

    public static ChatSettings Load()
    {
        ChatSettings settings = (ChatSettings)Resources.Load("ChatSettingsFile", typeof (ChatSettings));
        if (settings != null)
        {
            return settings;
        }
        else
        {
            return Create();
        }
    }
     

    private static ChatSettings Create()
    {
        ChatSettings settings = (ChatSettings)ScriptableObject.CreateInstance("ChatSettings");
#if UNITY_EDITOR
        if (!Directory.Exists("Assets/Resources"))
        {
            AssetDatabase.CreateFolder("Assets", "Resources");
            AssetDatabase.ImportAsset("Assets/Resources");
        }

        AssetDatabase.CreateAsset(settings, "Assets/Resources/ChatSettingsFile.asset");
        EditorUtility.SetDirty(settings);

        settings = (ChatSettings)Resources.Load("ChatSettingsFile", typeof(ChatSettings));
#endif
        return settings;
    }
}