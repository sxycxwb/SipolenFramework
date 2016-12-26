/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  ��    �ߣ� EricHu
 *  ����ʱ�䣺 2012-6-26 15:30:54
 ******************************************************************************/
namespace RDIFramework.Utilities
{
    public interface IRichMessageEmailSender : IEmailSender {
        /// <summary>
        /// Sends a message. 
        /// </summary>
        /// <param name="message">Message instance</param>
        void Send(Message message);

        /// <summary>
        /// Sends multiple messages. 
        /// </summary>
        /// <param name="messages">Array of messages</param>
        void Send(Message[] messages);
    }
}