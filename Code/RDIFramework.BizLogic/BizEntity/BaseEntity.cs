using System;
using System.Collections.Generic;
using System.Data;

namespace RDIFramework.BizLogic
{
    /// <summary>
    /// 基业务实体
    /// </summary>
    [Serializable]
    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity() { }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dr">数据行</param>
        public void GetFromExpand(DataRow dr)
        {
            GetFromExpand(new DRDataRow(dr));
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public void GetFromExpand(IDataReader dataReader)
        {
            GetFromExpand(new DRDataReader(dataReader));
        }

        /// <summary>
        /// 从自定义数据流读取
        /// </summary>
        /// <param name="dr">数据流</param>
        public virtual void GetFromExpand(IDataRow dr)
        {
        }
       
        #region IBaseEntity 成员

        protected abstract BaseEntity GetFrom(IDataRow dr);

        public BaseEntity GetFrom(DataRow dr)
        {
            return GetFrom(new DRDataRow(dr));
        }

        public BaseEntity GetFrom(IDataReader dataReader)
        {
            return GetFrom(new DRDataReader(dataReader));
        }

        public BaseEntity GetFrom(DataTable dt)
        {
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dr in dt.Rows)
            {
                this.GetFrom(dr);
                break;
            }
            return this;
        }

        public BaseEntity GetSingle(DataTable dt)
        {
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dr in dt.Rows)
            {
                this.GetFrom(dr);
                break;
            }
            return this;
        }

        #endregion

        public static T Create<T>() where T : BaseEntity, new()
        {
            return new T();
        }

        public static T Create<T>(DataTable dt) where T : BaseEntity, new()
        {
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                return null;
            }
            T entity = Create<T>();
            entity.GetFrom(dt.Rows[0]);
            return entity;
        }

        public static T Create<T>(DataRow dr) where T : BaseEntity, new()
        {
            T entity = Create<T>();
            entity.GetFrom(dr);
            return entity;
        }

        public static T Create<T>(IDataReader dataReader) where T : BaseEntity, new()
        {
            T entity = Create<T>();
            entity.GetFrom(dataReader);
            return entity;
        }

        public static List<T> GetList<T>(DataTable dt) where T : BaseEntity, new()
        {
            if ((dt == null) || (dt.Rows.Count == 0))
            {
                return new List<T>();
            }
            List<T> entites = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                entites.Add(Create<T>(dr));
            }
            return entites;
        }
    }
}
