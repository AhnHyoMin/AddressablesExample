using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CProjectManager : MonoBehaviour
{
    private static CProjectManager m_Instance = null;

    public static class ObjectName
    {
        // 소유자 Object의 이름.
        public const string Owner = "ProjectManager";
    }
    public static CProjectManager Get
    {
        get
        {
            if (Application.isPlaying)
            {
                if (m_Instance == null)
                {
                    GameObject _GameObject = GameObject.Find(ObjectName.Owner);

                    if (_GameObject == null)
                    {
                        _GameObject = Resources.Load(ObjectName.Owner, typeof(GameObject)) as GameObject;
                        _GameObject = Instantiate(_GameObject) as GameObject;

                        m_Instance = _GameObject.GetComponent<CProjectManager>();
                        DontDestroyOnLoad(_GameObject);
                    }

                }
            }

            return m_Instance;
        }
    }




    #region Manager

    [SerializeField]
    private CResourcesManager m_CResourcesManager = null;




    #region ManagerProperty
    public CResourcesManager CResourcesManager { get => m_CResourcesManager; private set => m_CResourcesManager = value; }

    #endregion

    #endregion

    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CResourcesManager.Get.CAddressableManager.InstantiateAsync<GameObject>("Cube",
                (bool _State, GameObject _GameObject) =>
                {
                    if (_State == true)
                    {
                        Debug.Log(_GameObject.name);
                    }

                });
        }
    }

    private void Initialize()
    {
        if (m_CResourcesManager == null)
            m_CResourcesManager = transform.Find(CResourcesManager.ObjectName.Owner).GetComponent<CResourcesManager>();
    }
}
