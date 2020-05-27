import { Component, OnInit, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { LoginService } from 'src/app/Services/login.service';
import { User } from 'src/app/Model/User';
import { MessengerService } from 'src/app/Services/messenger.service';
import { EmailService } from 'src/app/Services/email.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  @ViewChild('username_login') username_login : ElementRef;
  @ViewChild('password_login') password_login : ElementRef;
  @ViewChild('username_signup') username_signup : ElementRef;
  @ViewChild('email_signup') email_signup : ElementRef;
  @ViewChild('password_signup') password_signup : ElementRef;
  @ViewChild('passwordConfirm_signup') passwordConfirm_signup : ElementRef;

  constructor(private loginService : LoginService, private messageService : MessengerService, private emailService:EmailService) { }

  ngOnInit(): void {
  }

  login(){
    let username = this.username_login.nativeElement.value;
    let password = this.password_login.nativeElement.value;

    this.loginService.login(username,password).subscribe( 
      user => {
        if(user == null){
          alert('Login Failed!');
        }
        else{
          alert('Login Succesful!');
          this.messageService.sendUser(user);
          this.messageService.sendLoginState('hidden');
        }
      },
      err =>{
        alert('Server error!');
      }
    )
  }

  signUp(){
    let username = this.username_signup.nativeElement.value;
    let email = this.email_signup.nativeElement.value;
    let password = this.password_signup.nativeElement.value;
    let passwordConfirm = this.passwordConfirm_signup.nativeElement.value;

    if(password == passwordConfirm)
    {  
      this.loginService.usernameExists(username).subscribe(
        (res : boolean) => {
          if(res == false) {
            this.verifyEmail(email)
          }
          else
          {
            alert('Invalid credentials!');
          }
        },
        err =>{
          alert('Server error user!');
        }
      );
    }
    else
    {
      alert('Invalid credentials!');
    }
  }

  verifyEmail(email){
    this.loginService.emailExists(email).subscribe(
      (res : boolean) => {
        if(res == false) 
        {
          this.doSignUp()
        }
        else
        {
          alert('Invalid credentials!');
        }
      },
      err =>{
        alert('Server error!');
      }
    );
  }

  doSignUp(){
    let username = this.username_signup.nativeElement.value;
    let email = this.email_signup.nativeElement.value;
    let password = this.password_signup.nativeElement.value;

    let user = new User(username,email,password);
    this.loginService.signUp(user).subscribe(
      res=>{
        if(res!=null){
          alert('SignUp Succesful!');
          this.messageService.sendUser(user);
          this.messageService.sendLoginState('hidden');
          this.emailService.sendEmailOnSignUp(user);
        }
        else{
          alert('SignUp failed!');
        }
      },
      err=>{
        alert('Server error!');
      }
    );
  }

}
