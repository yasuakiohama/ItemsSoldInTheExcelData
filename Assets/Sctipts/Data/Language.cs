using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class Language
    {
        public Language()
        {
            param = new List<Entity_Language.Param> ();
            param.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Type.LANGUAGE]) as Entity_Language).param);
        }

        public enum Row : int
        {
            ITEM_HP_PORTION,
            ITEM_MP_PORTION,
            ITEM_BOMB,
            ITEM_FIRE,
            ITEM_THUNDER,
            ITEM_BURIZADO,
            ITEM_QUAKE,
            ITEM_DRAIN,
            ITEM_METEOR,
            ITEM_TYPE_DAMAGE,
            ITEM_TYPE_HEAL,
            ITEM_NANE,
        }

        private List<Entity_Language.Param> param = null;

        public Entity_Language.Param GetRowByKey(string key)
        {
            return param.Where (s => s.key == key).ToArray () [0];
        }
    }
}

//private List<Entity_Language.Param> m_param = null;
//public List<Entity_Language.Param> param
//{
//    get
//    {
//        if( m_param != null )
//        {
//            return m_param;
//        }
//
//        List<Entity_Language.Sheet> entity_Language = new List<Entity_Language.Sheet> ();
//        entity_Language.AddRange ((Resources.Load (MasterData.PATH [(int)MasterData.Type.LANGUAGE]) as Entity_Language).sheets);
//
//        m_param = new List<Entity_Language.Param> ();
//        m_param = entity_Language.Where (s => s.name == Application.systemLanguage.ToString ()).ToArray () [0].list;
//        return m_param;
//    }
//}