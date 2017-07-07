using RichUnity.Math;
using UnityEngine;

namespace RichUnity.Spawners {
    public class CuboidAreaSpawner : PrefabSpawner {
        //public enum Axis {
        //    X,
        //    Y,
        //    Z
        //}

        public Cuboid CuboidArea = new Cuboid();
        
        public int ObjectNumber;

        //public bool LerpProperties;
        //public Axis LerpAxis;
        //public Color BeginColor;
        //public Color EndColor;


        public override void Awake() {
            for (int i = 0; i < ObjectNumber; ++i) {
                Vector3 position = new Vector3 {
                    x = CuboidArea.RandomX(),
                    y = CuboidArea.RandomY(),
                    z = CuboidArea.RandomZ()
                };
                GameObject obj = Spawn();
                obj.transform.position = position;
            }
        }

        void OnDrawGizmos() {
            CuboidArea.DrawWireGizmos(Color.cyan);
        }
    }

    /*[CustomEditor(typeof(CuboidAreaSpawner))]
    public class СuboidAreaSpawnerEditor : Editor {

        public override void OnInspectorGUI() {
            CuboidAreaSpawner script = target as CuboidAreaSpawner;

            script.ObjectPrefab = EditorGUILayout.ObjectField("Object Prefab", script.ObjectPrefab, typeof(GameObject), false) as GameObject;

            script.SpawnAsChilds = GUILayout.Toggle(script.SpawnAsChilds, "Spawn As Childs");

            EditorGUILayout.LabelField("Cuboid Area");
            script.CuboidArea.Center = EditorGUILayout.Vector3Field("Center", script.CuboidArea.Center);
            script.CuboidArea.Size = EditorGUILayout.Vector3Field("Size", script.CuboidArea.Size);


            script.ObjectNumber = EditorGUILayout.IntField("Object Number", script.ObjectNumber);
            if (script.ObjectNumber < 1) {
                script.ObjectNumber = 1;
            }

            //script.LerpProperties = GUILayout.Toggle(script.LerpProperties, "Lerp Properties");

            //if (script.LerpProperties) {
            //    script.LerpAxis =
            //        (CuboidAreaSpawner.Axis) EditorGUILayout.EnumPopup("Lerp Axis", script.LerpAxis);
            //    script.BeginColor = EditorGUILayout.ColorField("Begin Color", script.BeginColor);
            //    script.EndColor = EditorGUILayout.ColorField("End Color", script.EndColor);
            //}
        }
    }*/
}
