using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32;

namespace uk.JohnCook.dotnet.SleepyWindows.Utils
{
    public class ErrorUtils
    {
        /// <summary>
        /// Check a <see cref="Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR"/> is <see cref="Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR.ERROR_SUCCESS"/>.
        /// </summary>
        /// <param name="win32ErrorCode">A <see cref="Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR"/>.</param>
        /// <returns>True if <paramref name="win32ErrorCode"/> equals <see cref="Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR.ERROR_SUCCESS"/>, otherwise false.</returns>
        public static bool IsSuccess(uint win32ErrorCode)
        {
            return (Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR)win32ErrorCode == Windows.Win32.System.Diagnostics.Debug.WIN32_ERROR.ERROR_SUCCESS;
        }

        /// <summary>
        /// Check a <see cref="Windows.Win32.Foundation.NTSTATUS"/> is <see cref="Constants.STATUS_SUCCESS"/>.
        /// </summary>
        /// <param name="hresult">A <see cref="Windows.Win32.Foundation.NTSTATUS"/>.</param>
        /// <returns>True if <paramref name="hresult"/> equals <see cref="Constants.STATUS_SUCCESS"/>, otherwise false.</returns>
        public static bool IsSuccess(int hresult)
        {
            return (Windows.Win32.Foundation.NTSTATUS)hresult == Constants.STATUS_SUCCESS;
        }
    }
}
