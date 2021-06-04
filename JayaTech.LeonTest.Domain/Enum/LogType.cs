using System;
using System.Collections.Generic;
using System.Text;

namespace JayaTech.LeonTest.Domain.Enum
{
    public enum LogType
    {
        LoginSuccess = 1,
        LoginFailed = 2,
        TransactionSuccess = 3,
        TransactionFailed = 4,
        ExchangeApiCallDuration = 5,
        Exception = 6,
        ApiCall = 7,
        ApiCallError = 8
    }
}