using UnityEngine;
using System.Collections;
using CorruptedSmileStudio.MessageBox;

/// <summary>
/// Showing example usage of the system.
/// </summary>
public class ExampleScript : MonoBehaviour
{
    void Start()
    {
        MessageBox.Show(null, "More buttons to clicky", "Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
    }

    void OnGUI()
    {
        if (GUILayout.Button("Show Info Dialog"))
        {
            MessageBox.Show(null, "This is a information dialog", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        if (GUILayout.Button("Show Warning Dialog"))
        {
            MessageBox.Show(null, "This is a warning dialog", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        if (GUILayout.Button("Show Error Dialog"))
        {
            MessageBox.Show(null, "This is a error dialog", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}