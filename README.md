# <img src="ScreenShots/Logo.png" alt="MKM Logo" width="70" height="70"> Virtual Wallet
Transfer money quick, safe, and free

# <img src="ScreenShots/Wallet_Intro_3s.gif" alt="MKM Intro" width="600" height="314">

## Walkthrough

Virtual Wallet MaxKashMate is a web-based application designed to empower users in efficiently managing their finances. The platform offers essential functionalities, including the ability to send and receive money between users and to facilitate deposits from a bank into the application's wallet, and vice versa.

The chosen name, "MaxKashMate," holds a special place in our project's heart. This name isn't just a random selection; it's been carefully crafted to perfectly align with the app's purpose while paying a friendly tribute to the names of its developers. You might notice a playful twist with intentional misspelling, which adds a touch of creativity and fun to the name. This way, we aim to make the app not only well-developed, but also to bring a smile to your face every time you use it.
<br>
<br>
<hr>

### Public Part<br>

> The public section doesn't require authentication and showcases a self-rotating carousel featuring product advertisements, along with buttons for both Login and Registration.<br>
Anonymous users need to either register or login to begin using the app.
<br>
<hr>

### Private Part<br>
##### Registration and confirmation <br>

> Upon successful user registration, the system will send a confirmation email to verify the user's email address. When the user clicks on the link within the email, the system will redirect them back to our website, allowing them to log in. Users who have not completed email verification are not considered registered.<br>
Users who successfully log in are automatically redirected to a welcome page, where they can immediately start using the app.
<br>
<details><summary>Additional details for registration</summary>

• Username <br>
    o Must be at least 2 characters long<br>
    o Maximum of 20 characters long<br>
    o Mandatory and cannot be edited<br>
    o Must be unique within the system<br>

• Email <br>
    o Required and can be changed<br>
    o Must be unique within the system<br>
    o Email format verification (regex)<br>

• Phone Number <br>
    o Required and can be changed<br>
    o Must be exactly 10 digits<br>

• First Name <br>
    o Not required and can be changed<br>
    o Maximum of 20 characters long<br>

• Last Name <br>
    o Not required and can be changed<br>
    o Maximum of 20 characters long<br>

• Password <br>
    o Required and can be changed<br>
    o Must be at least 8 characters long<br>
    o Maximum of 20 characters long<br>
    o Must include uppercase and lowercase character<br>
    o Must include digit and symbol<br>
    o NB! Provided password is not recorded in the database directly<br>

• Confirm Password <br>
    o Must match the Password<br>

# <img src="ScreenShots/Register.png" alt="Register" style="width: 80%; height: auto;">

</details>

<details><summary>Additional details for Login</summary>

• Username <br>
• Password <br>

# <img src="ScreenShots/Login.png" alt="Login" style="width: 80%; height: auto;">

</details>
<hr>


##### There are two user roles in the system: "user" and "administrator". <br>

##### Users <br>
> Registered users have access to their user profile page, where they can view the information provided during registration.<br>
Users can upload a profile image, update their email, phone number, first and last name, and password.<br>
The requirements for modifying a field are identical to those of the registration form. <br>
Each page displays the current field value, and changing the password necessitates inputting the current password.

# <img src="ScreenShots/User.png" alt="User" style="width: 80%; height: auto;">

##### Wallets <br>
> The most vital aspect of the app is the user wallet. This is where users store their money. After successful registration, each user must add a wallet to their account.<br>
This can be done by clicking on the "My Wallet" button. If the user doesn't have a wallet, "Create Wallet" button will appear. <br>
Users must select the currency for the wallet—BGN, EUR, or USD.<br>
Once created, the wallet will be showcased on the info page.<br>
Users can view their wallet details, where they can update or remove the wallet.<br>
The "Update wallet" option allows users to change the wallet's currency.<br>
Note: Updating the wallet currency will automatically recalculate the balance based on real-time exchange rates.

# <img src="ScreenShots/Wallets.png" alt="Wallets" style="width: 80%; height: auto;">

##### Right side panel <br>
> For an enhanced user experience, the app features two persistent panels on the right side of every page.<br>
The first panel displays the current wallet balance and its corresponding currency.<br>
The second panel houses a currency converter that offers real-time calculations for currency exchange rates.

# <img src="ScreenShots/Right_Side.png" alt="Right_Side_Panel" style="width: 20%; height: auto;">

##### Cards <br>
> Another essential feature for a completed account is the user's cards.<br>
To view their cards or add a new one, users should navigate to the "My Cards" section, where all cards associated with the user will be showcased.<br>
The "Add Card" button provides access to the corresponding page for card addition.

# <img src="ScreenShots/Cards.png" alt="Cards" style="width: 80%; height: auto;">

<details><summary>Additional details for adding card</summary>

• Card Name <br>
    o Required<br>
    o Must be at least 3 characters long<br>
    o Maximum of 16 characters long<br>
    o Must be unique within the user's cards<br>

• Card Number <br>
    o Required<br>
    o Must be unique within the user's cards<br>

• Expiration Date (MMyy) <br>
    o Required<br>
    o Date format Month Year<br>

• Cardholder <br>
    o Required<br>
    o Date format Month Year<br>
    o Must be at least 2 characters long<br>
    o Maximum of 30 characters long<br>

• Check Number <br>
    o Required<br>
    o Must exactly 3 digits long<br>

• Currency <br>
    o Required<br>
    o Supported currencies - BGN, EUR, USD<br>

• Card Type: <br>
    o Required<br>
    o Types - Debit or Credit<br>

</details>

##### Welcome page logged user <br>
> Upon logging in, users will be directed to a welcome page where they will find an overview, that includes details about their last three transactions and a chart providing information about the count of the transactions types they have made.<br>

# <img src="ScreenShots/Welcome.png" alt="Welcome" style="width: 80%; height: auto;">

##### Transactions <br>
> Once a user has both a wallet and a valid card, they are all set to initiate transactions. The app offers three distinct types of transactions that users can engage in.<br>

# <img src="ScreenShots/Transactions_Menu.png" alt="Transactions_Menu" style="width: 20%; height: auto;">

##### Transfer <br>
> This transaction enables users to transfer funds from their wallet to another user's wallet.<br>

<details><summary>Additional details for Transfer</summary>

• Select Recipient <br>
    o User should select recipient username from a list<br>
    o Can search the list for user by username, phone number and email<br>

• Create Transfer <br>
    o Shows the selected username for recepient<br>
    o Field for amount that should be sent<br>
    o Description field<br>
    o Both fields are required.<br>


• Successful transafer will be made if <br>
    o The amount is in decimal format<br>
    o The amount is less than or equal to the wallet's amount<br>
    o Description is at least 2 and not more than 150 characters long<br>
    o Recipient has wallet in the system<br>
    o Action is confirmed<br>

• Successful transafer will send email with notification to the recipient<br>

</details>

##### Deposit <br>
> This transaction enables users to transfer funds from any of their cards to their wallet.<br>

<details><summary>Additional details for Deposit</summary>

• Create Deposit <br>
    o Field for amount that should be deposited<br>
    o List of user's cards<br>
    o Description field<br>
    o All fields are required.<br>


• Successful deposit will be made if <br>
    o The amount is in decimal format<br>
    o The amount is less than or equal to the wallet's amount<br>
    o The user has wallet and card<br>
    o Description is at least 2 and not more than 150 characters long<br>
    o Action is confirmed<br>

</details>

##### Withdraw <br>
> This transaction enables users to transfer funds from their wallet to their cards.<br>

<details><summary>Additional details for Withdraw</summary>

• Create Withdraw <br>
    o Field for amount that should be withdrawed<br>
    o List of user's cards<br>
    o Description field<br>
    o All fields are required.<br>


• Successful withdraw will be made if <br>
    o The amount is in decimal format<br>
    o The amount is less than or equal to the wallet's amount<br>
    o The user has wallet and card<br>
    o Description is at least 2 and not more than 150 characters long<br>
    o Action is confirmed<br>

</details>

> On successful transaction, the user is redirected to the trnsaction info page.<br>

##### Transactions Info <br>
> Each user has access to all transactions concerning him, transactions he made and transactions that was send to him.<br>
Access to the page is given via button in the left side.<br>
This page provides list of all transactions, option to view details for each transaction and search options.<br>
The search options are listed in expandable button and can be variously combined.

# <img src="ScreenShots/Transactions.png" alt="Transactions" style="width: 80%; height: auto;">

### Administrative Part<br>

> Administrators have the responsibility of managing users. They are granted access to a dashboard that displays a list of all users and allows them to search for users by phone number, username, or email. Administrators have the authority to promote or demote users, as well as to block, unblock, and delete users.<br>
Additionally, administrators have the capability to view lists of all users' cards and their corresponding details, as well as comprehensive information about all users' wallets and their associated details.<br>
Last, but not least, administrators can access list of all transactions made by all users, view each transaction details and again search options.

# <img src="ScreenShots/Admin_Dashboard.png" alt="Admin_Dashboard" style="width: 80%; height: auto;">

### Database Diagram <br>

# <img src="ScreenShots/Database.png" alt="Database_Diagram" style="width: 80%; height: auto;">

### Additionals <br>

> Next to app's logo home button, there is button for access to app's REST API via Swagger.<br>
Accessing external links and being inactive for 15 minutes from the system, will cause user logout.<br>
There is also a privacy and policy button. There could be found standart text for real-world web wallet app <br>and bit of humorius part added for fun!<br>
Interactive footer with company and project developers team info, could be found at the bottom pf the page.
<br><hr><br>

<details><summary>Technological Info</summary>

o C#, ASP.NET Core MVC<br>
o HTML, CSS, JavaScript<br>
o Microsoft EntityFrameworkCore SqlServer<br>
o AutoMapper Extensions Microsoft DependencyInjection<br>
o Microsoft AspNetCore Mvc NewtonsoftJson<br>
o MailKit integration<br>
o ExchangeRateAPI integration<br>
o Microsoft NET Test Sdk<br>

</details>

<br><br>



## Thank you for your attention!
