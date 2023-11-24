namespace CorruptedSmileStudio.MessageBox
{
    /// <summary>
    /// Represents a MessageBox.
    /// </summary>
    internal class MessageItem
    {
        /// <summary>
        /// The callback associated with the MessageBox
        /// </summary>
        public MessageCallback callback;
        /// <summary>
        /// The caption of the Message Box
        /// </summary>
        public string caption;
        /// <summary>
        /// The message and Icon of the MessageBox
        /// </summary>
        public UnityEngine.GUIContent message;
        /// <summary>
        /// The buttons to display
        /// </summary>
        public MessageBoxButtons buttons;
        /// <summary>
        /// The default button to be selected.
        /// </summary>
        public MessageBoxDefaultButton defaultButton;
        /// <summary>
        ///  Creates a new Message Item with all the fields filled.
        /// </summary>
        /// <param name="call">The callback</param>
        /// <param name="content">The message</param>
        /// <param name="cap">The caption</param>
        /// <param name="btns">The buttons</param>
        /// <param name="defaultBtn">The default buttons</param>
        public MessageItem(MessageCallback call, UnityEngine.GUIContent content, string cap, MessageBoxButtons btns, MessageBoxDefaultButton defaultBtn)
        {
            message = content;
            caption = cap;
            buttons = btns;
            defaultButton = defaultBtn;
        }
        /// <summary>
        /// Creates an empty Message Item
        /// </summary>
        public MessageItem()
        {
            message = new UnityEngine.GUIContent();
            caption = "";
            buttons = MessageBoxButtons.OK;
            defaultButton = MessageBoxDefaultButton.Button1;
        }
    }
    /// <summary>
    /// This method is called on a button click from the message box.
    /// </summary>
    /// <param name="result">The result of the button click.</param>
    public delegate void MessageCallback(DialogResult result);
}