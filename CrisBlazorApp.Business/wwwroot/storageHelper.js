// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.storageHelper = {
    showPrompt: function (message) {
        return prompt(message, 'Type anything here');
    },

    ReadStorage: function (key) {
        return localStorage.getItem(key);
    },

    WriteStorage: function (key, value) {
        localStorage.setItem(key, value);
    }
};