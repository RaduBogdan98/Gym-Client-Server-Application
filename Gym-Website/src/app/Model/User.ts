export class User
{ 
    username:string;
    email:string;
    password:string;

    constructor(Username:string, Email:string, Password:string)
    {
        this.username = Username;
        this.email = Email;
        this.password = Password;
    }
}