using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DataManager : MonoBehaviour
{


    [Header("Suffix for the exported file")]
    public string exportFileName = "Test_Supermercado";

    private void Awake()
    {
        GameManager.OnGameEnded += HandleWriteCSVDump;
    }

    void Start()
        {
            Debug.Log(Application.persistentDataPath);
            
        }

        private void HandleWriteCSVDump()
        {
            Debug.Log("Escribo el CSV");
            SaveToFile(DateTime.Now.ToString("dd-MM-yyyy"), DateTime.Now.ToString("HH.mm"));
        }

        public string ToCSV(string date, string time)
        {
            var sb = new StringBuilder("Fecha,Hora,Tiempo Transcurrido,Usos de Mapa");
            var elapsedTime = Timer.GetCurrentTime();
            var mapInvocations = PlayerPrefs.GetInt(Prefs.MAP_INVOCATIONS.ToString());
            
            sb.Append('\n').Append(date).Append(',').Append(time).Append(',').Append(elapsedTime).Append(',').Append(mapInvocations);
            return sb.ToString();
        }

        public void SaveToFile(string date, string time)
        {
            var content = ToCSV(date, time);
#if UNITY_EDITOR
            var folder = Application.streamingAssetsPath;

            if(!Directory.Exists(folder)) Directory.CreateDirectory(folder);
#else
    var folder = Application.persistentDataPath;
#endif
            var filePath = Path.Combine(folder, $"{exportFileName}_{date}_{time}.csv");
            
            using(var writer = new StreamWriter(filePath, false))
            {
                writer.Write(content);
            }
            Debug.Log($"CSV file written to \"{filePath}\"");
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
        }

        private void PrintDictionary(Dictionary<string, EntityWithTime> dictionary) 
        {
            foreach (var key in dictionary.Keys)
            {
                Debug.Log("Key " + key);
            }
            
            foreach (var value in dictionary.Values)
            {
                Debug.Log("Values -> " + value.entity.GetName() + ":" + value.elaspedTime);
            }
            
            Debug.Log("Elapsed Time " + Timer.GetCurrentTime());
            Debug.Log("Time" + System.DateTime.Now.ToString("dd-MM-yyyy"));
            Debug.Log("Time" + System.DateTime.Now.ToString("HH:mm:ss tt zz"));
        }
}
