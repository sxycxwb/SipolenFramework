/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  ��    �ߣ� XuWangBin
 *  ����ʱ�䣺 2012-6-26 15:31:11
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