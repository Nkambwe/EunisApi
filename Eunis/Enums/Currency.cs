using System.ComponentModel;

namespace Eunis.Enums {

    public enum Currency {
        [Description("Undefined currency")]
        Unknown = 0,

        [Description("United States dollar")]
        USD = 840,

        [Description("Pound sterling")]
        GBP = 826,

        [Description("Euro")]
        EUR = 978,

        [Description("Kenyan Shilling")]
        KYS = 356,

        [Description("Ugandan Shilling")]
        UGX = 491
    }
}
