using System;
using System.Collections.Generic;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class ServiceResponse
    {
        public bool Success { get; private set; } = false;
        public object Data { get; private set; }
        public int StatusCode { get; private set; }

        public void OnSuccessSave(object data)
        {
            this.Success = true;
            this.Data = data;
            this.StatusCode = 201;
        }

        public void OnSuccessGet(object data)
        {
            this.Success = true;
            this.Data = data;
            this.StatusCode = 200;
        }
    }
}
