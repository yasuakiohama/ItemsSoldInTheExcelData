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

        public enum Key
        {
            TEXT_ITEM_HP_PORTION,
            TEXT_ITEM_MP_PORTION,
            TEXT_ITEM_BOMB,
            TEXT_ITEM_FIRE,
            TEXT_ITEM_THUNDER,
            TEXT_ITEM_BURIZADO,
            TEXT_ITEM_QUAKE,
            TEXT_ITEM_DRAIN,
            TEXT_ITEM_METEOR,
            TEXT_ITEM_TYPE_DAMAGE,
            TEXT_ITEM_TYPE_HEAL,
            TEXT_ITEM_NANE,
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