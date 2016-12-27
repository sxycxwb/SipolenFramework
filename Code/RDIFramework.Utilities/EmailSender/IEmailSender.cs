/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-6-26 15:30:51
 ******************************************************************************/
using System;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// Abstracts an approach to send e-mails
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends a message. 
        /// </summary>
        /// <param name="from">From field</param>
        /// <param name="to">To field</param>
        /// <param name="subject">e-mail's subject</param>
        /// <param name="messageText">message's body</param>
        void Send(String from, String to, String subject, String messageText);
    }
}