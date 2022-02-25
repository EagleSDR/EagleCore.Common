﻿using EagleWeb.Common.IO.FileSystem;
using EagleWeb.Common.IO.Sockets;
using EagleWeb.Common.Radio;
using System;
using System.Collections.Generic;
using System.Text;

namespace EagleWeb.Common
{
    /// <summary>
    /// Context to the Eagle server.
    /// </summary>
    public interface IEagleContext
    {
        int BufferSize { get; }
        IEagleRadio Radio { get; }

        WebFsFileStream ResolveFileToken(string token);
    }
}