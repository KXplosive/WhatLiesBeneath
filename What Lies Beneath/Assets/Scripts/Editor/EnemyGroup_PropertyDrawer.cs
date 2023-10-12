using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(EnemyGroup))]
public class EnemyGroup_PropertyDrawer : PropertyDrawer
{
    

    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var popup = new UnityEngine.UIElements.PopupWindow();
        popup.Add(new PropertyField(property.FindPropertyRelative("GroupName"), "Nombre"));
        popup.Add(new PropertyField(property.FindPropertyRelative("Type"), "Tipo"));
        popup.Add(new PropertyField(property.FindPropertyRelative("enemies"), "Enemigos"));

        container.Add(popup);

        return container;
    }
}
