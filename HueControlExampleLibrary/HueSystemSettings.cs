using System;

namespace HueControlExampleLibrary
{
    public class HueSystemSettings
    {
        public string IpAddress { get; set; }
        public Byte? Brightness { get; set; }
        public string Color { get; set; }
        public bool? On { get; set; }
        public bool? Off { get; set; }
        public string[] Light { get; set; }
        public string Key { get; set; }
        public string Register { get; set; }
        public bool? Status { get; set; }
    }
}
