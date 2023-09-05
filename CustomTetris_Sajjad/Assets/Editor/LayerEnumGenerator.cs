using UnityEditor;
using UnityEngine;
using System.IO;

public class LayerEnumGenerator : Editor
{
    [MenuItem("Tools/EnumGenerator/Generate Layer Enums")]
    public static void GenerateLayerEnums()
    {
        string scriptText = "public enum UnityLayers\n{\n";

        for (int i = 0; i < 32; i++)
        {
            string layerName = LayerMask.LayerToName(i);
            if (!string.IsNullOrEmpty(layerName))
            {
                //scriptText += $"    {layerName} = {i},\n";
                scriptText += $"    {string.Join("_", layerName.Split(' '))} = {i},\n";
            }
        }

        scriptText += "}";

        // Define where to save the script
        string outputPath = Application.dataPath + "/Scripts/Enums/" + ConstantsManager.FileNames.UnityLayers + ".cs"; 

        // Write the script to the specified path
        File.WriteAllText(outputPath, scriptText);

        // Refresh the Asset Database
        AssetDatabase.Refresh();
    }

}
