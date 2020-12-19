using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CResourcesManager : MonoBehaviour
{
    public static class ObjectName
    {
        // 소유자 Object의 이름.
        public const string Owner = "ResourcesManager";
    }

    public static CResourcesManager Get
    {
        get { return CProjectManager.Get.CResourcesManager; }
    }


    [SerializeField]
    private CAddressableManager m_CAddressableManager = null;

    #region Property
    public CAddressableManager CAddressableManager { get => m_CAddressableManager; private set => m_CAddressableManager = value; }

    #endregion
}
