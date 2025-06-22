using Microsoft.JSInterop;

namespace YumBlazor.Services.Extensions
{
    public static class IJSRuntimeExtensions
    {
        public static async Task ToastrSuccess(this IJSRuntime runtime, string message)
            => await runtime.InvokeVoidAsync("showToastr", ToastrConstants.Success, message);

        public static async Task ToastrError(this IJSRuntime runtime, string message) 
            => await runtime.InvokeVoidAsync("showToastr", ToastrConstants.Error, message);

        public static async Task ToastrInfo(this IJSRuntime runtime, string message) 
            => await runtime.InvokeVoidAsync("showToastr", ToastrConstants.Info, message);

        public static async Task ToastrWarning(this IJSRuntime runtime, string message) 
            => await runtime.InvokeVoidAsync("showToastr", ToastrConstants.Warning, message);

        public static async Task Toastr(this IJSRuntime runtime, string type, string message) 
            => await runtime.InvokeVoidAsync("showToastr", type, message);
    }

    public static class ToastrConstants
    {
        public const string Success = "success";
        public const string Error = "error";
        public const string Info = "info";
        public const string Warning = "warning";
    }
}
