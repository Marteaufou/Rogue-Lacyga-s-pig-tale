using UnityEngine;
using System.Collections.Generic;

namespace LevelEditor
{
    public class RessourcesManager : MonoBehaviour
    {

        public List<LevelGameObjectBase> LevelGameObjects = new List<LevelGameObjectBase>();
        public List<LevelStackedObjsBase> LevelGameObjects_Stacking = new List<LevelStackedObjsBase>();
        public List<Material> LevelMaterials = new List<Material>();
        public GameObject wallPrefab;

        private static RessourcesManager instance = null;

        void Awake()
        {
            instance = this;
        }

        public static RessourcesManager GetInstance()
        {
            return instance;
        }

        public LevelGameObjectBase GetObjBase(string objId)
        {
            LevelGameObjectBase retVal = null;

            for (int i = 0; i < LevelGameObjects.Count; i++)
            {
                if (objId.Equals(LevelGameObjects[i].obj_Id))
                {
                    retVal = LevelGameObjects[i];
                    break;
                }
            }
            return retVal;

        }

        public LevelStackedObjsBase GetStackObjBase(string stack_id)
        {
            LevelStackedObjsBase retVal = null;

            for (int i = 0; i < LevelGameObjects.Count; i++)
            {
                if (stack_id.Equals(LevelGameObjects_Stacking[i].stack_id))
                {
                    retVal = LevelGameObjects_Stacking[i];
                    break;
                }
            }
            return retVal;
        }

        public Material GetMaterial(int matId)
        {
            Material retVal = null;

            for (int i = 0; i < LevelMaterials.Count; i++)
            {
                if (matId == i)
                {
                    retVal = LevelMaterials[i];
                    break;
                }
            }

            return retVal;
        }

        public int GetMaterialId(Material mat)
        {
            int id = -1;

            for (int i = 0; i < LevelMaterials.Count; i++)
            {
                if (mat.Equals(LevelMaterials[i]))
                {
                    id = i;
                    break;
                }
            }

            return id;
        }
    }

    [System.Serializable]
    public class LevelGameObjectBase
    {
        public string obj_Id;
        public GameObject objPrefab;
    }

    [System.Serializable]
    public class LevelStackedObjsBase
    {
        public string stack_id;
        public GameObject objPrefab;
    }
}

