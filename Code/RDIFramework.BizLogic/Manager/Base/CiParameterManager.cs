//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Aite TECH, Ltd.
//--------------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace RDIFramework.BizLogic
{
    using RDIFramework.Utilities;

     /// <summary>
     /// CiParameterManager
     /// 系统参数配置表
     ///
     /// 修改纪录
     ///
     ///		2012-03-02 版本：1.0 EricHu 创建主键。
     ///
     /// 版本：3.0
     ///
     /// <author>
     ///		<name>EricHu</name>
     ///		<date>2012-03-02</date>
     /// </author>
     /// </summary>
    public partial class CiParameterManager
    {
          #region public string Add(string categoryKey, string parameterId, string parameterCode, string parameterContent, bool worked, bool enabled)
          /// <summary>
          /// 添加
          /// </summary>
          /// <param name="categoryKey">类别主键</param>
          /// <param name="parameterId">标记主键</param>
          /// <param name="parameterCode">标记编码</param>
          /// <param name="parameterContent">标记内容</param>
          /// <param name="worked">工作状态</param>
          /// <param name="enabled">有效</param>
          /// <returns>主键</returns>
          public string Add(string categoryKey, string parameterId, string parameterCode, string parameterContent, bool worked, bool enabled)
          {
              CiParameterEntity parameterEntity = new CiParameterEntity
              {
                  CategoryKey = categoryKey,
                  ParameterId = parameterId,
                  ParameterCode = parameterCode,
                  ParameterContent = parameterContent,
                  Worked = worked ? 1 : 0,
                  Enabled = enabled ? 1 : 0
              };
              return this.Add(parameterEntity);
          }
          #endregion

          #region public string Add(CiParameterEntity parameterEntity)
          /// <summary>
          /// 添加内容
          /// </summary>
          /// <param name="parameterEntity">内容</param>
          /// <returns>主键</returns>
          public string Add(CiParameterEntity parameterEntity)
          {
              string returnValue = string.Empty;
              // 此处检查this.exist()
              List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
              {
                  new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, parameterEntity.CategoryKey),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterEntity.ParameterId),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterCode, parameterEntity.ParameterCode)
              };
              if (this.Exists(parameters))
              {
                  // 编号已重复
                  this.ReturnStatusCode = StatusCode.ErrorCodeExist.ToString();
              }
              else
              {
                  returnValue = this.AddEntity(parameterEntity);
                  // 运行成功
                  this.ReturnStatusCode = StatusCode.OKAdd.ToString();
              }
              return returnValue;
          }
          #endregion

          #region public int Update(CiParameterEntity parameterEntity) 更新
          /// <summary>
          /// 更新
          /// </summary>
          /// <param name="parameterEntity">参数基类表结构定义</param>
          /// <returns>影响行数</returns>
          public int Update(CiParameterEntity parameterEntity)
          {
              int returnValue = 0;

              // 检查编号是否重复
              if (this.Exists(new KeyValuePair<string, object>(CiParameterTable.FieldParameterCode, parameterEntity.ParameterCode), parameterEntity.Id))
              {
                  // 文件夹名已重复
                  this.ReturnStatusCode = StatusCode.ErrorCodeExist.ToString();
              }
              else
              {
                  // 进行更新操作
                  returnValue = this.UpdateEntity(parameterEntity);
                  this.ReturnStatusCode = returnValue == 1 ? StatusCode.OKUpdate.ToString() : StatusCode.ErrorDeleted.ToString();
              }
              return returnValue;
          }
          #endregion

          #region public string GetParameter(string categoryKey, string parameterId, string parameterCode)
          /// <summary>
          /// 获取参数
          /// </summary>
          /// <param name="categoryKey">类别主键</param>
          /// <param name="parameterId">标志主键</param>
          /// <param name="parameterCode">编码</param>
          /// <returns>参数值</returns>
          public string GetParameter(string categoryKey, string parameterId, string parameterCode)
          {
              List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
              {
                  new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterCode, parameterCode),
                  new KeyValuePair<string, object>(CiParameterTable.FieldDeleteMark, 0)
              };
              return this.GetProperty(parameters, CiParameterTable.FieldParameterContent).ToString();
          }
          #endregion

          #region public int SetParameter(string categoryKey, string parameterId, string parameterCode, string parameterContent)
          /// <summary>
          /// 更新参数设置
          /// </summary>
          /// <param name="categoryKey">类别主键</param>
          /// <param name="parameterId">标志主键</param>
          /// <param name="parameterCode">编码</param>
          /// <param name="parameterContent">参数内容</param>
          /// <returns>影响行数</returns>
          public int SetParameter(string categoryKey, string parameterId, string parameterCode, string parameterContent,int allowEdit = 0,int allowDelete = 0)
          {
              int returnValue = 0;

              List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
              {
                  new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterCode, parameterCode),
                  new KeyValuePair<string, object>(CiParameterTable.FieldDeleteMark, 0)
              };
              // 检测是否无效数据
              if (string.IsNullOrEmpty(parameterContent))
              {
                  returnValue = this.Delete(parameters);
              }
              else
              {
                  // 检测是否存在
                  returnValue = this.SetProperty(parameters, new KeyValuePair<string, object>(CiParameterTable.FieldParameterContent, parameterContent));
                  if (returnValue == 0)
                  {
                      // 进行增加操作
                      CiParameterEntity parameterEntity = new CiParameterEntity
                      {
                          CategoryKey = categoryKey,
                          ParameterId = parameterId,
                          ParameterCode = parameterCode,
                          ParameterContent = parameterContent,
                          AllowDelete = allowDelete,
                          AllowEdit = allowEdit,
                          Enabled = 1,
                          Worked = 0,
                          DeleteMark = 0
                      };
                      this.AddEntity(parameterEntity);
                      returnValue = 1;
                  }
              }
              return returnValue;
          }
          #endregion

          #region public DataTable GetDataTableByParameter(string categoryKey, string parameterId)
          /// <summary>
          /// 获取记录
          /// </summary>
          /// <param name="categoryKey">类别主键</param>
          /// <param name="parameterId">标志主键</param>
          /// <returns>数据表</returns>
          public DataTable GetDTByParameter(string categoryKey, string parameterId)
          {
              List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
              {
                  new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId)
              };
              return this.GetDT(parameters);
          }
          #endregion

          #region public DataTable GetDTByParameterCode(string categoryKey, string parameterId, string parameterCode)
          /// <summary>
          /// 获取记录
          /// </summary>
          /// <param name="categoryKey">类别主键</param>
          /// <param name="parameterId">参数主键</param>
          /// <param name="parameterCode">编码</param>
          /// <returns>数据表</returns>
          public DataTable GetDTByParameterCode(string categoryKey, string parameterId, string parameterCode)
          {
              List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
              {
                  new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterCode, parameterCode)
              };
              return this.GetDT(parameters, CiParameterTable.FieldCreateOn);
          }
          #endregion

          #region public int DeleteByParameter(string categoryKey, string parameterId)
          /// <summary>
          /// 删除
          /// </summary>
          /// <param name="categoryKey">类别主键</param>
          /// <param name="parameterId">参数主键</param>
          /// <returns>影响行数</returns>
          public int DeleteByParameter(string categoryKey, string parameterId)
          {
              List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
              {
                  new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId)
              };
              return this.Delete(parameters);
          }
          #endregion

          #region public int DeleteByParameterCode(string categoryKey, string parameterId, string parameterCode)
          /// <summary>
          /// 删除
          /// </summary>
          /// <param name="categoryKey">类别主键</param>
          /// <param name="parameterId">标志主键</param>
          /// <param name="parameterCode">标志编号</param>
          /// <returns>影响行数</returns>
          public int DeleteByParameterCode(string categoryKey, string parameterId, string parameterCode)
          {
              List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>
              {
                  new KeyValuePair<string, object>(CiParameterTable.FieldCategoryKey, categoryKey),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterId, parameterId),
                  new KeyValuePair<string, object>(CiParameterTable.FieldParameterCode, parameterCode)
              };
              return this.Delete(parameters);
          }
          #endregion
      }
}
