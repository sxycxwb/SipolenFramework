/*****************************************************************
 * Copyright (C) EricHu Corporation. All rights reserved.
 * 
 * Author:   EricHu 
 * Email:    80368704@qq.com
 * Website:  http://www.cnblogs.com/huyong/       
 * Create Date:  5/8/2010 
 * Usage:
 *
 * RevisionHistory
 * Date         Author               Description
 * 
*****************************************************************/

namespace CAutoUpdater
{
    public interface IAutoUpdater
    {
        /// <summary>
        /// To Update
        /// </summary>
        void Update();

        /// <summary>
        /// RollBack update
        /// </summary>
        void RollBack();
    }
}
