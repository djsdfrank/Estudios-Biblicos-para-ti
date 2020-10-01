using System;
using Android.Webkit;
using Java.Interop;
using EstudiosBiblicos.Droid.Views;
using EstudiosBiblicos.Helpers;

namespace EstudiosBiblicos.Droid.Helpers
{
    public class JSBridge : Java.Lang.Object
    {
        readonly WeakReference<HybridWebViewRenderer> hybridWebViewRenderer;

        public JSBridge(HybridWebViewRenderer hybridRenderer)
        {
            hybridWebViewRenderer = new WeakReference<HybridWebViewRenderer>(hybridRenderer);
        }

        [JavascriptInterface]
        [Export("invokeAction")]
        public void InvokeAction(string data)
        {
            try
            {
                HybridWebViewRenderer hybridRenderer;
                if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget(out hybridRenderer))
                {
                    hybridRenderer.Element.InvokeAction(data);
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Error($"JSBridge::InvokeAction exception, {ex.Message}");
            }
        }
    }
}

