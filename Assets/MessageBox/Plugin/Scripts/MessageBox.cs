using UnityEngine;
using System;
using System.Collections.Generic;
using CorruptedSmileStudio.MessageBox;
/// <summary>
/// The MessageBox.
/// </summary>
public class MessageBox : MonoBehaviour
{
    /// <summary>
    /// The size of the message box window
    /// </summary>
    public Rect messageBoxRect = new Rect(0, 0, 350, 200);
    /// <summary>
    /// The list of message box items.
    /// </summary>
    private static List<MessageItem> items = new List<MessageItem>();
    /// <summary>
    /// The MessageBox instance
    /// </summary>
    private static MessageBox i;
    /// <summary>
    /// The texture icon for errors
    /// </summary>
    public Texture error;
    /// <summary>
    /// The texture icon for warnings
    /// </summary>
    public Texture warning;
    /// <summary>
    /// The texture icon for information
    /// </summary>
    public Texture info;
    /// <summary>
    /// Doesn't destroy the gameObject between scenes.
    /// </summary>
    public bool dontDestroy = true;
    /// <summary>
    /// Available to better match the MessageBox appearance to your game/app.
    /// </summary>
    public GUISkin skin;

    void Awake()
    {
        if (i == null)
        {
            i = this;
            if (dontDestroy)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        if (items.Count > 0)
        {
            if (skin != null)
            {
                GUI.skin = skin;
            }
            messageBoxRect.x = (Screen.width / 2.0f) - (messageBoxRect.width / 2);
            messageBoxRect.y = 200;
            messageBoxRect = GUI.Window(0, messageBoxRect, Display, items[0].caption);
        }
    }
    /// <summary>
    /// The message box window
    /// </summary>
    /// <param name="id">The Window ID</param>
    private void Display(int id)
    {
        try
        {
            GUI.Label(new Rect(5, 20, messageBoxRect.width - 20, messageBoxRect.height - 50), items[0].message);
            DisplayButtons(items[0]);
        }
        catch (ArgumentOutOfRangeException) { }
    }
    /// <summary>
    /// Displays all the buttons
    /// </summary>
    /// <param name="item">The item to display</param>
    private void DisplayButtons(MessageItem item)
    {
        switch (item.buttons)
        {
            case MessageBoxButtons.AbortRetryIgnore:
                GUI.SetNextControlName("Button1");
                Button(new Rect(5, messageBoxRect.height - 30, 50, 25), "Abort", DialogResult.Abort);
                GUI.SetNextControlName("Button2");
                Button(new Rect(60, messageBoxRect.height - 30, 50, 25), "Retry", DialogResult.Retry);
                GUI.SetNextControlName("Button3");
                Button(new Rect(115, messageBoxRect.height - 30, 55, 25), "Ignore", DialogResult.Ignore);
                break;
            case MessageBoxButtons.RetryCancel:
                GUI.SetNextControlName("Button1");
                Button(new Rect(5, messageBoxRect.height - 30, 50, 25), "Retry", DialogResult.Retry);
                GUI.SetNextControlName("Button2");
                Button(new Rect(60, messageBoxRect.height - 30, 55, 25), "Cancel", DialogResult.Cancel);
                break;
            case MessageBoxButtons.YesNoCancel:
                GUI.SetNextControlName("Button1");
                Button(new Rect(5, messageBoxRect.height - 30, 50, 25), "Yes", DialogResult.Yes);
                GUI.SetNextControlName("Button2");
                Button(new Rect(60, messageBoxRect.height - 30, 50, 25), "No", DialogResult.No);
                GUI.SetNextControlName("Button3");
                Button(new Rect(115, messageBoxRect.height - 30, 55, 25), "Cancel", DialogResult.Cancel);
                break;
            case MessageBoxButtons.YesNo:
                GUI.SetNextControlName("Button1");
                Button(new Rect(5, messageBoxRect.height - 30, 50, 25), "Yes", DialogResult.Yes);
                GUI.SetNextControlName("Button2");
                Button(new Rect(60, messageBoxRect.height - 30, 50, 25), "No", DialogResult.No);
                break;
            case MessageBoxButtons.OKCancel:
                GUI.SetNextControlName("Button1");
                Button(new Rect(5, messageBoxRect.height - 30, 50, 25), "Ok", DialogResult.Ok);
                GUI.SetNextControlName("Button2");
                Button(new Rect(60, messageBoxRect.height - 30, 55, 25), "Cancel", DialogResult.Cancel);
                break;
            case MessageBoxButtons.OK:
                GUI.SetNextControlName("Button1");
                Button(new Rect(messageBoxRect.width - 55, messageBoxRect.height - 30, 50, 25), "Ok", DialogResult.Ok);
                break;
            default:
                GUI.SetNextControlName("Button1");
                Button(new Rect(5, messageBoxRect.height - 30, 50, 25), "Close", DialogResult.None);
                break;
        }
        GUI.FocusControl(item.defaultButton.ToString());
    }
    /// <summary>
    /// Displays a button
    /// </summary>
    /// <param name="place">The location of the button</param>
    /// <param name="caption">The button caption</param>
    /// <param name="result">The result of the button press.</param>
    private void Button(Rect place, string caption, DialogResult result)
    {
        if (GUI.Button(place, caption))
        {
            if (items[0].callback != null)
                items[0].callback(result);
            items.RemoveAt(0);
        }
        else if (Input.GetKeyDown("space") || Input.GetKeyDown("backspace") || Input.GetKeyDown("escape"))
        {
            items.RemoveAt(0);
        }
    }
    /// <summary>
    /// Shows a message box
    /// </summary>
    /// <param name="callback">The method to call once the user has taken a action.</param>
    /// <param name="message">The text label of the message box</param>
    public static void Show(MessageCallback callback, string message)
    {
        Show(callback, message, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
    }
    /// <summary>
    /// Shows a message box
    /// </summary>
    /// <param name="callback">The method to call once the user has taken a action.</param>
    /// <param name="message">The text label of the message box</param>
    /// <param name="caption">The caption of the window</param>
    public static void Show(MessageCallback callback, string message, string caption)
    {
        Show(callback, message, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
    }
    /// <summary>
    /// Shows a message box
    /// </summary>
    /// <param name="callback">The method to call once the user has taken a action.</param>
    /// <param name="message">The text label of the message box</param>
    /// <param name="caption">The caption of the window</param>
    /// <param name="buttons">The buttons to display on the message box</param>
    public static void Show(MessageCallback callback, string message, string caption, MessageBoxButtons buttons)
    {
        Show(callback, message, caption, buttons, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
    }
    /// <summary>
    /// Shows a message box
    /// </summary>
    /// <param name="callback">The method to call once the user has taken a action.</param>
    /// <param name="message">The text label of the message box</param>
    /// <param name="caption">The caption of the window</param>
    /// <param name="buttons">The buttons to display on the message box</param>
    /// <param name="icon">The icon to display on the message box.</param>
    public static void Show(MessageCallback callback, string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
        Show(callback, message, caption, buttons, icon, MessageBoxDefaultButton.Button1);
    }
    /// <summary>
    /// Shows a message box
    /// </summary>
    /// <param name="callback">The method to call once the user has taken a action.</param>
    /// <param name="message">The text label of the message box</param>
    /// <param name="caption">The caption of the window</param>
    /// <param name="buttons">The buttons to display on the message box</param>
    /// <param name="icon">The icon to display on the message box.</param>
    /// <param name="defaultButton">The default button to be selected.</param>
    public static void Show(MessageCallback callback, string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
    {
        MessageItem item = new MessageItem();
        item.caption = caption;
        item.buttons = buttons;
        item.defaultButton = defaultButton;
        item.callback = callback;
        item.message.text = message;

        switch (icon)
        {
            case MessageBoxIcon.Error:
            case MessageBoxIcon.Stop:
            case MessageBoxIcon.Hand:
                item.message.image = i.error;
                break;
            case MessageBoxIcon.Exclamation:
            case MessageBoxIcon.Warning:
                item.message.image = i.warning;
                break;
            case MessageBoxIcon.Information:
            case MessageBoxIcon.Asterisk:
                item.message.image = i.info;
                break;
            default:
                break;
        }

        items.Add(item);
    }
}