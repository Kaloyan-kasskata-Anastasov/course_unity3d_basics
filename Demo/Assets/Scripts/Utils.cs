using UnityEditor;
using UnityEngine;

public static class Utils
{
    [MenuItem("Utils/Toggle Activation of Selected Objects")]
    private static void FindAndRemoveMissingInSelected()
    {
        GameObject[] selected = Selection.gameObjects;
        for (int i = 0; i < selected.Length; i++)
        {
            bool active = !selected[i].activeSelf;
            selected[i].SetActive(active);
        }
    }

    // To create a hotkey you can use the following special characters:
    // % (ctrl on Windows, cmd on macOS), # (shift), & (alt). If no special modifier key combinations are required the key can be given after an underscore.
    // For example to create a menu with hotkey shift-alt-g use "MyMenu/Do Something #&g". To create a menu with hotkey g and no key modifiers pressed use "MyMenu/Do Something _g".
    // Some special keyboard keys are supported as hotkeys, for example "#LEFT" would map to shift-left.
    // The keys supported like this are: LEFT, RIGHT, UP, DOWN, F1..F12, HOME, END, PGUP, PGDN.

    [MenuItem("Utils/GameObject/Create Empty %e")]
    private static void CreateEmpty()
    {
        GameObject[] selected = Selection.gameObjects;
        for (int i = 0; i < selected.Length; i++)
        {
            GameObject go = new GameObject();
            go.transform.parent = selected[i].transform;
            EditorGUIUtility.PingObject(go);
        }
    }
}
