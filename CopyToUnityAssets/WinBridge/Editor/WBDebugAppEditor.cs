using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using WinControls;
using System;

[CustomEditor(typeof(WindowsStoreProxy))]

public class WBDebugAppEditor : Editor
{

    [SerializeField]
    private static List<bool> _debugProductsFoldoutBools = new List<bool>();

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
        if (mbTarget.debugProducts.Count > 0)
        {
            EditorGUILayout.BeginVertical();
            int i = 0;
            foreach (WindowsStoreProxy.SerializableDebugProduct product in mbTarget.debugProducts)
            {
                // Debug.Log("Count DebugProducts: " + mbTarget.debugProducts.Count + " i: " + i + " Count Bools: " + _debugProductsFoldoutBools.Count);
                if (i >= _debugProductsFoldoutBools.Count) { _debugProductsFoldoutBools.Add(true); };                
                _debugProductsFoldoutBools[i] = EditorGUILayout.Foldout(_debugProductsFoldoutBools[i], product.productName);
                if (_debugProductsFoldoutBools[i])
                {
                    product.productName = EditorGUILayout.TextField("Name", product.productName);
                    product.productId = EditorGUILayout.TextField("ID", product.productId);
                    EditorGUILayout.Space();
                    product.disActive = EditorGUILayout.ToggleLeft("Active", Convert.ToBoolean(product.disActive));
                    EditorGUILayout.Space();
                    product.price = EditorGUILayout.FloatField("Price", (float)product.price);
                    product.currencySymbol = EditorGUILayout.TextField("Currency Symbol", product.currencySymbol);
                    product.currencyCode = EditorGUILayout.TextField("Currency Code", product.currencyCode);
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
        EditorGUILayout.Space();
        if (GUILayout.Button("Delete Debug Products"))
        {
            _debugProductsFoldoutBools.Clear();
            mbTarget.debugProducts.Clear();
        }
    }

}
