using System.ComponentModel;

namespace Eunis.Enums {
    public enum TransactionType {
        [Description("Account Enquiry")]
        Enquiry = 0,
        [Description("Cash Deposit")]
        Deposit = 1,
        [Description("Cash Withdraw")]
        Withdrawal = 2
    }
}
