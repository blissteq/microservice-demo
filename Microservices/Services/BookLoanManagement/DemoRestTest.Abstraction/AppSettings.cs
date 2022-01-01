using System;
using System.Collections.Generic;
using System.Text;

namespace DemoRestTest.Abstraction
{
 public   class AppSettings
    {
        public string VirtualDirectory { get; set; }

        public string MongoServerName { get; set; }

        public string MongoDatabaseName { get; set; }
    }
}
