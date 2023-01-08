﻿using popos.Core.Interfaces;
using popos.Driver.Interfaces;

namespace popos.Core.Extensions
{
    public static class DriverExtensions
    {
        #region Statics

        public static Access<T> Access<T>(this IDriver driver, ulong address, IType<T> type)
        {
            return new Access<T>(driver, address, type);
        }

        public static Access<T> Access<T>(this IDriver driver, ulong address, IType<T> type, uint interval)
        {
            return new Access<T>(driver, address, type, interval);
        }

        #endregion
    }
}
