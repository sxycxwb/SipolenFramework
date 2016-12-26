/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 15:31:11
 ******************************************************************************/

using System;

namespace RDIFramework.Utilities
{
    public class MockSender : IRichMessageEmailSender {
        
        public virtual void Send(String from, String to, String subject, String messageText) {

        }

        public virtual void Send(Message message) {

        }

        public virtual void Send(Message[] messages) {

        }
    }
}