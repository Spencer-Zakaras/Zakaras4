/********************************************************************
*** NAME : Spencer Zakaras ***
*** CLASS : CSc 346 ***
*** ASSIGNMENT : 4 ***
*** DUE DATE : 4/3/23 ***
*** INSTRUCTOR : GAMRADT ***
*********************************************************************
*** DESCRIPTION : This assignment is an app store program. This program lets a user select an app store and buy & download an app on that specific store ***
********************************************************************/

namespace AppStoreNS; //shared namespace

    public abstract class AppStore //public abstract definition of the AppStore class
    {
        protected List<App> Apps = new List<App>(); //protected list of App objects

        protected int Selected; //protected integer selected variable

        protected int Paid; //protected integer paid variable

        /********************************************************************
        *** METHOD AppStore ***
        *********************************************************************
        *** DESCRIPTION : default constructor for private AppStore class, creates AppStore class instance ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        public AppStore() //base constructor
        {
            
        }

        /********************************************************************
        *** METHOD AppStore ***
        *********************************************************************
        *** DESCRIPTION : copy constructor for private AppStore class, duplicate AppStore class instance ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        private AppStore(AppStore ApStore) //copy constructor
        {
            Apps = ApStore.Apps; //copy app list
            Selected = ApStore.Selected; //copy selected integer var
            Paid = ApStore.Paid; //copy paid integer var
        }

        /********************************************************************
        *** METHOD PurchaseApp ***
        *********************************************************************
        *** DESCRIPTION : app store algorithm that runs all protected methods to function app store ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        public void PurchaseApp() //purchase app public definition
        {
            WelcomeToStore(); //Welcome to Store method call
            SelectApp(); //Select app method call
            PayForApp(); //Pay for app method call
            ReturnChange(); //return change method call
            DownloadApp(); //download app method call
        }

        /********************************************************************
        *** METHOD WelcomeToStore ***
        *********************************************************************
        *** DESCRIPTION : welcome to store abstract protected definition ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected abstract void WelcomeToStore(); //define welcome to store method


        /********************************************************************
        *** METHOD SelectApp ***
        *********************************************************************
        *** DESCRIPTION : Select App method, displays apps and prompts user for choice of app ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected void SelectApp() //select app protected method definitions
        {
            int choosen; //integer choice variable

            int num = 0; //number counter for list indexer

            foreach(App AppItem in Apps) //FOREACH loop to index through and print out list objects 
            {
                Console.WriteLine("{0}. Name: {1} | Price: {2} | Available Licenses: {3}\n", num, AppItem.Name, AppItem.Price, AppItem.Available); //print out entire list elemnt properties
                num = ++num; //increment indexer
            }

            Console.WriteLine("Please enter the number of the app you want to purchase: "); //prompt user for app selection from list

            choosen = Convert.ToInt32(Console.ReadLine()); //read in & convert to integer user input

            while( choosen < 0 || (Apps.Count - 1) < choosen || Apps[choosen].Available <= 0) //WHILE error conditions loop
            {
                Console.WriteLine("Invalid App Selection, Try Again: "); //prompt user for new selection due to invalidity

                choosen = Convert.ToInt32(Console.ReadLine()); //read in & convert from string to int user input
            }
            
            Apps[choosen].Available = --Apps[choosen].Available; //decrement available quantity of app

            Selected = choosen; //read temp into selected variable

            
        }

        /********************************************************************
        *** METHOD PayForApp ***
        *********************************************************************
        *** DESCRIPTION : pay for app method, prompts user for enough money to pay for app. ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected virtual void PayForApp() //protected virtual definition of pay for app method
        {
            string? Twenties; //string temp var for twenties

            int twenties; //int to hold twenties total

            string? Tens; //string temp var for tens

            int tens; //int to hold tens total

            int total = 0; //int temp var for total

            bool enough = false; //enough money total bool loop var

            Console.WriteLine("\nYou Choose {0}, which cost {1} Dollars.\n", Apps[Selected].Name, Apps[Selected].Price); //display selected app name and price
            
            Console.WriteLine("Please Enter a Combination of Ten and Twenty Dollar Bills to Pay.\n"); //prompt user for combonation of money that meets/exceedes cost



            while(enough == false) //WHILE test loop for valid total input
            {
                while(true) //WHILE test loop for valid twenties input
                {
                    Console.WriteLine("How Many Twenties are you Paying with:  "); //prompt user for twenties quantity

                    Twenties = Console.ReadLine(); //read in twenties total

                    if(int.TryParse(Twenties, out twenties) && Convert.ToInt32(Twenties) >= 0) //attempt to read in input & test validity
                    {
                        break; //break Error loop
                    }

                    Console.WriteLine("Invalid Number. Please Enter an Integer Not Below 0.\n"); //ERROR prompt for valid input

                }

                while(true) //WHILE test loop for valid tens input
                {
                    Console.WriteLine("How Many Tens are you Paying with:  "); //prompt user for tens quantity

                    Tens = Console.ReadLine(); //read in tens total

                    if(int.TryParse(Tens, out tens) && Convert.ToInt32(Tens) >= 0) //attempt to read in input & test validity
                    {
                        break; //break Error loop
                    }

                    Console.WriteLine("Invalid Number. Please Enter an Integer Not Below 0.\n"); //ERROR prompt for valid input


                }

                total = (twenties * 20) + (tens * 10); //Calculate total payment

                if(total < Apps[Selected].Price) //test if meets price threshold
                {
                    enough = false; //if not set false
                    
                    Console.WriteLine("You Entered {0} Dollars, the Price is {1}. Please Enter Enough Money to Buy the App (All Cash Returned).\n\n", total, Apps[Selected].Price); //error out not enough cash prompt for reattempt
                }
                else //if enough
                {
                    enough = true; //set true
                }

            }

            Paid = total; //set paid to temp total val
        }

        /********************************************************************
        *** METHOD ReturnChange ***
        *********************************************************************
        *** DESCRIPTION : calculate and display total change ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected virtual void ReturnChange() //protected virtual return change method definition
        {
            int totalChange; //temp total change var

            totalChange = Apps[Selected].Price - Paid; //calculate total change to return

            int tens = Math.Abs(totalChange / 10); //calculate tens total
            int ones = Math.Abs(totalChange % 10); //calculate ones total

            Console.WriteLine($"Your Change is {tens} ten(s) \n{ones} one(s).\n\n"); //display change
        }

        /********************************************************************
        *** METHOD DownloadApp ***
        *********************************************************************
        *** DESCRIPTION : downloading prompt ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected void DownloadApp() //protected download app method definition
        {
            Console.WriteLine("Thank you for using the App Store! Your app is downloading.\n\n"); //print exit & downloading prompt
        }
    }