using System.Collections;
using GameCore.Data;
using UnityEngine;

namespace GameCore.Servises.Saving
{
    public class PeriodicDataSaver : MonoBehaviour
    {
        public bool DoSave = true;
        [SerializeField] private DataSaver _saver;
        [SerializeField] private MainConfig _config;

        private void Start()
        {
            StartCoroutine(PeriodicSaving(_config.DataSavePeriod));
        }

        private IEnumerator PeriodicSaving(float period)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(period);
                try
                {
                    if(DoSave)
                        _saver.SaveData();
                }
                catch(System.Exception ex)
                {
                    Debug.Log($"Can't save!. {ex.Message}\n {ex.StackTrace}");
                }
            }
        }
    }
}