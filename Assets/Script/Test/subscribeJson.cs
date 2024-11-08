using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.IO;

namespace Test
{
    public class subscribeJson : MonoBehaviour
    {
        [SerializeField] private GameObject obj;
        [System.Serializable]
        public struct Note
        {
            public string timing;
        }
        public struct NotesData
        {
            public List<Note> Notes;
        }
        private void Start()
        {
            string path = "Assets/Audio/Notes/NovelGameBGM.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                NotesData notesData = JsonUtility.FromJson<NotesData>(json);
                for(int i = 0; i < notesData.Notes.Count; i++)
                {
                    var noteTime = notesData.Notes[i].timing;
                    Debug.Log(noteTime);
                }
            }
            else
            {
                Debug.LogError("JSON file not found");
            }
        }
        IEnumerator InstantiateNote(float timing)
        {
            yield return new WaitForSeconds(timing);
            Vector3 posi = new Vector3(0, 0, 0);
            Instantiate(obj, posi, Quaternion.identity);
        }
    }
}
