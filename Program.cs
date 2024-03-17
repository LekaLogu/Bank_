namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(1001, "Manager", 1234);
            Teller teller1 = new Teller(1002, "Teller1", 123456);
            Console.WriteLine("Hello, Welcome to the Bank!");
            Customer customer1 = new Customer()
            {
                CustomerId = 1,
                Name = "Test",
                AccountNumber = 1,
                Balance = 1000,
                PhoneNumber = 123,
            };

            teller1.FetchCustomerDetails(customer1);
            teller1.DepositAmount(customer1, 100);
            //Console.WriteLine($"Balance:{customer1.Balance}");

        }
    }
    public abstract class BankEmployee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public abstract void FetchCustomerDetails(Customer obj);

    }
    public class Teller : BankEmployee
    {

        public Teller(int employeeId, string name, int phoneNumber)
        {
            this.EmployeeId = employeeId;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public void DepositAmount(Customer obj, int amount)
        {
            obj.Balance += amount;
            Transaction trans=new Transaction(DateTime.Now,obj.CustomerId,"Deposit",amount,obj.Balance);
            Console.WriteLine("Amount deposited");
            trans.DisplayTransactionDetails();

        }
        public void WithdrawAmount(Customer obj, int amount)
        {
            if (obj.Balance >= amount)
            {
                obj.Balance -= amount;
                Transaction trans=new Transaction(DateTime.Now,obj.CustomerId,"Withdraw",amount,obj.Balance);
                Console.WriteLine("Amount Withdrawn");
            }
            else
            {
                Console.WriteLine("Not enough Balance");
            }
        }
        public override void FetchCustomerDetails(Customer obj)
        {
            Console.WriteLine($"Customer Name :{obj.Name},Phone Number: {obj.PhoneNumber}");

        }


    }
    public class Manager : BankEmployee
    {
        public Manager(int employeeId, string name, int phoneNumber)
        {
            this.EmployeeId = employeeId;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }
        public override void FetchCustomerDetails(Customer obj)
        {
            Console.WriteLine($"Customer Name :{obj.Name},Phone Number: {obj.PhoneNumber}, Customer ID: {obj.CustomerId}");

        }
        public void CheckEmployeeDetails(Teller obj)
        {
            Console.WriteLine($"Teller Name :{obj.Name},Phone Number: {obj.PhoneNumber}, Employee ID: {obj.EmployeeId}");
        }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public int AccountNumber { get; set; }
        public int Balance { get; set; }
        
        public int CheckBalance()
        {
            return Balance;
        }

    }
    public class Transaction
    {
        public  int TransactionId {  get; set; }
        public DateTime DateOfTransfer { get; set; }
        public int CustomerID { get; set; }
        public string TransactionType { get; set; }
        public int TransactionAmount { get; set; }
        public int Balance { get; set; }
        public Transaction( DateTime dateOfTransfer, int customerID, string transactionType, int transactionAmount, int balance)
        {
            this.DateOfTransfer = dateOfTransfer;
            this.CustomerID = customerID;
            this.TransactionType = transactionType;
            this.TransactionAmount = transactionAmount;
            this.Balance = balance;
            TransactionId++;
        }
        public void DisplayTransactionDetails()
        {
            Console.WriteLine($"DateOfTransfer: {this.DateOfTransfer},CustomerID: {this.CustomerID},TransactionType: {this.TransactionType},TransactionAmount:{this.TransactionAmount},Balance: {this.Balance}");
        }
    }
}
