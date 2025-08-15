using RGiesecke.DllExport;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace A3MOD
{
    public static class A3MOD
    {
        public static UdpClient UdpClient = new UdpClient();
        public static IPEndPoint SourceEndpoint = new IPEndPoint(IPAddress.Loopback, 12345);
        /// <summary>
        /// Gets called when Arma starts up and loads all extension.
        /// It's perfect to load in static objects in a separate thread so that the extension doesn't needs any separate initalization
        /// </summary>
        /// <param name="output">The string builder object that contains the result of the function</param>
        /// <param name="outputSize">The maximum size of bytes that can be returned</param>
#if WIN64
    [DllExport("RVExtensionVersion", CallingConvention = CallingConvention.Winapi)]
#else
        [DllExport("_RVExtensionVersion@8", CallingConvention = CallingConvention.Winapi)]
#endif
        public static void RvExtensionVersion(StringBuilder output, uint outputSize)
        {
            output.Append("A32TAK Helper");
        }

        /// <summary>
        /// The entry point for the default callExtension command.
        /// </summary>
        /// <param name="output">The string builder object that contains the result of the function</param>
        /// <param name="outputSize">The maximum size of bytes that can be returned</param>
        /// <param name="function">The string argument that is used along with callExtension</param>
#if WIN64
    [DllExport("RVExtension", CallingConvention = CallingConvention.Winapi)]
#else
        [DllExport("_RVExtension@12", CallingConvention = CallingConvention.Winapi)]
#endif
        public static void RvExtension(StringBuilder output, uint outputSize, [MarshalAs(UnmanagedType.LPStr)] string function) { }

        /// <summary>
        /// The entry point for the callExtensionArgs command.
        /// </summary>
        /// <param name="output">The string builder object that contains the result of the function</param>
        /// <param name="outputSize">The maximum size of bytes that can be returned</param>
        /// <param name="function">The string argument that is used along with callExtension</param>
        /// <param name="args">The args passed to callExtension as a string array</param>
        /// <param name="argsCount">The size of the string array args</param>
        /// <returns>The result code</returns>
#if WIN64
    [DllExport("RVExtensionArgs", CallingConvention = CallingConvention.Winapi)]
#else
    [DllExport("_RVExtensionArgs@20", CallingConvention = CallingConvention.Winapi)]
#endif
        public static int RvExtensionArgs(
            StringBuilder output, 
            uint outputSize, 
            [MarshalAs(UnmanagedType.LPStr)] string function,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 4)] string[] args,
            uint argCount
        )
        {
            if (function == "send" && argCount == 1)
            {
                UdpClient.Send(Encoding.ASCII.GetBytes(args[0]), Encoding.ASCII.GetByteCount(args[0]), SourceEndpoint);
            }
            return 0;
        }
    }
}