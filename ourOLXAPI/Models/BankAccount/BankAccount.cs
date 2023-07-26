using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ourOLXAPI.Models
{
    public class BankAccountResponse
    {
        public bool IsActive { get; set; }
        public string Message { get; set; }
        public BankAccount Result { get; set; }
    }


    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public int Balance { get; set; }
        public AccountType AccountType { get; set; }
        
    }
   
        public enum AccountType
    {
        Savings,
        Checking,
        Investment    
    }
}
