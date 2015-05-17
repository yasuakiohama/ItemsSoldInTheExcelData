using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    /// <summary>
    /// Itemsのエクセルデータ設定用クラス
    /// sepalate seetにチェックを着けてある。
    /// </summary>
    public class Items
    {
        public enum Row : int
        {
            hpPortion,
            mpPortion,
            bomb,
            fire,
            thunder,
            Burizado,
            quake,
            drain,
            Meteor,
        }

        private List<Entity_Items.Param> m_param = null;
        public List<Entity_Items.Param> param
        {
            get
            {
                if( m_param != null )
                {
                    return m_param;
                }

                m_param = new List<Entity_Items.Param> ();
                m_param.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Type.ITEMS]) as Entity_Items).param);
                return m_param;
            }
        }
    }
}