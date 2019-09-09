using UnityEngine;
using System;
using WebStorage;

namespace Examples
{
    [Serializable]
    public class TestClass
    {
        public int id;
        public string name;

        public TestClass(int id, string name) {
            this.id = id;
            this.name = name;
        }
    }

    public class Example : MonoBehaviour
    {
        private void Start()
        {
            if(LocalStorage.IsAvailable()) {
                LocalStorage.SetItem("foo1", "bar1");
                LocalStorage.SetItem("foo2", "bar2");
                LocalStorage.SetItem("foo3", "bar3");
                LocalStorage.SetItem("foo4", null); // test injected null value
                Debug.Log(LocalStorage.GetItem("foo1"));
                Debug.Log(LocalStorage.GetItem("foo2"));
                Debug.Log(LocalStorage.GetItem("foo3"));
                Debug.Log(LocalStorage.GetItem("missing")); // missing records return null

                // write: Serialize Class into localStorage 
                string jsonStr = JsonUtility.ToJson(new TestClass(1, "foobar"));
                Debug.Log(jsonStr);
                LocalStorage.SetItem("myData", jsonStr);

                // read: Deserialize Class out of localStorage 
                string jsonData = LocalStorage.GetItem("myData");
                TestClass test = JsonUtility.FromJson<TestClass>(jsonData);
                Debug.Log("TestClass id: "+test.id+", name: "+test.name);
            }
        }
    }
}
