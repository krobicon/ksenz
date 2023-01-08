using System.Runtime.InteropServices;

namespace ksenz.Driver.Linux.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Iovec
    {
        public void* iov_base;
        public int iov_len;
    }
}