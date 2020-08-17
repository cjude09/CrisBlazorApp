using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CrisBlazorApp.Business
{
    public class StorageHelper
    {
        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        public static void LoadJS(IJSRuntime jsRuntime)
        {
            jsRuntime.InvokeVoidAsync(
                "eval",
                 @"(function() {
                        let scripts = document.getElementsByTagName('script');
                        let exists = false;
                        let index = 0;

                        while (index < scripts.length && !exists)
                        {
                            exists = scripts[index].src.endsWith('_content/CrisBlazorApp.Business/storageHelper.js');
                            index++;
                        }

                        if (!exists)
                        {
                            document.body.appendChild(
                                Object.assign(
                                    document.createElement('script'), {
                            src: '_content/CrisBlazorApp.Business/storageHelper.js',
                                type: 'text/javascript'
                                    }));
                        }
                    })()");
        }

        public static ValueTask<string> Prompt(IJSRuntime jsRuntime, string message)
        {
            // Implemented in exampleJsInterop.js
            return jsRuntime.InvokeAsync<string>(
                "storageHelper.showPrompt",
                message);
        }

        public async static Task<string> ReadStorageAsync(IJSRuntime jsRuntime, string key)
        {
            return await jsRuntime.InvokeAsync<string>("storageHelper.ReadStorage", key);
        }

        public async static Task WriteStorageAsync(IJSRuntime jsRuntime, string key, string value)
        {
            var test = await jsRuntime.InvokeAsync<object>("storageHelper.WriteStorage", key, value);
        }
    }
}
