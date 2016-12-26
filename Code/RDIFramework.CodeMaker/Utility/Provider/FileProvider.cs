using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Reflection;

namespace RDIFramework.CodeMaker
{
    /// <summary>
    /// 实现文件管理的类。
    /// </summary>
    public  class FileProvider
    {
        /// <summary>
        /// 将文件复制到目标路径。
        /// </summary>
        /// <param name="from">原始文件路径。</param>
        /// <param name="to">目标文件路径。</param>
        /// <returns>如果复制成功则返回 true ，否则返回 false 。</returns>
        public bool Copy(string from, string to)
        {
            bool b = true;

            try
            {
                File.Copy(from, to, true);
            }
            catch
            {
                b = false;
            }

            return b;
        }

        /// <summary>
        /// 删除指定的文件。如果指定的文件不存在，则不引发异常。
        /// </summary>
        /// <param name="path">要删除的文件的名称。</param>
        public void Delete(string path)
        {
            try
            {
                while (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 从给定的路径创建所有的目录和子目录，但不包含文件名部分。
        /// </summary>
        /// <param name="path">要创建的目录路径。</param>
        /// <returns>由 path 指定的 System.IO.DirectoryInfo。</returns>
        public string CreatePath(string path)
        {
            try
            {
                // 分离文件夹和文件名
                string fp = Path.GetDirectoryName(path);
                string fn = Path.GetFileName(path);

                fp = fp.TrimEnd(new char[] { '/', '\\' }) + "\\";

                return Directory.CreateDirectory(fp).FullName + fn;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 确定指定的文件是否存在。
        /// </summary>
        /// <param name="path">要检查的文件的物理路径。</param>
        /// <returns>bool</returns>
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// 确定指定的文件是否存在，如果存在则检查其创建时间是否已经过期。
        /// </summary>
        /// <param name="path">要检查的文件的物理路径。</param>
        /// <param name="expiration">过期时间，单位为秒。</param>
        /// <returns>如果文件不存在或文件已经过期则返回 false 。</returns>
        public bool Exists(string path, int expiration)
        {
            return this.Exists(path, TimeSpan.FromSeconds(expiration));
        }

        /// <summary>
        /// 确定指定的文件是否存在，如果存在则检查其创建时间是否已经过期。
        /// </summary>
        /// <param name="path">要检查的文件的物理路径。</param>
        /// <param name="expiration">指定一个包含过期时间的 TimeSpan。</param>
        /// <returns>如果文件不存在或文件已经过期则返回 false 。</returns>
        public bool Exists(string path, TimeSpan expiration)
        {
            if (this.Exists(path) == false)
            {
                return false;
            }
            else
            {
                if (expiration == TimeSpan.Zero) return true;

                DateTime d1 = File.GetLastWriteTime(path).Add(expiration);
                DateTime d2 = DateTime.Now;

                return d1.CompareTo(d2) > 0 ? true : false;
            }
        }

        /// <summary>
        /// 打开一个文件，使用指定的编码读取文件的所有行，然后关闭该文件。
        /// </summary>
        /// <param name="path">要打开以进行读取的文件。</param>
        /// <param name="encoding">应用到文件内容的编码。</param>
        /// <returns>包含文件所有行的字符串。</returns>
        public string ReadText(string path, Encoding encoding)
        {
            try
            {
                return File.ReadAllText(path, encoding);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 将文档内容保存到指定的文件，如果文件已经存在则覆盖。
        /// </summary>
        /// <param name="path">文件路径。</param>
        /// <param name="contents">文档内容。</param>
        public void WriteText(string path, string contents)
        {
            File.WriteAllText(path, contents, Encoding.UTF8);
        }

        /// <summary>
        /// 将指定的字符串追加到文件中，如果文件还不存在则创建该文件。
        /// </summary>
        /// <param name="path">要将指定的字符串追加到的文件。</param>
        /// <param name="contents">要追加到文件中的字符串。</param>
        public void AppentText(string path, string contents)
        {
            this.AppentText(path, contents, Encoding.UTF8);
        }

        /// <summary>
        /// 将指定的字符串追加到文件中，如果文件还不存在则创建该文件。
        /// </summary>
        /// <param name="path">要将指定的字符串追加到的文件。</param>
        /// <param name="contents">要追加到文件中的字符串。</param>
        /// <param name="encoding">要使用的字符编码。</param>
        public void AppentText(string path, string contents, Encoding encoding)
        {
            File.AppendAllText(path, contents, encoding);
        }

        /// <summary>
        /// 返回上次写入指定文件或目录的日期和时间。
        /// </summary>
        /// <param name="path">要获取其写入日期和时间信息的文件或目录。</param>
        /// <returns>一个 System.DateTime 结构，它被设置为上次写入指定文件或目录的日期和时间。该值用本地时间表示。</returns>
        public DateTime GetLastWriteTime(string path)
        {
            return File.GetLastWriteTime(path);
        }

        /// <summary>
        /// 获取指定文件（指exe、dll文件）的程序集版本号，仅读取Assembly Version
        /// </summary>
        /// <param name="FileName">要获取程序集版本号的文件地址</param>
        /// <returns>如果存在则返回完整的程序集版本号，否则将返回错误信息</returns>
        public string GetAssemblyVersion(string FileName)
        {
            try
            {
                FileVersionInfo fi = FileVersionInfo.GetVersionInfo(FileName);

                Assembly assembly = Assembly.LoadFile(FileName);
                return assembly.GetName().Version.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取指定文件的文件版本号，仅读取FileVersion
        /// </summary>
        /// <param name="FileName">要获取文件版本号的文件地址</param>
        /// <returns>如果存在则返回完整的文件版本号，否则将返回错误信息</returns>
        public string GetFileVersion(string FileName)
        {
            try
            {
                FileVersionInfo fi = FileVersionInfo.GetVersionInfo(FileName);
                return fi.FileVersion;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 复制文件夹中的内容到目标文件夹
        /// </summary>
        /// <param name="srcPath">起始文件夹</param>
        /// <param name="aimPath">目标文件夹</param>
        public bool xCopy(string srcPath, string aimPath)
        {
            try
            {
                if (aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar) { aimPath += Path.DirectorySeparatorChar; }
                if (!Directory.Exists(aimPath)) { Directory.CreateDirectory(aimPath); }

                string[] fileList = Directory.GetFileSystemEntries(srcPath);

                foreach (string file in fileList)
                {
                    if (Directory.Exists(file))
                    {
                        xCopy(file, aimPath + Path.GetFileName(file));
                    }
                    else
                    {
                        File.Copy(file, aimPath + Path.GetFileName(file), true);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 删除指定文件夹及其所有子文件夹
        /// </summary>
        /// <param name="path">要删除的文件夹路径</param>
        public bool DeletePath(string DirectoryPath)
        {
            try
            {
                Directory.Delete(DirectoryPath, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 获取指定文件夹的文件大小
        /// </summary>
        /// <param name="DirectoryPath">文件夹路径</param>
        /// <returns>文件大小</returns>
        public string GetDirectoryLength(string DirectoryPath)
        {
            if (!Directory.Exists(DirectoryPath)) { return "0"; }

            long Length = 0;
            DirectoryInfo di = new DirectoryInfo(DirectoryPath);

            DirectoryInfo[] dis = di.GetDirectories();

            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    Length += long.Parse(GetDirectoryLength(dis[i].FullName));
                }
            }

            foreach (FileInfo fi in di.GetFiles())
            {
                Length += fi.Length;
            }

            return Length.ToString();
        }

        /// <summary>
        /// 获取指定文件夹的根目录的文件列表。
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <returns>string[]</returns>
        public FileInfo[] GetFileList(string path)
        {
            FileInfo[] list = null;

            if (!Directory.Exists(path)) return list;

            DirectoryInfo d = new DirectoryInfo(path);
            d.GetFiles();
            list = d.GetFiles();

            return list;
        }

        /// <summary>
        /// 计算指定文件的MD5码
        /// </summary>
        /// <param name="path">文件的完整物理路径</param>
        /// <returns>文件MD5码</returns>
        public string GetFileMD5(string path)
        {
            try
            {
                FileStream f = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                MD5CryptoServiceProvider g = new MD5CryptoServiceProvider();
                byte[] b = g.ComputeHash(f);
                f.Close();
                string s = System.BitConverter.ToString(b);
                s = s.Replace("-", "");
                return s;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
