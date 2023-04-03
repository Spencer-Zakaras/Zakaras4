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

    public class App //definition of public app class
    {
        public string Name{set; get;} //name string property

        public int Price{set;get;} //price integer property

        public int Available{set;get;} //available integer property


        /********************************************************************
        *** METHOD App ***
        *********************************************************************
        *** DESCRIPTION : default constructor for app class, creates app class instance ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        public App(string name = "", int price = 0, int available = 0) //default constructor
        {
            Name = name; //set name
            Price = price; //set price
            Available = available; //set available
        }

        /********************************************************************
        *** METHOD App ***
        *********************************************************************
        *** DESCRIPTION : copy constructor for app class, this duplicates a app method exactly ***
        *** INPUT ARGS : N/A ***
        *** OUTPUT ARGS : N/A ***
        *** IN/OUT ARGS : N/A ***
        *** RETURN : N/A ***
        ********************************************************************/
        public App(App original) //copy constructor
        {
            Name = original.Name; // copy name
            Price = original.Price; // copy price
            Available = original.Available; // copy available
        }
    }