using System.Collections.Generic;

namespace Payments.Tests.FakeData
{
    public static class CPFProvider
    {
        public static List<string> ValidCPFs() {
            return new List<string> {
                "755.865.370-36",
                "737.354.690-00"
            };
        }
        public static List<string> InvalidCPFs() {
            return new List<string> {
                "546.484.899-82",
                "123.466.789-52"
            };
        }
    }
}