﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SiGas.Interfaces
{
    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
