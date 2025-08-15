using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace A3MOD
{
    public class A3MOD
    {
        public static UdpClient UdpClient = new UdpClient();
        public static IPEndPoint SourceEndpoint = new IPEndPoint(IPAddress.Loopback, 12345);
        public static StreamWriter Log = new StreamWriter("C:\\Users\\Public\\Documents\\A3MOD.log", true);
        /// <summary>
        /// Gets called when Arma starts up and loads all extension.
        /// It's perfect to load in static objects in a separate thread so that the extension doesn't needs any separate initalization
        /// </summary>
        /// <param name="output">The string builder object that contains the result of the function</param>
        /// <param name="outputSize">The maximum size of bytes that can be returned</param>
		[DllExport("RVExtensionVersion", CallingConvention = CallingConvention.Winapi)]
        public static void RvExtensionVersion(StringBuilder output, uint outputSize)
        {
            Log.WriteLine("Initialized.");
            output.Append("A32TAK Helper");
        }

        /// <summary>
        /// The entry point for the default callExtension command.
        /// </summary>
        /// <param name="output">The string builder object that contains the result of the function</param>
        /// <param name="outputSize">The maximum size of bytes that can be returned</param>
        /// <param name="function">The string argument that is used along with callExtension</param>
		[DllExport("RVExtension", CallingConvention = CallingConvention.Winapi)]
        public static void RvExtension(StringBuilder output, uint outputSize, [MarshalAs(UnmanagedType.LPStr)] string function)
        {
            Log.WriteLine(function);
            if (function == ":READY:")
            {
                output.Append("OK");
            }
        }

        /// <summary>
        /// The entry point for the callExtensionArgs command.
        /// </summary>
        /// <param name="output">The string builder object that contains the result of the function</param>
        /// <param name="outputSize">The maximum size of bytes that can be returned</param>
        /// <param name="function">The string argument that is used along with callExtension</param>
        /// <param name="args">The args passed to callExtension as a string array</param>
        /// <param name="argsCount">The size of the string array args</param>
        /// <returns>The result code</returns>
        ///
		[DllExport("RVExtensionArgs", CallingConvention = CallingConvention.Winapi)]
        public static int RvExtensionArgs(
            StringBuilder output, 
            uint outputSize, 
            [MarshalAs(UnmanagedType.LPStr)] string function,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 4)] string[] args,
            uint argCount
        )
        {
            Log.WriteLine(function + ": " + string.Join("; ", args));
            if (
                (
                    function == "send" ||
                    function == ":POS:"
                ) && 
                argCount == 1
            ) {
                UdpClient.Send(Encoding.ASCII.GetBytes(args[0]), Encoding.ASCII.GetByteCount(args[0]), SourceEndpoint);
            }
            return 0;
        }
    }
}