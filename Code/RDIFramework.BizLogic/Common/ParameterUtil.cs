using System.Reflection;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

	public class ParameterUtil
	{
		private UserInfo userInfo = null;

		private MethodBase currentMethod = null;

		private string rdiMessage = string.Empty;

		private string serviceName = string.Empty;

	    private string parameter = string.Empty;

		private bool isAddLog = true;

		public static ParameterUtil CreateWithMessage(UserInfo userInfo, MethodBase currentMethod, string serviceName, string rdiMessage)
		{
			return new ParameterUtil(userInfo, currentMethod) 
				{ ServiceName = serviceName, RDIFrameworkMessage = rdiMessage,IsAddLog = !string.IsNullOrEmpty(rdiMessage) };
		}

        public static ParameterUtil CreateWithMessage(UserInfo userInfo, MethodBase currentMethod, string serviceName, string rdiMessage,string par)
        {
            return new ParameterUtil(userInfo, currentMethod) { ServiceName = serviceName, RDIFrameworkMessage = rdiMessage,Parameter = par };
        }

		public static ParameterUtil CreateWithOutMessage(UserInfo userInfo, MethodBase currentMethod, string serviceName)
		{
			return new ParameterUtil(userInfo, currentMethod) 
				{ ServiceName = serviceName };
		}

		public static ParameterUtil CreateWithLog(UserInfo userInfo, MethodBase currentMethod)
		{
			return new ParameterUtil(userInfo, currentMethod) { IsAddLog = false };
		}

		private ParameterUtil(UserInfo userInfo, MethodBase currentMethod)
		{
			this.userInfo = userInfo;
			this.currentMethod = currentMethod;
		}

		public string RDIFrameworkMessage
		{
			set { rdiMessage = value; }
			get { return rdiMessage; }
		}

		public string ServiceName
		{
			set { serviceName = value; }
			get { return serviceName; }
		}

	    public string Parameter
	    {
	        set { parameter = value; }
            get { return parameter; }
	    }

		public bool IsAddLog
		{
			set { isAddLog = value; }
			get { return isAddLog; }
		}

		public UserInfo UserInfo
		{
			set { userInfo = value; }
			get { return userInfo; }
		}

		public MethodBase CurrentMethod
		{
			set { currentMethod = value; }
			get { return currentMethod; }
		}
	}
}
