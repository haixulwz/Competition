﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Competition.Tools
{
   public static class ServiceLocator
    {
        public static IServiceProvider Instance { get; set; }
    }
}
