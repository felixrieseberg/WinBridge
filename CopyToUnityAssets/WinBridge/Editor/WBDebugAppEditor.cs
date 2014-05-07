using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using WinControls;
using System;

[CustomEditor(typeof(WindowsStoreProxy))]

public class WBDebugAppEditor : Editor
{

    private List<bool> _debugProductsFoldoutBools = new List<bool>();
    private bool debugProductsFoldout = true;

    public override void OnInspectorGUI()
    {
        WindowsStoreProxy mbTarget = (WindowsStoreProxy)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("App Settings", EditorStyles.boldLabel);
        mbTarget.dName = EditorGUILayout.TextField("Name", mbTarget.dName);
        mbTarget.description = EditorGUILayout.TextField("Description", mbTarget.description);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Commerce Settings", EditorStyles.boldLabel);
        mbTarget.price = EditorGUILayout.FloatField("Price", (float)mbTarget.price);
        mbTarget.currencySymbol = EditorGUILayout.TextField("Currency Symbol", mbTarget.currencySymbol);
        mbTarget.currencyCode = EditorGUILayout.TextField("Currency Code", mbTarget.currencyCode);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Store Information", EditorStyles.boldLabel);
        mbTarget.appId = EditorGUILayout.TextField("Store App ID", mbTarget.appId);
        mbTarget.linkUri = EditorGUILayout.TextField("Store App URI", mbTarget.linkUri);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Trial Settings", EditorStyles.boldLabel);
        mbTarget.isTrial = EditorGUILayout.ToggleLeft("Trial version active", mbTarget.isTrial);
        mbTarget.dIsActive = EditorGUILayout.ToggleLeft("License valid", mbTarget.dIsActive);
        if (mbTarget.isTrial == true)
        {
            EditorGUILayout.HelpBox("In-App-Purchases won't work if the app is set to be in trial mode!", MessageType.Warning);
        }
        if (mbTarget.dIsActive == false)
        {
            EditorGUILayout.HelpBox("You set the license to 'invalid', which is only useful if you have code reacting to this state.", MessageType.Warning);
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Products Available in Debug", EditorStyles.boldLabel);
        if (mbTarget.debugProducts.ToArray().Length > 0)
        {
            EditorGUILayout.BeginVertical();
            int i = 0;
            foreach (Store.DebugProduct product in mbTarget.debugProducts)
            {
                _debugProductsFoldoutBools[i] = EditorGUILayout.Foldout(_debugProductsFoldoutBools[i], product.Name);
                if (_debugProductsFoldoutBools[i])
                {
                    product.Name = EditorGUILayout.TextField("Name", product.Name);
                    product.ProductId = EditorGUILayout.TextField("ID", product.ProductId);
                    EditorGUILayout.Space();
                    product.IsActive = EditorGUILayout.ToggleLeft("Active", Convert.ToBoolean(product.IsActive));
                    EditorGUILayout.Space();
                    product.CurrencySymbol = EditorGUILayout.TextField("Currency Symbol", product.CurrencySymbol);
                    product.CurrencyCode = EditorGUILayout.TextField("Currency Code", product.CurrencyCode);
                }
                i++;
            }
            EditorGUILayout.EndVertical();
        }
        else
        {

        }


        if (GUILayout.Button("Add Debug Product"))
        {
            _debugProductsFoldoutBools.Add(true);
            mbTarget.AddDebugProduct("", "", 1.99, "$", "USD", false);
        }
    }

}
