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
            
            Console.WriteLine("Amount deposited");
            

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
        private int customerId;
        private string name;
        private int phoneNumber;
        private int accountNumber;
        private int balance;
        
        public int CustomerId { get { return customerId; } set { customerId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int PhoneNumber { get { return phoneNumber; } set { this.phoneNumber = value; } }
        public int AccountNumber { get { return accountNumber; } set { accountNumber = value; } }


        public int Balance {
            get { return this.balance; }
            set {
                if (value > 0)
                {
                    this.balance = value;
                }
                else
                {
                    Console.WriteLine("Balance should not negative"); ;
                }
            }
        }

    }
    
}
