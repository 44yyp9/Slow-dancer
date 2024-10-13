using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateCustomScript
{
    private const string MenuItemPath = "Assets/Create/Custom C# Script";
    private const int MenuItemPriority = 80;
    private const string DefaultScriptName = "NewScript.cs";
    private const string TemplatePath = "Assets/Script/Editor/CustomScriptTemplates/CustomScriptTemplate.txt";
    private const string ScriptsFolderPath = "Assets/Scripts/";

    [MenuItem(MenuItemPath, false, MenuItemPriority)]
    public static void CreateNewScript()
    {
        string selectedPath = GetSelectedPath();
        string filePath = ShowSaveFilePanel(selectedPath);

        if (string.IsNullOrEmpty(filePath))
        {
            // User cancelled the save operation
            return;
        }

        string scriptName = Path.GetFileNameWithoutExtension(filePath);
        string namespaceName = GetNamespaceFromPath(selectedPath);

        CreateScriptFile(filePath, scriptName, namespaceName);
        AssetDatabase.Refresh();
    }

    private static string GetSelectedPath()
    {
        string path = "Assets";
        foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }

    private static string ShowSaveFilePanel(string initialPath)
    {
        return EditorUtility.SaveFilePanelInProject(
            "Save Script",
            DefaultScriptName,
            "cs",
            "Please enter a file name to save the script to.",
            initialPath
        );
    }

    private static string GetNamespaceFromPath(string path)
    {
        if (!path.Contains(ScriptsFolderPath))
        {
            return string.Empty;
        }

        int startIndex = path.IndexOf(ScriptsFolderPath) + ScriptsFolderPath.Length;
        return path.Substring(startIndex).Replace("/", ".");
    }

    private static void CreateScriptFile(string filePath, string scriptName, string namespaceName)
    {
        string templateContent = File.ReadAllText(TemplatePath);
        templateContent = templateContent.Replace("#SCRIPTNAME#", scriptName);

        File.WriteAllText(filePath, templateContent);
    }
}