using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawner_Inspector : Editor
{

    string groupSelected;
    public VisualTreeAsset m_InspectorXML;

    public override VisualElement CreateInspectorGUI()
    {
        VisualElement myInspector = new VisualElement();
        m_InspectorXML.CloneTree(myInspector);

        return myInspector;
    }
}
