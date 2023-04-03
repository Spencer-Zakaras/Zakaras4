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

    public class Apple : AppStore //public class definition of Apple class with inheritence from AppStore
    {

        /********************************************************************
        *** METHOD Apple ***
        *********************************************************************
        *** DESCRIPTION : default constructor for apple class, creates apple class instance ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        public Apple() //base constructor
        {
            App app1 = new App {Name = "Final Cut Pro", Price = 54, Available = 3}; //Create new app instances to fill list
            App app2 = new App {Name = "Logic Pro", Price = 50, Available = 4};
            App app3 = new App {Name = "MainStage", Price = 46, Available = 5};
            App app4 = new App {Name = "Pixelmator Pro", Price = 57, Available = 2};

            this.Apps.Add(app1); //populate list
            this.Apps.Add(app2);
            this.Apps.Add(app3);
            this.Apps.Add(app4);
        }

        /********************************************************************
        *** METHOD Apple ***
        *********************************************************************
        *** DESCRIPTION : copy constructor for apple class, duplicates apple class instance ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/

        private Apple(Apple apple)//copy constructor
        {
            this.Apps = apple.Apps; //copy apps list

            this.Selected = apple.Selected; //copy selected integer variable

            this.Paid = apple.Paid; //copy paid integer variable
        }


        /********************************************************************
        *** METHOD WelcomeToStore ***
        *********************************************************************
        *** DESCRIPTION : this is an overriden version of the welcome to store app store method. All this method does is print a welcome to the user ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected override void WelcomeToStore() //protected overridden definition of welcometostore
        {
            Console.WriteLine("Welcome to the Apple App Store!\n\n"); //print out welcome message
        }


        /********************************************************************
        *** METHOD PayForApp ***
        *********************************************************************
        *** DESCRIPTION : this is an overriden version of the pay for app app store method. This method prompts user for money and ensures it's enough for selected app ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected override void PayForApp() //protected overridden payforapp method
        {
            string? Fives; //nullable string to hold parsed fives total

            int fives; //integer to hold total fives

            string? Tens; //nullable string to hold parsed tens total

            int tens; //integer to hold total tens

            string? Ones; //nullable string to hold parsed ones total

            int ones; //integer to hold total ones

            int total = 0; //temp var to hold running money total

            bool enough = false; //bool var to hold if total money enough

            Console.WriteLine("\nYou Choose {0}, which cost {1} Dollars.\n", Apps[Selected].Name, Apps[Selected].Price); //display to user selected app name & price
            
            Console.WriteLine("Please Enter a Combination of Ten, Five, & One Dollar Bills to Pay.\n"); //prompt user for money



            while(enough == false) //WHILE to test valid money amount
            {
                while(true) //WHILE to test valid tens input
                {
                    Console.WriteLine("How Many Tens are you Paying with:  "); //prompt for tens number

                    Tens = Console.ReadLine(); //read in tens amount

                    if(int.TryParse(Tens, out tens) && Convert.ToInt32(Tens) >= 0) //check for valid input
                    {
                        break; //break error loop
                    }

                    Console.WriteLine("Invalid Number. Please Enter an Integer Not Below 0.\n"); //display error message

                }

                while(true) //WHILE to test valid fives input
                {
                    Console.WriteLine("How Many Fives are you Paying with:  "); //prompt for fives number

                    Fives = Console.ReadLine(); //read in fives amount

                    if(int.TryParse(Fives, out fives) && Convert.ToInt32(Fives) >= 0) //check for valid input
                    {
                        break; //break error loop
                    }

                    Console.WriteLine("Invalid Number. Please Enter an Integer Not Below 0.\n"); //display error message

                }

                while(true) //WHILE to test valid ones input
                {
                    Console.WriteLine("How Many Ones are you Paying with:  "); //prompt for ones number

                    Ones = Console.ReadLine(); //read in ones amount

                    if(int.TryParse(Ones, out ones) && Convert.ToInt32(Ones) >= 0) //check for valid input
                    {
                        break; //break error loop
                    }

                    Console.WriteLine("Invalid Number. Please Enter an Integer Not Below 0.\n"); //display error message

                }

                total = (tens * 10) + (fives * 5) + (ones); //calculate total money collected

                if(total < Apps[Selected].Price) //test for valid input
                {
                    enough = false; //if not set false
                    
                    Console.WriteLine("You Entered {0} Dollars, the Price is {1}. Please Enter Enough Money to Buy the App (All Cash Returned).\n\n", total, Apps[Selected].Price); //inform user not enough money input 7 prompt for do-over
                }
                else //if enough money for selected app
                {
                    enough = true; //set true
                }

            }

            Paid = total; //set temp to paid integer variable
        }
    }