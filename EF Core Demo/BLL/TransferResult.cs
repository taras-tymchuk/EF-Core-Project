using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Demo.BLL
{
    public class TransferResult
    {
        public ErrorCodeEnum errorCode { get; set; }

        public TransferResult()
        {
            errorCode = ErrorCodeEnum.Succeded;
        }
    }

    public enum ErrorCodeEnum
    {
        Succeded, NotFoundPlayer, NotFoundTeam, DuplicatePlayer
    }
}
