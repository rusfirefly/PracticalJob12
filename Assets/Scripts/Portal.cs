using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Portal : MonoBehaviour
{
    public SceneID SceneID;
    public bool IsLobby;
    public int SceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if (IsLobby == false)
            {
                SaveHandler.Instance.SavedData.SetPortallId(-1);
                SaveHandler.Instance.SavedData.SetLevelId((int)(++SceneID));
            }
            else
            {
                SaveHandler.Instance.SavedData.SetPortallId(SceneNumber);
            }

            SaveHandler.Instance.Save();
            SceneManager.LoadScene((int)SceneID.LoadScene);
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(Portal)), InitializeOnLoadAttribute]
public class PortalEditor: Editor
{
    Portal _portal;
    SerializedObject _serPortal;

    public void OnEnable()
    {
        _portal = (Portal)target;
        _serPortal = new SerializedObject(_portal);
    }

    public override void OnInspectorGUI()
    {
        _serPortal.Update();

        _portal.IsLobby = EditorGUILayout.ToggleLeft(new GUIContent("IsLobby"), _portal.IsLobby);
        _portal.SceneID = (SceneID)EditorGUILayout.EnumPopup(new GUIContent("Scene ID"), _portal.SceneID);

        if (_portal.SceneID == SceneID.SceneNumber)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel(new GUIContent("переход к уровню:"));
            _portal.SceneNumber = EditorGUILayout.IntField(_portal.SceneNumber);
            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel--;
        }
        

        
    }
}
#endif
