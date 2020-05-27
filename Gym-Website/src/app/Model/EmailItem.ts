export class EmailItem{
    toEmail:string;
    fromEmail:string;
    subject:string;
    message:string;

    constructor( toEmail:string, fromEmail:string, subject:string, message:string){
        this.toEmail=toEmail;
        this.fromEmail=fromEmail;
        this.subject=subject;
        this.message=message;
    }
}