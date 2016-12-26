/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , EricHu. 
 *  作    者： EricHu
 *  创建时间： 2012-4-20 10:17:08
 ******************************************************************************/

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

    /// <summary>
    /// PiUserManager
    /// 用户管理
    /// 
    /// </summary>
    public partial class PiUserManager:DbCommonManager
    {
        #region public int Update(BaseUserEntity userEntity, out string statusCode)
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <returns>影响行数</returns>
        public int Update(PiUserEntity userEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查用户名是否重复
            if (this.Exists(PiUserTable.FieldUserName, userEntity.UserName, PiUserTable.FieldDeleteMark, "0", userEntity.Id))
            {
                // 用户名已重复
                statusCode = StatusCode.ErrorUserExist.ToString();
            }
            else
            {
                if (!string.IsNullOrEmpty(userEntity.Code) && userEntity.Code.Length > 0 && this.Exists(PiUserTable.FieldCode, userEntity.Code, PiUserTable.FieldDeleteMark, "0", userEntity.Id))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    returnValue = this.UpdateEntity(userEntity);
                    statusCode = returnValue == 0 ? StatusCode.ErrorDeleted.ToString() : StatusCode.OKUpdate.ToString();
                }
            }
            return returnValue;
        }
        #endregion
    }
}
