using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class CAddressableManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// 에셋 로드
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_AssetName"></param>
    /// <param name="_Result"></param>
    public void LoadAsync<T>(string _AssetName, Action<bool, T> _Result)
    {
        AsyncOperationHandle<T> _Asset = Addressables.LoadAssetAsync<T>(_AssetName);

        _Asset.Completed += (_Handle) =>
        {
            if (_Handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                // 로드 성공
                if (_Result != null)
                    _Result(true, _Asset.Result);
            }
            else
            {
                // 로드 실패
                if (_Result != null)
                    _Result(false, default(T));
            }
        };
    }

    /// <summary>
    /// 에셋 생성
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_AssetName"></param>
    /// <param name="_Result"></param>
    public void InstantiateAsync<T>(string _AssetName, Action<bool, GameObject> _Result)
    {
        AsyncOperationHandle<GameObject> _Asset = Addressables.InstantiateAsync(_AssetName);

        _Asset.Completed += (_Handle) =>
        {
            if (_Handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                // 로드 성공
                if (_Result != null)
                    _Result(true, _Asset.Result);
            }
            else
            {
                // 로드 실패
                if (_Result != null)
                    _Result(false, null);
            }
        };
    }

}
