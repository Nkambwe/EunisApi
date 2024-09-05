using System.ComponentModel;

namespace Eunis.Enums {
    public enum AccountType {
        [Description("Unknown Account type")]
        None = 0,
        [Description("Savings Account")]
        Savings = 1,
        [Description("Current Account")]
        Chequeing = 2,
        [Description("Fixed Deposit Account")]
        Fixed = 3,
        [Description("Security Trading Account")]
        Trading = 4,
        [Description("Share Premium Account")]
        Shares = 5
    }

    public enum EmploymentType {
        [Description("Undefined")]
        None = 0,
        [Description("Self Employed")]
        Self = 1,
        [Description("Private Employee")]
        Private = 2,
        [Description("Public Servant")]
        Public = 3,
        [Description("Retired")]
        Retired = 4
    }
}
