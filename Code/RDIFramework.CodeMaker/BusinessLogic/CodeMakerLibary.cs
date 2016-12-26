using System.IO;
using System.Text;

namespace RDIFramework.CodeMaker
{
    public class CodeMakerLibary
    {
        /// <summary>
        /// 得到模版文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetTemplate(string file)
        {
            string code = string.Empty;
            var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var streamReader = new StreamReader(fileStream, Encoding.Default))
            {
                code = streamReader.ReadToEnd();
            }
            return code;
        }       
    }
}
