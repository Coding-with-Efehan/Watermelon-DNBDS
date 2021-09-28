using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Watermelon.Models
{
    public static class Serialize
    {
        public static string ToJson(this Event self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
