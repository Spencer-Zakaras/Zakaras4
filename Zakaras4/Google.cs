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

    public class Google : AppStore //public google class w/inheritence from AppStore Class
    {


        /********************************************************************
        *** METHOD Google ***
        *********************************************************************
        *** DESCRIPTION : default constructor for google class, creates google class instance ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        public Google() //base constructor
        {
            App app1 = new App {Name = "Cubasis 3", Price = 46, Available = 3}; //create new app classes
            App app2 = new App {Name = "FL Studio Mobile", Price = 50, Available = 5};
            App app3 = new App {Name = "LumaFusion Pro", Price = 57, Available = 1};

            this.Apps.Add(app1); //add new "apps" to list
            this.Apps.Add(app2);
            this.Apps.Add(app3);
        }

        /********************************************************************
        *** METHOD Google ***
        *********************************************************************
        *** DESCRIPTION : copy constructor for google class, duplicates google class instance ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        private Google(Google google)//copy constructor
        {
            this.Apps = google.Apps; //copy apps list

            this.Selected = google.Selected; //copy selected field

            this.Paid = google.Paid; //copy paid field
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
        protected override void WelcomeToStore() //overridden welcome to store method
        {
            Console.WriteLine("Welcome to the Google App Store!\n\n"); //prompt welcoming user to store
        }

        /********************************************************************
        *** METHOD ReturnChange ***
        *********************************************************************
        *** DESCRIPTION : This is an overriden version of the AppStore return change method. This protected method calculates change and displays that to the total  ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        protected override void ReturnChange() //overriden Return Change Method
        {
            int totalChange; //total change integer variable

            totalChange = Apps[Selected].Price - Paid; //calculate total change

            int fives = Math.Abs(totalChange / 5); //calculate total five dollar bills
            totalChange = Math.Abs(totalChange % 5); //remove fives
            int twos = Math.Abs(totalChange / 2); //calculate total two dollar bills
            totalChange = Math.Abs(totalChange % 2); //remove twos
            int ones = totalChange; //calculate total ones

            Console.WriteLine($"Your Change is {fives} fives. \n{twos} Twos.\n{ones} Ones. \n \n"); //inform user of change received
        }
    }