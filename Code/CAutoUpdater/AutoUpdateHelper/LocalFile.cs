using System.Xml.Serialization;

namespace CAutoUpdater
{
    public class LocalFile
    {
        #region The private fields
        private string path = "";
        private string lastver = "";
        private string updateurl = "";
        private string md5 = "";
        private int size = 0;
        #endregion

        #region The public property
        public string Updateurl
        {
            get
            {
                return this.updateurl;
            }
            set
            {
                this.updateurl = value;
            }
        }

        public string Md5
        {
            get
            {
                return this.md5;
            }
            set
            {
                this.md5 = value;
            }
        }

        /// <summary>
        /// File Name
        /// </summary>
        [XmlAttribute("path")]
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        /// <summary>
        /// The latest version
        /// </summary>
        [XmlAttribute("lastver")]
        public string LastVer
        {
            get
            {
                return lastver;
            }
            set
            {
                lastver = value;
            }
        }

        /// <summary>
        /// File size
        /// </summary>
        [XmlAttribute("size")]
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
        #endregion

        #region The constructor of LocalFile
        public LocalFile(string path, string ver, int size, string md5,string updateurl)
        {
            this.path = path;
            this.lastver = ver;
            this.size = size;
            this.md5 = md5;
            this.updateurl = updateurl;
        }

        public LocalFile()
        {
        }
        #endregion
    }
}