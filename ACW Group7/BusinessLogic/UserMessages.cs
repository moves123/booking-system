namespace BusinessLogic
{
    public class UserMessage
    {
        #region Member Variables
        private string m_messageText;
        private string m_caption;
        //private MessageBoxButtons m_buttons; // what will this be in WPG????
        #endregion

        #region Constructor
        //pIcon wasnt working so I have disabled it by commenting it out and added warning triangle to all messages to revisit if time
        private UserMessage(string pMessageText, int pCaption, int pButtons)//, int pIcon)
        {
            m_messageText = pMessageText;
            switch (pCaption)
            {
                case 1:
                    m_caption = "Important Note...";
                    break;
                case 2:
                    m_caption = "Error Detected...";
                    break;
                case 3:
                    m_caption = "Form Closing...";
                    break;
            }
            switch (pButtons)
            {
                //case 1:
                //    m_buttons = MessageBoxButtons.OK;
                //    return;
                //case 2:
                //    m_buttons = MessageBoxButtons.YesNo;
                //    return;
                //case 3:
                //    m_buttons = MessageBoxButtons.YesNoCancel;
                //    return;
            }
            //switch (pIcon)
            //{
            //    case 1:
            //        m_icon = MessageBoxIcon.Information;
            //        return;
            //    case 2:
            //        m_icon = MessageBoxIcon.Exclamation;
            //        return;
            //    case 3:
            //        m_icon = MessageBoxIcon.Error;
            //        return;
            //}
        }
        #endregion

        #region Method
        public static void MessageToUser(string pMessageText, int pCaption, int pButtons) //int pIcon)
        {

            //UserMessage message = new UserMessage(pMessageText, pCaption, pButtons);/*pIcon);*/
            //MessageBox.Show(message.m_messageText, message.m_caption, message.m_buttons, MessageBoxIcon.Exclamation);
            //// message.m_icon);

            return;
        }
        #endregion
    }
}
