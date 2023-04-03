/********************************************************************
*** NAME : Spencer Zakaras ***
*** CLASS : CSc 346 ***
*** ASSIGNMENT : 4 ***
*** DUE DATE : 4/3/23 ***
*** INSTRUCTOR : GAMRADT ***
*********************************************************************
*** DESCRIPTION : This assignment is an app store program. This program lets a user select an app store and buy & download an app on that specific store ***
********************************************************************/

using AppStoreNS; //using shared namespace

Apple appl = new Apple(); //create apple app store object

Google ggl = new Google(); //create a google app store object

bool continu = true; //a bool to hold onto the choice to continue buying apps

int select; //holds user choice of store/exit

while(continu == true) //continue WHILE user chooses to
{
    Console.WriteLine("Please Select an App Store:\n1. Apple\n2. Google\n3. Exit\n"); //print out menu

    select = Convert.ToInt32(Console.ReadLine()); //convert string from readLine to int & store

    while(select <= 0 || select > 3) //loop WHILE error input continues
    {
        Console.WriteLine("ERROR! Invalid App Store Selection! Try Again: "); //Error & re-try prompt

        select = Convert.ToInt32(Console.ReadLine()); //convert string from readLine to int & store
    }

    if(select == 1) //go to Apple store
            appl.PurchaseApp(); //open apple app store algorithm

    else if(select == 2) //go to google apple store
        ggl.PurchaseApp(); //open google app store algorithm

    else //exit program
        continu = false; //set continue WHILE loop to false

    
}

