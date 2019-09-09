mergeInto(LibraryManager.library, {

  /**
   * Check browser if HTML5 localStorage is supported
   * @return {boolean}
   */
  localStorageIsAvailable: function() {
    var type = 'localStorage'
    var storage;
    try {
        storage = window[type];
        var x = '__storage_test__';
        storage.setItem(x, x);
        storage.removeItem(x);
        return true;
    }
    catch(e) {
      return false;
      // return e instanceof DOMException && (
      //     // everything except Firefox
      //     e.code === 22 ||
      //     // Firefox
      //     e.code === 1014 ||
      //     // test name field too, because code might not be present
      //     // everything except Firefox
      //     e.name === 'QuotaExceededError' ||
      //     // Firefox
      //     e.name === 'NS_ERROR_DOM_QUOTA_REACHED') &&
      //     // acknowledge QuotaExceededError only if there's something already stored
      //     (storage && storage.length !== 0);
    }
  },

  /**
   * Store data into browser's localStorage
   * @param {string} key - index key
   * @param {string|null} value - data to be stored
   */
  localStorageSetItem: function (key, value) {
    var keyStr = Pointer_stringify(key);
    if (value == null) {
      localStorage.setItem(keyStr, null);
    }
    else {
      var valueStr = Pointer_stringify(value);
      localStorage.setItem(keyStr, valueStr);
    }
  },

  /**
   * Get data from browser's localStorage
   * @param {string} key - index key
   * @return {string|null}
   */
  localStorageGetItem: function (key) {
    var keyStr = Pointer_stringify(key);
    var returnStr = localStorage.getItem(keyStr);
    if(returnStr == null) {
      return null;
    }
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  /**
   * Delete specific data entry from browser's localStorage
   * @param {string} key - index key 
   */
  localStorageRemoveItem: function (key) {
    var keyStr = Pointer_stringify(key);
    localStorage.removeItem(keyStr);
  },

  /**
   * Clear all items from browser's localStorage
   */
  localStorageClear: function () {
    localStorage.clear();
  },

  // -- Extension methods --
  /**
   * Check if key exists
   * In order to tell the differnce between a key existing and the value just being null
   * @param {string} key - index key 
   * @return {boolean}
   */
  localStorageHasOwnProperty: function (key) {
    var keyStr = Pointer_stringify(key);
    return localStorage.hasOwnProperty(keyStr);
  }

});
