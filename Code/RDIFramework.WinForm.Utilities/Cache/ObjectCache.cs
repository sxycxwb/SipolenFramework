/******************************************************************************
 *  All Rights Reserved , Copyright (C) 2012 , XuWangBin. 
 *  作    者： XuWangBin
 *  创建时间： 2012-5-24 9:55:21
 ******************************************************************************/

using System;
using System.Runtime.Remoting.Messaging;

namespace RDIFramework.WinForm.Utilities
{
    /// <summary>
    /// ObjectCache
    /// 对象缓存管理
    /// 
    /// </summary>
    public class ObjectCache
    {
        /// <summary>
        /// 数据缓存保存信息异步处理委托
        /// </summary>
        delegate void EventSaveCache(object key, object value);

             /// <summary>
        /// 构造缓存对象
        /// </summary>
        public ObjectCache()
        {
        }

        // 用于缓存数据的Hashtable       
        protected System.Collections.Hashtable hashTableCache = new System.Collections.Hashtable();
        protected Object _LockObj = new object();

        public int Count
        {
            get
            { return hashTableCache.Count; }
        }

        #region 获取指定键值的对象GetObject()

        /// <summary>
        /// 获取指定键值的对象
        /// </summary>
        /// <param name="key">键值</param>
        /// <returns>object</returns>
        public virtual object GetObject(object key)
        {
            if (hashTableCache.ContainsKey(key))
            {
                return hashTableCache[key];
            }
            return null;
        }

        #endregion

        #region 把对象按指定的键值保存到缓存中SaveCaech()
        /// <summary>
        /// 把对象按指定的键值保存到缓存中
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">保存的对象</param>
        public void SaveCache(object key, object value)
        {
            EventSaveCache save = new EventSaveCache(SetCache);
            IAsyncResult ar = save.BeginInvoke(key, value, new System.AsyncCallback(Results), null);
        }

        /// <summary>
        /// 把对象按指定的键值保存到缓存中
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="value">保存的对象</param>
        protected virtual void SetCache(object key, object value)
        {
            lock (_LockObj)
            {
                if (!hashTableCache.ContainsKey(key))
                    hashTableCache.Add(key, value);
            }
        }

        private void Results(IAsyncResult ar)
        {
            EventSaveCache fd = (EventSaveCache)((AsyncResult)ar).AsyncDelegate;
            fd.EndInvoke(ar);
        }
        #endregion

        #region 在缓存中删除指定键值的对象DelObject()
        /// <summary>
        /// 在缓存中删除指定键值的对象
        /// </summary>
        /// <param name="key">键值</param>
        public virtual void DelObject(object key)
        {
            lock (hashTableCache.SyncRoot)
            {
                hashTableCache.Remove(key);
            }
        }
        #endregion

        #region 清除缓存中所有对象Clear()
        /// <summary>
        /// 清除缓存中所有对象
        /// </summary>
        public virtual void Clear()
        {
            lock (hashTableCache.SyncRoot)
            {
                hashTableCache.Clear();
            }
        }
        #endregion
    }
}
