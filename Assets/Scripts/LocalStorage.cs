using UnityEngine;
using System.Runtime.InteropServices;

namespace WebStorage {

    public class LocalStorage {

        // Javascript bridge
        // These function names must match exactly those found in html5LocalStroage.jslib
        [DllImport("__Internal")]
        private static extern bool localStorageIsAvailable();

        [DllImport("__Internal")]
        private static extern void localStorageSetItem(string key, string data);

        [DllImport("__Internal")]
        private static extern string localStorageGetItem(string key);

        [DllImport("__Internal")]
        private static extern void localStorageRemoveItem(string key);

        [DllImport("__Internal")]
        private static extern void localStorageClear();

        [DllImport("__Internal")]
        private static extern bool localStorageHasOwnProperty(string key);


        // -- Adpater functions use to expose the interal JS bridge --

        public static bool IsAvailable() {
            if (Application.platform != RuntimePlatform.WebGLPlayer) {
                return false;
            }
            return localStorageIsAvailable();
        }

        // if below functions are call outside WebGL runtime
        // EntryPointNotFoundException will be thrown
        // Always Use LocalStorage.IsAvailable() to check before calling these functions

        public static void SetItem(string key, string data) {
           localStorageSetItem(key, data);
        }

        public static string GetItem(string key) {
            return localStorageGetItem(key);
        }

        public static void RemoveItem(string key) {
            localStorageRemoveItem(key);
        }

        public static void Clear(string key) {
            localStorageClear();
        }

        public static bool HasKey(string key) {
            return localStorageHasOwnProperty(key);
        }
    }
}
