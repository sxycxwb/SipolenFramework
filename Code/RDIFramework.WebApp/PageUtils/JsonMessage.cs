
namespace RDIFramework.WebApp
{
    using RDIFramework.WebCommon;

    public class JsonMessage
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }

        public override string ToString()
        {
            return JSONhelper.ToJson(this);
        }
    }
}