using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance; 
    }
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastname)
    {
        lastName = newLastname;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String [] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the followng options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void showBalanceOptions(cardHolder currentUser)
        {
            Console.WriteLine("Would you like to show the current balance?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
        }


        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Your current balance: " + currentUser.getBalance());
        }
        
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if the user has enough money
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient Balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you. Enjoy your money");
                //Console.WriteLine("Your remaining balance:" + currentUser.getBalance());
            }
        }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current Balance " + currentUser.getBalance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("1234567890111111", 1234, "John", "Griffin", 200));
            cardHolders.Add(new cardHolder("1212121212111111", 5454, "Cath", "Long", 211));
            cardHolders.Add(new cardHolder("6041724789111111", 6666, "Lala", "Suryadi", 500));
            cardHolders.Add(new cardHolder("6894386944111111", 0000, "Casian", "Master", 70));

            //prompt user
            Console.WriteLine("Welcome to ATM");
            Console.WriteLine("Please insert your debit card: ");
            String debitCardNum = "";
            cardHolder currentUser;

            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    //check agains our db
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if(currentUser != null) {break;}
                    else{Console.WriteLine("Card not recognize. Please Try Again");}
                }
                catch
                {
                    Console.WriteLine("Card not recognize. Please Try Again");
                }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while(true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if(currentUser.getPin()== userPin) {break;}
                    else{Console.WriteLine("Incorrect pin number");}
                }
                catch
                {
                    Console.WriteLine("Incorrect pin number");
                }
            }

            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;
            int options = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch{}
                if(option == 1) 
                {
                    deposit(currentUser);
                }
                else if(option == 2)
                {
                    withdraw(currentUser);
                    while(true)
                    {
                        showBalanceOptions(currentUser);
                        try
                        {
                            options = int.Parse(Console.ReadLine());
                        }
                        catch{}
                        if(options == 1)
                        {
                            Console.WriteLine("Thank you for your deposit. Your New Balance is: " + currentUser.getBalance());
                            break;
                        }
                        else if(options == 2)
                        {
                            break;
                        }
                    }

                }
                else if(option == 3)
                {
                    balance(currentUser);
                }
                else if(option == 4)
                {
                    break;
                }
                else {
                    option = 0; 
                }
                
            }
            while(option != 4);
            Console.WriteLine("Thank you! Have a nice day");
        
    }
}
