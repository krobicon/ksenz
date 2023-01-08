﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using ksenz.Core.Interfaces;

namespace ksenz.Core.Types
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class UInt16Type : IType<ushort>
    {
        public static readonly UInt16Type Instance = new();

        #region Constructors

        private UInt16Type()
        {
        }

        #endregion

        #region Implementation of IType<ushort>

        public ushort Get(byte[] buffer)
        {
            return Unsafe.ReadUnaligned<ushort>(ref buffer[0]);
        }

        public void Set(byte[] buffer, ushort value)
        {
            Unsafe.As<byte, ushort>(ref buffer[0]) = value;
        }

        public int Size()
        {
            return sizeof(ushort);
        }

        #endregion
    }
}