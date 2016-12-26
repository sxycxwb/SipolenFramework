/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 15:30:57
 ******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Text;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// Abstracts an e-mail message
    /// </summary>
    public class Message {
        private Format _format = Format.Text;
        private Encoding _encoding = Encoding.ASCII;
        private IDictionary _headers = new HybridDictionary();
        private IDictionary _fields = new HybridDictionary();
        private MessagePriority _priority = MessagePriority.Normal;
        private MessageAttachmentList _attachments = new MessageAttachmentList();
        private readonly IDictionary<string, LinkedResource> _linkedResources = new Dictionary<string, LinkedResource>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        public Message() {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="from">From header.</param>
        /// <param name="to">To header.</param>
        /// <param name="subject">The subject header.</param>
        /// <param name="body">The message body.</param>
        public Message(string from, string to, string subject, string body) {
            this.To = to;
            this.From = from;
            this.Body = body;
            this.Subject = subject;
        }

        public String To { get; set; }

        public String From { get; set; }

        public String Cc { get; set; }

        public String Bcc { get; set; }

        public String Body { get; set; }

        public String Subject { get; set; }

        public MailAddress ReplyTo { get; set; }

        public Format Format {
            get { return _format; }
            set { _format = value; }
        }

        public Encoding Encoding {
            get { return _encoding; }
            set { _encoding = value; }
        }

        public MessagePriority Priority {
            get { return _priority; }
            set { _priority = value; }
        }

        public IDictionary Headers {
            get { return _headers; }
        }

        public IDictionary Fields {
            get { return _fields; }
        }

        public MessageAttachmentList Attachments {
            get { return _attachments; }
        }

        /// <summary>
        /// You can add any number of inline attachments to this mail message. Inline attachments 
        /// differ from normal attachments in that they can be displayed withing the email body, 
        /// which makes this very handy for displaying images that can be viewed without having to 
        /// access an external server. 
        /// Provide an unique identifier (id) and use it with a &lt;img src="cid:my_id" /> tag from 
        /// within your view code.
        /// </summary>
        public IDictionary<string, LinkedResource> Resources {
            get { return _linkedResources; }
        }
    }
}