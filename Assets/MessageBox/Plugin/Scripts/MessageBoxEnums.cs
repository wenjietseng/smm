namespace CorruptedSmileStudio.MessageBox
{
    /// <summary>
    /// The return value of a dialog box.
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        /// Nothing is returned from the message box,
        /// this means the dialog continues running.
        /// </summary>
        None,
        /// <summary>
        /// Return Value: OK
        /// </summary>
        Ok,
        /// <summary>
        /// Return Value: Cancel
        /// </summary>
        Cancel,
        /// <summary>
        /// Return Value: Abort
        /// </summary>
        Abort,
        /// <summary>
        /// Return Value: Retry
        /// </summary>
        Retry,
        /// <summary>
        /// Return Value: Ignore
        /// </summary>
        Ignore,
        /// <summary>
        /// Return Value: Yes
        /// </summary>
        Yes,
        /// <summary>
        /// Return Value: No
        /// </summary>
        No
    }
    /// <summary>
    /// Defines which buttons to display on a MessageBox
    /// </summary>
    public enum MessageBoxButtons
    {
        /// <summary>
        /// Contains a OK Button.
        /// </summary>
        OK,
        /// <summary>
        /// Contains OK and Cancel buttons.
        /// </summary>
        OKCancel,
        /// <summary>
        /// Contains Abort, Retry and Ignore buttons.
        /// </summary>
        AbortRetryIgnore,
        /// <summary>
        /// Contains Yes, No and Cancel buttons.
        /// </summary>
        YesNoCancel,
        /// <summary>
        /// Contains Yes and No buttons.
        /// </summary>
        YesNo,
        /// <summary>
        /// Contains Retry and Cancel buttons.
        /// </summary>
        RetryCancel
    }
    /// <summary>
    /// The icon to display on a message box
    /// </summary>
    public enum MessageBoxIcon
    {
        /// <summary>
        /// Contains no Icon
        /// </summary>
        None,
        /// <summary>
        /// Contains a symbol consisting of a while X in a red circle
        /// </summary>
        Hand,
        /// <summary>
        /// Contains a Exclamation point in a yellow triangle
        /// </summary>
        Exclamation,
        /// <summary>
        /// Contains a lowercase i in a circle
        /// </summary>
        Asterisk,
        /// <summary>
        /// Contains a White X in a red circle
        /// </summary>
        Stop,
        /// <summary>
        /// Contains a white x in a red circle
        /// </summary>
        Error,
        /// <summary>
        /// Contains a exclamation point in a yellow triangle
        /// </summary>
        Warning,
        /// <summary>
        /// Contains a lowercase i in a circle.
        /// </summary>
        Information
    }
    /// <summary>
    /// The default button on the message box.
    /// </summary>
    public enum MessageBoxDefaultButton
    {
        /// <summary>
        /// The first button on the message box
        /// </summary>
        Button1,
        /// <summary>
        /// The second button on the message box
        /// </summary>
        Button2,
        /// <summary>
        /// The third button on the message box
        /// </summary>
        Button3
    }
}