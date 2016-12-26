/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-6-26 15:31:02
 ******************************************************************************/
using System;
using System.IO;

namespace RDIFramework.Utilities
{
    /// <summary>
    /// Represents a file attachment
    /// </summary>
    public class MessageAttachment {
        private readonly String mediaType;
        private readonly Stream stream;

        /// <summary>
        /// Creates a new attachment
        /// </summary>
        /// <param name="mediaType">Look at System.Net.Mimie.MediaTypeNames for help.</param>
        /// <param name="fileName">Path to the file.</param>
        public MessageAttachment(String mediaType, String fileName) {
            this.mediaType = mediaType;

            if (fileName == null) throw new ArgumentNullException("fileName");

            var info = new FileInfo(fileName);

            if (!info.Exists) throw new ArgumentException("The specified file does not exists", "fileName");

            this.FileName = fileName;
        }

        /// <summary>
        /// Creates a new attachment
        /// </summary>
        /// <param name="mediaType">Look at System.Net.Mime.MediaTypeNames for help.</param>
        /// <param name="stream">File stream.</param>
        public MessageAttachment(String mediaType, Stream stream) {
            this.mediaType = mediaType;

            if (stream == null) {
                throw new ArgumentNullException("stream");
            }

            this.stream = stream;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageAttachment"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mediaType">Type of the media.</param>
        /// <param name="stream">The stream.</param>
        public MessageAttachment(string fileName, string mediaType, Stream stream)
            : this(mediaType, stream) {
            this.FileName = fileName;
            }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public String FileName { get; set; }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        /// <value>The type of the media.</value>
        public String MediaType {
            get { return mediaType; }
        }

        /// <summary>
        /// Gets the stream.
        /// </summary>
        /// <value>The stream.</value>
        public Stream Stream {
            get { return stream; }
        }
    }
}